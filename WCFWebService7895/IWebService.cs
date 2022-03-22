using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Domain.Entities;

namespace WCFWebService7895
{
    [ServiceContract(CallbackContract = typeof(ITerminalStatusCallback))]
    public interface IWebService
    {
        [OperationContract]
        Task StartCollectingSwipes();
    }

    public interface ITerminalStatusCallback
    {
        [OperationContract(IsOneWay = true)]
        Task GetStatus(List<Terminal> updatedTerminals);
    }
}
