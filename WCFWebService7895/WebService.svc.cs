using Application;
using Domain.Entities;
using Infrastructure.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFWebService7895
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class WebService : IWebService
    {
        SwipeService swipeService = new SwipeService();
        TerminalRepository terminalRepo = new TerminalRepository();
        SwipeRepository swipeRepo = new SwipeRepository();
        ITerminalStatusCallback Callback = OperationContext.Current.GetCallbackChannel<ITerminalStatusCallback>();
        
        public async Task StartCollectingSwipes()
        {
            var termins = terminalRepo.GetTerminals();
            var updatedTerminals = new List<Terminal>();
            
            await Task.Run(() =>
            {
                Parallel.ForEach(termins, new ParallelOptions { MaxDegreeOfParallelism = 3 }, (t) =>
                {
                    t.Status = "InProcess";
                    terminalRepo.Update(t);
                    updatedTerminals = terminalRepo.GetTerminals();                    
                    Callback.GetStatus(updatedTerminals);

                    var swipes = swipeService.RetrieveSwipes(t);
                    swipeRepo.BulkInsert(swipes);

                    t.Status = "Finished";
                    terminalRepo.Update(t);
                    updatedTerminals = terminalRepo.GetTerminals();                    
                    Callback.GetStatus(updatedTerminals);
                });
            });
        }
    }
}
