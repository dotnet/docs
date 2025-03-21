using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.ServiceModel.MsmqIntegration;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples
{
    class Snippets
    {
        public static void Snippet2()
        {
            // <Snippet2>
            MsmqIntegrationBinding binding = new MsmqIntegrationBinding();
            EndpointAddress address = new EndpointAddress("msmq.formatname:DIRECT=OS:.\\private$\\Orders");
            ChannelFactory<IOrderProcessor> channelFactory = new ChannelFactory<IOrderProcessor>(binding, address);
            IOrderProcessor channel = channelFactory.CreateChannel();

            PurchaseOrder po = new PurchaseOrder();
            po.customerId = "somecustomer.com";
            po.poNumber = Guid.NewGuid().ToString();

            PurchaseOrderLineItem lineItem1 = new PurchaseOrderLineItem();
            lineItem1.productId = "Blue Widget";
            lineItem1.quantity = 54;
            lineItem1.unitCost = 29.99F;

            PurchaseOrderLineItem lineItem2 = new PurchaseOrderLineItem();
            lineItem2.productId = "Red Widget";
            lineItem2.quantity = 890;
            lineItem2.unitCost = 45.89F;

            po.orderLineItems = new PurchaseOrderLineItem[2];
            po.orderLineItems[0] = lineItem1;
            po.orderLineItems[1] = lineItem2;

            MsmqMessage<PurchaseOrder> ordermsg = new MsmqMessage<PurchaseOrder>(po);
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                channel.SubmitPurchaseOrder(ordermsg);
                scope.Complete();
            }
            Console.WriteLine($"Order has been submitted:{po}");
            // </Snippet2>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            MsmqIntegrationBinding binding = new MsmqIntegrationBinding("MyBindingConfig");
            // </Snippet3>
        }

        public static void Snippet4()
        {
            MsmqIntegrationBinding binding = new MsmqIntegrationBinding();
            binding.SerializationFormat = MsmqMessageSerializationFormat.Binary;
        }

        public static void Snippet5()
        {
            // <Snippet5>
            MsmqIntegrationBinding binding = new MsmqIntegrationBinding(MsmqIntegrationSecurityMode.Transport);
            // </Snippet5>
        }
    }
}
