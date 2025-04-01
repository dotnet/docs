//<snippet3>

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a client with given client endpoint configuration
            CalculatorClient client = new CalculatorClient();

            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            Console.WriteLine($"Add({value1},{value2}) = {result}");

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = client.Subtract(value1, value2);
            Console.WriteLine($"Subtract({value1},{value2}) = {result}");

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = client.Multiply(value1, value2);
            Console.WriteLine($"Multiply({value1},{value2}) = {result}");

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = client.Divide(value1, value2);
            Console.WriteLine($"Divide({value1},{value2}) = {result}");

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}

//</snippet3>
