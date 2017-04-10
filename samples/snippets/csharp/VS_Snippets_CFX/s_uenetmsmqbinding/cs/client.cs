
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.Transactions;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedwcfClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
           // Create a WCF client with a given client endpoint configuration.
          QueueCalculatorClient wcfClient = new QueueCalculatorClient();
          try
          {
            //Create a transaction scope.
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                // Call the Add service operation.
                double value1 = 100.00D;
                double value2 = 15.99D;
                wcfClient.Add(value1, value2);
                Console.WriteLine("Add({0},{1})", value1, value2);

                // Call the Subtract service operation.
                value1 = 145.00D;
                value2 = 76.54D;
                wcfClient.Subtract(value1, value2);
                Console.WriteLine("Subtract({0},{1})", value1, value2);

                // Call the Multiply service operation.
                value1 = 9.00D;
                value2 = 81.25D;
                wcfClient.Multiply(value1, value2);
                Console.WriteLine("Multiply({0},{1})", value1, value2);

                // Call the Divide service operation.
                value1 = 22.00D;
                value2 = 7.00D;
                wcfClient.Divide(value1, value2);
                Console.WriteLine("Divide({0},{1})", value1, value2);

                // Complete the transaction.
                scope.Complete();
            }
            wcfClient.Close();

          }
          catch (TimeoutException timeProblem)
          {
            Console.WriteLine("The service operation timed out. " + timeProblem.Message);
            Console.ReadLine();
            wcfClient.Abort();
          }
          catch (CommunicationException commProblem)
          {
            Console.WriteLine("There was a communication problem. " + commProblem.Message + commProblem.StackTrace);
            Console.ReadLine();
            wcfClient.Abort();
          }
          Console.WriteLine();
          Console.WriteLine("Press <ENTER> to terminate client.");
          Console.ReadLine();
        }
    }
}
