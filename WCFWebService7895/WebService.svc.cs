using Application;
using Domain.Entities;
using Infrastructure.DAL.Repositories;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WCFWebService7895
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class WebService : IWebService
    {
        /*----Initializing the required objects----*/

        SwipeService swipeService = new SwipeService();
        TerminalRepository terminalRepo = new TerminalRepository();
        SwipeRepository swipeRepo = new SwipeRepository();

        /// <summary>
        /// Reports the status of terminals to the client
        /// </summary>
        ITerminalStatusCallback Callback = OperationContext.Current.GetCallbackChannel<ITerminalStatusCallback>();
   
        /// <summary>
        /// Collects swipes from terminals
        /// </summary>
        /// <returns>Task - thread</returns>
        public async Task StartCollectingSwipes()
        {
            //getting the list of terminals
            var termins = terminalRepo.GetTerminals();

            //defining the list of terminals to add updated terminals
            var updatedTerminals = new List<Terminal>();
            
            //implementing concurrency to collect swipes from terminals
            //await Task.Run - runs anynomous threads/methods concurrently
            await Task.Run(() =>
            {
                //Parallel - thread class that executes threads in parallel
                //foreach terminal in the database
                //MaxDegreeOfParallelism - defines how many threads can execute in parallel at the same time
                Parallel.ForEach(termins, new ParallelOptions { MaxDegreeOfParallelism = 3 }, (t) =>
                {
                    //When a thread starts executing first it updates the status of terminal
                    t.Status = "InProcess";
                    terminalRepo.Update(t);

                    //adding updated terminals with status InProcess
                    updatedTerminals = terminalRepo.GetTerminals();   
                    
                    //Passing the updatedTerminals to Callback to inform the client about the progress of terminals
                    Callback.GetStatus(updatedTerminals);

                    //Retrieving swipes from third-party library
                    var swipes = swipeService.RetrieveSwipes(t);
                    //Saving swipes to the database
                    swipeRepo.BulkInsert(swipes);

                    //Once the swipes are added, updating the status of terminals
                    t.Status = "Finished";
                    terminalRepo.Update(t);
                    updatedTerminals = terminalRepo.GetTerminals();  
                    //Reporting the progress of terminals to the client
                    Callback.GetStatus(updatedTerminals);
                });
            });
        }
    }
}
