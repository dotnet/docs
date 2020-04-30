
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    // The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.

    // Define class which implements callback interface of duplex contract
    public class CallbackHandler : ICalculatorDuplexCallback
    {
		public void Equals(double result)
		{
			Console.WriteLine("Equals({0})", result);
		}

        public void Equation(string eqn)
		{
            Console.WriteLine("Equation({0})", eqn);
		}
    }

    class Client
    {
        static void Main()
        {
            // Construct InstanceContext to handle messages on callback interface
            InstanceContext instanceContext = new InstanceContext(new CallbackHandler());

            // Create a proxy with given client endpoint configuration
            CalculatorDuplexClient wcfClient = new CalculatorDuplexClient(instanceContext);
            try
            {
                // Call the AddTo service operation.
                double value = 100.00D;
                wcfClient.AddTo(value);

                // Call the SubtractFrom service operation.
                value = 50.00D;
                wcfClient.SubtractFrom(value);

                // Call the MultiplyBy service operation.
                value = 17.65D;
                wcfClient.MultiplyBy(value);

                // Call the DivideBy service operation.
                value = 2.00D;
                wcfClient.DivideBy(value);

                // Complete equation
                wcfClient.Clear();

                // Wait for callback messages to complete before closing
                System.Threading.Thread.Sleep(500);

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
