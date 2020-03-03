
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
// <Snippet3>
using System;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.Transactions;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            //Create a transaction scope.
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                // Create a proxy with given client endpoint configuration
                OrderTakerClient client = new OrderTakerClient("OrderTakerEndpoint");
                try
                {
                    // Open a purchase order
                    client.OpenPurchaseOrder("somecustomer.com");
                    Console.WriteLine("Purchase Order created");

                    // Add product line items
                    Console.WriteLine("Adding 10 quantities of blue widget");
                    client.AddProductLineItem("Blue Widget", 10);

                    Console.WriteLine("Adding 23 quantities of red widget");
                    client.AddProductLineItem("Red Widget", 23);

                    // Close the purchase order
                    Console.WriteLine("Closing the purchase order");
                    client.EndPurchaseOrder();
                    client.Close();
                }
                catch (CommunicationException ex)
                {
                    client.Abort();
                }
                // Complete the transaction.
                scope.Complete();
            }
            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
// </Snippet3>
