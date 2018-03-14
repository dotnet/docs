
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
// <Snippet6>
using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    // The service contract is defined in code generated from the service by the svcutil tool.

    // Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a WCF client object.
            CalculatorClient wcfClient = new CalculatorClient();
            try
            {
              // Call the Add service operation.
              double value1 = 100.00D;
              double value2 = 15.99D;
              double result = wcfClient.Add(value1, value2);
              Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

              // Call the Subtract service operation.
              value1 = 145.00D;
              value2 = 76.54D;
              result = wcfClient.Subtract(value1, value2);
              Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

              // Call the Multiply service operation.
              value1 = 9.00D;
              value2 = 81.25D;
              result = wcfClient.Multiply(value1, value2);
              Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

              // Call the Divide service operation.
              value1 = 22.00D;
              value2 = 7.00D;
              result = wcfClient.Divide(value1, value2);
              Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

              // Closing the client gracefully closes the connection and cleans up resources.
              wcfClient.Close();
            }
            catch (TimeoutException timeout)
            {
              Console.WriteLine(timeout.Message);
              Console.ReadLine();
              wcfClient.Abort();
            }
            catch (CommunicationException commProblem)
            {
              Console.WriteLine(commProblem.Message);
              Console.ReadLine();
              wcfClient.Abort();
            } 
          
          Console.WriteLine();
          Console.WriteLine("Press <ENTER> to terminate client.");
          Console.ReadLine();
        }
    }
}
// </Snippet6>
