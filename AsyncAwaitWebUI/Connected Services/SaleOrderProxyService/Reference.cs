﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsyncAwaitWebUI.SaleOrderProxyService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SaleOrder", Namespace="http://schemas.datacontract.org/2004/07/AsyncAwaitService.Service")]
    [System.SerializableAttribute()]
    public partial class SaleOrder : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccountNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumberField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AccountNumber {
            get {
                return this.AccountNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.AccountNumberField, value) != true)) {
                    this.AccountNumberField = value;
                    this.RaisePropertyChanged("AccountNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Number {
            get {
                return this.NumberField;
            }
            set {
                if ((object.ReferenceEquals(this.NumberField, value) != true)) {
                    this.NumberField = value;
                    this.RaisePropertyChanged("Number");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SaleOrderProxyService.ISaleOrderService")]
    public interface ISaleOrderService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISaleOrderService/GetSaleOrders", ReplyAction="http://tempuri.org/ISaleOrderService/GetSaleOrdersResponse")]
        AsyncAwaitWebUI.SaleOrderProxyService.SaleOrder[] GetSaleOrders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISaleOrderService/GetSaleOrders", ReplyAction="http://tempuri.org/ISaleOrderService/GetSaleOrdersResponse")]
        System.Threading.Tasks.Task<AsyncAwaitWebUI.SaleOrderProxyService.SaleOrder[]> GetSaleOrdersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISaleOrderService/GetSaleOrdersTask", ReplyAction="http://tempuri.org/ISaleOrderService/GetSaleOrdersTaskResponse")]
        AsyncAwaitWebUI.SaleOrderProxyService.SaleOrder[] GetSaleOrdersTask();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISaleOrderService/GetSaleOrdersTask", ReplyAction="http://tempuri.org/ISaleOrderService/GetSaleOrdersTaskResponse")]
        System.Threading.Tasks.Task<AsyncAwaitWebUI.SaleOrderProxyService.SaleOrder[]> GetSaleOrdersTaskAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISaleOrderServiceChannel : AsyncAwaitWebUI.SaleOrderProxyService.ISaleOrderService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SaleOrderServiceClient : System.ServiceModel.ClientBase<AsyncAwaitWebUI.SaleOrderProxyService.ISaleOrderService>, AsyncAwaitWebUI.SaleOrderProxyService.ISaleOrderService {
        
        public SaleOrderServiceClient() {
        }
        
        public SaleOrderServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SaleOrderServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SaleOrderServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SaleOrderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AsyncAwaitWebUI.SaleOrderProxyService.SaleOrder[] GetSaleOrders() {
            return base.Channel.GetSaleOrders();
        }
        
        public System.Threading.Tasks.Task<AsyncAwaitWebUI.SaleOrderProxyService.SaleOrder[]> GetSaleOrdersAsync() {
            return base.Channel.GetSaleOrdersAsync();
        }
        
        public AsyncAwaitWebUI.SaleOrderProxyService.SaleOrder[] GetSaleOrdersTask() {
            return base.Channel.GetSaleOrdersTask();
        }
        
        public System.Threading.Tasks.Task<AsyncAwaitWebUI.SaleOrderProxyService.SaleOrder[]> GetSaleOrdersTaskAsync() {
            return base.Channel.GetSaleOrdersTaskAsync();
        }
    }
}
