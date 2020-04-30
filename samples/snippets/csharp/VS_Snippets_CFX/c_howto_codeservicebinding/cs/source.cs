using System;
using System.ServiceModel;

namespace Samples
{

    //<snippet1>
  [ServiceContract]
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

    //</snippet1>

    //<snippet2>
  public class CalculatorService : ICalculator
  {
     public double Add(double n1, double n2)
     {
        return n1 + n2;
     }
     public double Subtract(double n1, double n2)
     {
        return n1 - n2;
     }
     public double Multiply(double n1, double n2)
     {
        return n1 * n2;
     }
     public double Divide(double n1, double n2)
     {
        return n1 / n2;
     }
  }

    //</snippet2>

    public class Test
    {
        public static void Main()
        {
            //<snippet3>

            // Specify a base address for the service

            String baseAddress = "http://localhost/CalculatorService";
            // Create the binding to be used by the service.

            BasicHttpBinding binding1 = new BasicHttpBinding();
            //</snippet3>		
            //<snippet5>

            TimeSpan modifiedCloseTimeout = new TimeSpan(00, 02, 00);
            binding1.CloseTimeout = modifiedCloseTimeout;
	    //</snippet5>

            //<snippet4>

            //<snippet6>

            using(ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.AddServiceEndpoint(typeof(ICalculator),binding1, baseAddress);

            //</snippet6>

                host.Open();
            }	
            //</snippet4>

            Console.WriteLine("Press <ENTER> to close...");

            Console.ReadLine();
        }

        public static void Snippets()
        {
            String baseAddress = "http://localhost/CalculatorService";

            //<snippet7>
            ServiceHost host = new ServiceHost(typeof(CalculatorService), new Uri(baseAddress));
            //</snippet7>
        }
    }
}
