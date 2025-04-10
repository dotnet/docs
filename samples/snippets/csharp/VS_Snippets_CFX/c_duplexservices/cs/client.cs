
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    // The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    // Define class which implements callback interface of duplex contract
    //<snippet2>
    public class CallbackHandler : ICalculatorDuplexCallback
    {
        public void Equals(double result)
        {
            Console.WriteLine($"Equals({result})");
        }

        public void Equation(string eqn)
        {
            Console.WriteLine($"Equation({eqn})");
        }
    }
    //</snippet2>
    class Client
    {
        static void Main()
        {
            //<snippet3>
            // Construct InstanceContext to handle messages on callback interface
            InstanceContext instanceContext = new InstanceContext(new CallbackHandler());

            // Create a client
            CalculatorDuplexClient client = new CalculatorDuplexClient(instanceContext);
            //</snippet3>
            Console.WriteLine("Press <ENTER> to terminate client once the output is displayed.");
            Console.WriteLine();

            // Call the AddTo service operation.
            double value = 100.00D;
            client.AddTo(value);

            // Call the SubtractFrom service operation.
            value = 50.00D;
            client.SubtractFrom(value);

            // Call the MultiplyBy service operation.
            value = 17.65D;
            client.MultiplyBy(value);

            // Call the DivideBy service operation.
            value = 2.00D;
            client.DivideBy(value);

            // Complete equation
            client.Clear();

            Console.ReadLine();

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();
        }
    }
}
