
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.Transactions;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.
    // <Snippet11>
    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // <Snippet7>
            // Create a client with given client endpoint configuration.
            QueueCalculatorClient client = new QueueCalculatorClient();
            try
            {
                //Create a transaction scope.
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    // Call the Add service operation.
                    double value1 = 100.00D;
                    double value2 = 15.99D;
                    client.Add(value1, value2);
                    Console.WriteLine("Add({0},{1})", value1, value2);

                    // Call the Subtract service operation.
                    value1 = 145.00D;
                    value2 = 76.54D;
                    client.Subtract(value1, value2);
                    Console.WriteLine("Subtract({0},{1})", value1, value2);

                    // Call the Multiply service operation.
                    value1 = 9.00D;
                    value2 = 81.25D;
                    client.Multiply(value1, value2);
                    Console.WriteLine("Multiply({0},{1})", value1, value2);

                    // Call the Divide service operation.
                    value1 = 22.00D;
                    value2 = 7.00D;
                    client.Divide(value1, value2);
                    Console.WriteLine("Divide({0},{1})", value1, value2);

                    // Complete the transaction.
                    scope.Complete();
                }
                client.Close();
            }
            catch (CommunicationException ex)
            {
                client.Abort();
            }
            // </Snippet7>

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
    // </Snippet11>
}
