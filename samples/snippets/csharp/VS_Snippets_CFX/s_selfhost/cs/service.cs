using System.Net;
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
//<snippet11>
using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
    }

    // Step 1: Create service class that implements the service contract.
//<snippet110>
    public class CalculatorService : ICalculator
//</snippet110>
    {
         // Step 2: Implement functionality for the service operations.
//<snippet111>
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            // Code added to write output to the console window.
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }
//</snippet111>
    }
}
//</snippet11>

namespace HowToCreateAclient
{
 public class Test
    {
        static void Main()
        {
            //<snippet15>
            string machineName = Dns.GetHostEntry("").HostName;
            // Print the fully qualified address to the screen.
            Console.WriteLine("Listening on: {0}:8000/servicemodel/", machineName);
            Console.ReadLine();
            //</snippet15>
        }
    }
}

