using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace Service
{
    [ServiceContract(Namespace = "http://migree.TcpSecurity.Service")]
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
            // <Snippet0>
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                serviceHost.Open();
                ServiceEndpointCollection endpoints = serviceHost.Description.Endpoints;
                ServiceEndpoint endpoint = endpoints.Find(typeof(ICalculator));

                NetTcpBinding binding = (NetTcpBinding) endpoint.Binding;

                // <Snippet1>
                NetTcpSecurity security = binding.Security;
                MessageSecurityOverTcp msTcp = security.Message;

                Console.WriteLine("Dumping NetTcpSecurity object:");
                Console.WriteLine("\tMessageSecurityOverTcp:");
                Console.WriteLine("\t\tAlgorithm Suite: {0}", msTcp.AlgorithmSuite);
                Console.WriteLine("\t\tClient Credential Type: {0}", msTcp.ClientCredentialType);
                // </Snippet1>

                Console.WriteLine("\tSecurity Mode: {0}", security.Mode);

                // <Snippet3>
                TcpTransportSecurity tsTcp = security.Transport;
                Console.WriteLine("\tTcpTransportSecurity:");
                Console.WriteLine("\t\tClient Credential Type: {0}", tsTcp.ClientCredentialType);
                Console.WriteLine("\t\tProtectionLevel: {0}", tsTcp.ProtectionLevel);
                // </Snippet3>

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();
            }
            // </Snippet0>
        }

        public static void Snippet2()
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                serviceHost.Open();
                ServiceEndpointCollection endpoints = serviceHost.Description.Endpoints;
                ServiceEndpoint endpoint = endpoints.Find(typeof(ICalculator));

                NetTcpBinding binding = (NetTcpBinding)endpoint.Binding;

                // <Snippet2>
                NetTcpSecurity security = binding.Security;
                Console.WriteLine("\tSecurity Mode: {0}", security.Mode);
                // </Snippet2>
            }
        }

    }

}
