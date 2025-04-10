//  Copyright (c) Microsoft Corporation. All rights reserved.
// <snippet6>
using System;

namespace Microsoft.ServiceModel.Samples
{
    // The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    class Client
    {
        static void Main()
        {
            Console.WriteLine("Press <ENTER> to terminate client once the output is displayed.");
            Console.WriteLine();

            // Create a client
            CalculatorClient client = new CalculatorClient();

            // <snippet5>
            // AddAsync
            double value1 = 100.00D;
            double value2 = 15.99D;
            client.AddCompleted += new EventHandler<AddCompletedEventArgs>(AddCallback);
            client.AddAsync(value1, value2);
            Console.WriteLine($"Add({value1},{value2})");
            // </snippet5>

            // SubtractAsync
            value1 = 145.00D;
            value2 = 76.54D;
            client.SubtractCompleted += new EventHandler<SubtractCompletedEventArgs>(SubtractCallback);
            client.SubtractAsync(value1, value2);
            Console.WriteLine($"Subtract({value1},{value2})");

            // Multiply
            value1 = 9.00D;
            value2 = 81.25D;
            double result = client.Multiply(value1, value2);
            Console.WriteLine($"Multiply({value1},{value2}) = {result}");

            // Divide
            value1 = 22.00D;
            value2 = 7.00D;
            result = client.Divide(value1, value2);
            Console.WriteLine($"Divide({value1},{value2}) = {result}");

            Console.ReadLine();

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();
        }

        // <snippet4>
        // Asynchronous callbacks for displaying results.
        static void AddCallback(object sender, AddCompletedEventArgs e)
        {
            Console.WriteLine($"Add Result: {e.Result}");
        }
        // </snippet4>

        static void SubtractCallback(object sender, SubtractCompletedEventArgs e)
        {
            Console.WriteLine($"Subtract Result: {e.Result}");
        }
    }
}
// </snippet6>
