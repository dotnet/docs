
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.ServiceModel.MsmqIntegration;

namespace Microsoft.ServiceModel.Samples
{
	
	[System.Diagnostics.DebuggerStepThroughAttribute()]
			[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public partial class OrderProcessorClient : System.ServiceModel.ClientBase<IOrderProcessor>, IOrderProcessor
	{

		public OrderProcessorClient()
		{
		}

		public OrderProcessorClient(string endpointConfigurationName) :
				base(endpointConfigurationName)
		{
		}

		public OrderProcessorClient(string endpointConfigurationName, string remoteAddress) :
				base(endpointConfigurationName, remoteAddress)
		{
		}

		public OrderProcessorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
				base(endpointConfigurationName, remoteAddress)
		{
		}

		public OrderProcessorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
				base(binding, remoteAddress)
		{
		}

		public void SubmitPurchaseOrder
				(MsmqMessage<PurchaseOrder> po)
		{
			base.Channel.SubmitPurchaseOrder(po);
		}
	}

    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet4>
            // Create the purchase order.
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

            OrderProcessorClient client = new OrderProcessorClient("OrderResponseEndpoint");
            MsmqMessage<PurchaseOrder> ordermsg = new MsmqMessage<PurchaseOrder>(po);
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                client.SubmitPurchaseOrder(ordermsg);
                scope.Complete();
            }

            Console.WriteLine($"Order has been submitted:{po}");

            //Closing the client gracefully closes the connection and cleans up resources.
            client.Close();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
            // </Snippet4>
        }
    }
}
