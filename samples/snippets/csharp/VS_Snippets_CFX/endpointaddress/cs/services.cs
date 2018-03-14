using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  // Define a service contract.
  [ServiceContract(Namespace="Microsoft.WCF.Documentation")]
    public interface ICalculator
    {
      [OperationContract]
      double Add(double n1, double n2);
      [OperationContract]
      double Subtract(double n1, double n2);
  }

    // Service class which implements the service contract.
    // Added code to write output to the console window
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
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

        
    }
}
