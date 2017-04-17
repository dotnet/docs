
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
          CalculatorSessionClient wcfClient = new CalculatorSessionClient();
          try
          {
            wcfClient.Clear();
            wcfClient.AddTo(100.0D);
            wcfClient.SubtractFrom(50.0D);
            wcfClient.MultiplyBy(17.65D);
            wcfClient.DivideBy(2.0D);
            double result = wcfClient.Equals();
            Console.WriteLine("0 + 100 - 50 * 17.65 / 2 = {0}", result);
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
