
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.MsmqIntegration;
using Microsoft.ServiceModel.Samples;

namespace Microsoft.ServiceModel.Samples
{
    // <Snippet6>
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IOrderProcessor
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> msg);
    }
   
    public interface IOrderProcessorChannel : IOrderProcessor, System.ServiceModel.IClientChannel
    {
    }
    // </Snippet6>
    
    // <Snippet7>
    public partial class OrderProcessorProxy : System.ServiceModel.ClientBase<IOrderProcessor>, IOrderProcessor
    {
        public OrderProcessorProxy(){}
        public OrderProcessorProxy(string configurationName) : base(configurationName){}

        public OrderProcessorProxy(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress address)
            : base(binding, address){}

        public void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> msg)
        {
            base.Channel.SubmitPurchaseOrder(msg);
        }
    }
    // </Snippet7>
}
