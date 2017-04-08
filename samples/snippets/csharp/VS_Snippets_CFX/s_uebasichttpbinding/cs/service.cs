using System;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace UE.ServiceModel.Samples
{
    // <Snippet1>
    [ServiceContract(Namespace = "http://UE.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract(IsOneWay = false)]
        double Add(double n1, double n2);
        [OperationContract(IsOneWay = false)]
        double Subtract(double n1, double n2);
        [OperationContract(IsOneWay = false)]
        double Multiply(double n1, double n2);
        [OperationContract(IsOneWay = false)]
        double Divide(double n1, double n2);
    }

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

        public static void Main()
        {
            // <Snippet2>
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "binding1";
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.Security.Mode = BasicHttpSecurityMode.None;
            
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service/calc");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, address);

            // Open the ServiceHostBase to create listeners and start listening for messages.
            serviceHost.Open();

            // The service can now be accessed.
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();
	    
            // Close the ServiceHostBase to shutdown the service.
            serviceHost.Close();
            
            //</Snippet2>
        }
    }
    // </Snippet1>
}

