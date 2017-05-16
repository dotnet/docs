
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in a file generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a WCF client with given client endpoint configuration
          InstanceContextCalculatorClient wcfClient = new InstanceContextCalculatorClient();
          try
            {
                // Call the Add service operation.
                //int value1 = 15;
                //int value2 = 3;
                //int result = wcfClient.Add(value1, value2);
                //Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

                // Call the Subtract service operation.
                //value1 = 145;
                //value2 = 76;
                //result = wcfClient.Subtract(value1, value2);
                //Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

                // Call the Multiply service operation.
                //value1 = 9;
                //value2 = 81;
                //result = wcfClient.Multiply(value1, value2);
                //Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

                // Call the Divide service operation - trigger a divide by zero error.
                //value1 = 22;
                //value2 = 7;
                //result = wcfClient.Divide(value1, value2);
                //Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

                // Obtain InstanceContext information from the service.
                //Console.WriteLine("GetInstanceContextInfo");
              //Console.WriteLine(wcfClient.GetInstanceContextInfo());

                Console.WriteLine("Test");
                wcfClient.GetIncomingChannels();
                wcfClient.Close(); // close the client object.
          

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
