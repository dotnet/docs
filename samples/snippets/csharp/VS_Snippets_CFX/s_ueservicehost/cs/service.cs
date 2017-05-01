using System;
using System.Configuration;
using System.ServiceModel;

namespace ServiceModel.Sample
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

        // Host the service within this EXE console application.
        public static void Main()
        {
            // Get base address from app settings in configuration
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            // <Snippet1>
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            // </Snippet1>


            // Open the ServiceHostBase to create listeners and start listening for messages.
            serviceHost.Open();

            // The service can now be accessed.
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            // Close the ServiceHostBase to shutdown the service.
            serviceHost.Close();
        }

        public static void Snippet2()
        {
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            // <Snippet2>
            BasicHttpBinding binding = new BasicHttpBinding();
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service/basic");
            serviceHost.AddServiceEndpoint("IMetadataExchange", binding, address);
            // </Snippet2>
        }

        public static void Snippet3()
        {
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            // <Snippet3>
            WSHttpBinding binding = new WSHttpBinding();
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, "http://localhost:8000/servicemodelsamples/service/basic");
            // </Snippet3>
        }


        public static void Snippet4()
        {
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            // <Snippet4>
            BasicHttpBinding binding = new BasicHttpBinding();
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service/basic");
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, address);
            // </Snippet4>
        }
        
        public static void Snippet5()
        {
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            
            // <Snippet5>
            BasicHttpBinding binding = new BasicHttpBinding();
            Uri listenUri = new Uri("http://localhost:8000/MyListenUri");
            String address = "http://localhost:8000/servicemodelsamples/service2";
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, address, listenUri);
            // </Snippet5>
        }

        public static void Snippet6()
        {
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            
            // <Snippet6>
            BasicHttpBinding binding = new BasicHttpBinding();
            Uri listenUri = new Uri("http://localhost:8000/MyListenUri");
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service3");
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, address, listenUri);
            // </Snippet6>
        }

    }
}
