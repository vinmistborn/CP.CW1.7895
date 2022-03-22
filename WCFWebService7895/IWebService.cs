using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Domain.Entities;

namespace WCFWebService7895
{
    /// <summary>
    /// Defines web service methods for clients
    /// Implements CallbackContract to report the progress of a service to the client
    /// </summary>
    [ServiceContract(CallbackContract = typeof(ITerminalStatusCallback))]
    public interface IWebService
    {
        /// <summary>
        /// Collects swipes of terminals and saves it to the database
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Task StartCollectingSwipes();
    }

    public interface ITerminalStatusCallback
    {
        /// <summary>
        /// Reports the status of terminals to the client
        /// A communication method between the web service and the windows forms
        /// </summary>
        /// <param name="updatedTerminals">Terminals with updated status (InProcess, Finished)</param>
        /// <returns></returns>
        [OperationContract(IsOneWay = true)]
        Task GetStatus(List<Terminal> updatedTerminals);
    }
}
