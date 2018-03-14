// <Snippet12>
// This is the client code.
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.Transactions;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a client.
            OrderProcessorClient client = new OrderProcessorClient();

            // Create the purchase order.
            PurchaseOrder po = new PurchaseOrder();
            po.CustomerId = "somecustomer.com";
            po.PONumber = Guid.NewGuid().ToString();

            PurchaseOrderLineItem lineItem1 = new PurchaseOrderLineItem();
            lineItem1.ProductId = "Blue Widget";
            lineItem1.Quantity = 54;
            lineItem1.UnitCost = 29.99F;

            PurchaseOrderLineItem lineItem2 = new PurchaseOrderLineItem();
            lineItem2.ProductId = "Red Widget";
            lineItem2.Quantity = 890;
            lineItem2.UnitCost = 45.89F;

            po.orderLineItems = new PurchaseOrderLineItem[2];
            po.orderLineItems[0] = lineItem1;
            po.orderLineItems[1] = lineItem2;

            // <Snippet8>
            //Create a transaction scope.
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                // Make a queued call to submit the purchase order.
                client.SubmitPurchaseOrder(po);
                // Complete the transaction.
                scope.Complete();
            }

            //Closing the client gracefully closes the connection and cleans up resources.
            client.Close();
            // </Snippet8>

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
// </Snippet12>