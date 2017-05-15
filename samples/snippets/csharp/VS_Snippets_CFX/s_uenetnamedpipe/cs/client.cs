using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace UE.Samples
{
    class client
    {
        static void Main(string[] args)
        {
          CalculatorClient wcfClient = new CalculatorClient("NetNamedPipeBinding_ICalculator");
          try
          {
            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = wcfClient.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);
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
