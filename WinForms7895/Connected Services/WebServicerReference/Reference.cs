﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinForms7895.WebServicerReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WebServicerReference.IWebService", CallbackContract=typeof(WinForms7895.WebServicerReference.IWebServiceCallback))]
    public interface IWebService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebService/StartCollectingSwipes", ReplyAction="http://tempuri.org/IWebService/StartCollectingSwipesResponse")]
        void StartCollectingSwipes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebService/StartCollectingSwipes", ReplyAction="http://tempuri.org/IWebService/StartCollectingSwipesResponse")]
        System.Threading.Tasks.Task StartCollectingSwipesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWebServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWebService/GetStatus")]
        void GetStatus(Domain.Entities.Terminal[] updatedTerminals);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWebServiceChannel : WinForms7895.WebServicerReference.IWebService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceClient : System.ServiceModel.DuplexClientBase<WinForms7895.WebServicerReference.IWebService>, WinForms7895.WebServicerReference.IWebService {
        
        public WebServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public WebServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public WebServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void StartCollectingSwipes() {
            base.Channel.StartCollectingSwipes();
        }
        
        public System.Threading.Tasks.Task StartCollectingSwipesAsync() {
            return base.Channel.StartCollectingSwipesAsync();
        }
    }
}
