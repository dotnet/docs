//<snippet0>
using System;
using System.Collections.Generic;
using System.ServiceModel;
//<snippet0>
using System.ServiceModel.Description;
using System.Security.Principal;

namespace Unsecured
{
    class Service
    {
        static void Main(string[] args)
        {
            Service s = new Service();
            //s.UnsecuredHttp();
            s.UnsecuredTcp();
        }

        private void UnsecuredHttp()
        {

            //<snippet1>
            Uri httpUri = new Uri("http://localhost/Calculator");

            // Create the ServiceHost.
            ServiceHost myServiceHost = new ServiceHost(typeof(Calculator), httpUri);

            // Create a binding that uses HTTP. By default,
            // this binding has no security.
            BasicHttpBinding b = new BasicHttpBinding();

            // Add an endpoint to the service.
            myServiceHost.AddServiceEndpoint(typeof(ICalculator), b, "");
            // Open the service and wait for calls.
            AddMexEndpoint(ref myServiceHost);
            myServiceHost.Open();
            Console.Write("Listening....");
            Console.ReadLine();
            // Close the service when a key is pressed.
            myServiceHost.Close();
            //</snippet1>
        }

        private void UnsecuredTcp()
        {
            //<snippet2>
            Uri tcpUri = new Uri("net.tcp://localhost:8008/Calculator");

            // Create the ServiceHost.
            ServiceHost sh = new ServiceHost(typeof(Calculator), tcpUri);

            // Create a binding that uses TCP and set the security mode to none.
            NetTcpBinding b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.None;

            // Add an endpoint to the service.
            sh.AddServiceEndpoint(typeof(ICalculator), b, "");
            // Open the service and wait for calls.
            sh.Open();

            string listenUri = sh.Description.Endpoints[0].ListenUri.AbsoluteUri;
            Console.WriteLine("Listening on: {0}", listenUri);
            Console.Write("Press Enter to end the service");
            Console.ReadLine();
            // Close the service when a key is pressed.

            //</snippet2>
        }

        private void AddMexEndpoint(ref ServiceHost sv)
        {
            // Add an endpoint to return metadata.
            ServiceMetadataBehavior sb = new ServiceMetadataBehavior();
            sb.HttpGetEnabled = true;
            sb.HttpGetUrl = new Uri("http://localhost:8008/metadata");
            sv.Description.Behaviors.Add(sb);
        }
    }

    [ServiceContract]
    interface ICalculator
    {
        [OperationContract]
        double Add(double a, double b);
    }

    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }
}
