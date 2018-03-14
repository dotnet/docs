
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a proxy with given client endpoint configuration
            using (CalculatorProxy proxy = new CalculatorProxy())
            {
                // Call the Add service operation.
                double value1 = 100.00D;
                double value2 = 15.99D;
                double result = proxy.Add(value1, value2);
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

                // Call the Subtract service operation.
                value1 = 145.00D;
                value2 = 76.54D;
                result = proxy.Subtract(value1, value2);
                Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

                // Call the Multiply service operation.
                value1 = 9.00D;
                value2 = 81.25D;
                result = proxy.Multiply(value1, value2);
                Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

                // Call the Divide service operation.
                value1 = 22.00D;
                value2 = 7.00D;
                result = proxy.Divide(value1, value2);
                Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
