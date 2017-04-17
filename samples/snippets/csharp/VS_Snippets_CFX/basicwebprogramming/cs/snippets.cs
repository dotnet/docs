using System;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;

namespace BasicWebProgramming
{
    class Snippets
    {
        public static void Snippet0()
        {
            // <Snippet0>
            Uri baseAddress = new Uri("http://localhost:8000");
            WebServiceHost host = new WebServiceHost(typeof(Service), baseAddress);
            try
            {
                host.Open();

                WebChannelFactory<IService> cf = new WebChannelFactory<IService>(baseAddress);
                IService channel = cf.CreateChannel();
                string s;

                Console.WriteLine("Calling EchoWithGet via HTTP GET: ");
                s = channel.EchoWithGet("Hello, world");
                Console.WriteLine("   Output: {0}", s);

                Console.WriteLine("");

                Console.WriteLine("Calling EchoWithPost via HTTP POST: ");
                s = channel.EchoWithPost("Hello, world");
                Console.WriteLine("   Output: {0}", s);

                Console.WriteLine("");
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
            }
            // </Snippet0>
        }
        public static void Snippet1()
        {
            // <Snippet1>
            Uri baseAddress = new Uri("http://localhost:8000");
            WebServiceHost host = new WebServiceHost(typeof(Service), baseAddress);
            try
            {
                host.Open();
                WebHttpBinding binding = new WebHttpBinding();
                WebChannelFactory<IService> cf = new WebChannelFactory<IService>(binding);
                cf.Endpoint.Address = new EndpointAddress("http://localhost:8000");
                IService channel = cf.CreateChannel();
                string s;

                Console.WriteLine("Calling EchoWithGet via HTTP GET: ");
                s = channel.EchoWithGet("Hello, world");
                Console.WriteLine("   Output: {0}", s);

            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
            }

            // </Snippet1>
        }
        public static void Snippet2()
        {
            // <Snippet2>
            Uri baseAddress = new Uri("http://localhost:8000");
            WebServiceHost host = new WebServiceHost(typeof(Service), baseAddress);
            try
            {
                host.Open();

                WebHttpBinding binding = new WebHttpBinding();
                ContractDescription desc = ContractDescription.GetContract(typeof(IService));
                EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8000");
                ServiceEndpoint endpoint = new ServiceEndpoint(desc, binding, endpointAddress);

                WebChannelFactory<IService> cf = new WebChannelFactory<IService>(endpoint);
                IService channel = cf.CreateChannel();
                string s;

                Console.WriteLine("Calling EchoWithGet via HTTP GET: ");
                s = channel.EchoWithGet("Hello, world");
                Console.WriteLine("   Output: {0}", s);
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
            }
            // </Snippet2>
        }
        public static void Snippet3()
        {
            // <Snippet3>
            Uri baseAddress = new Uri("http://localhost:8000");
            WebServiceHost host = new WebServiceHost(typeof(Service), baseAddress);
            try
            {
                host.Open();
            
                // The endpoint name passed to the constructor must match an endpoint element
                // in the application configuration file
                WebChannelFactory<IService> cf = new WebChannelFactory<IService>("MyEndpoint");
                IService channel = cf.CreateChannel();
                string s;

                Console.WriteLine("Calling EchoWithGet via HTTP GET: ");
                s = channel.EchoWithGet("Hello, world");
                Console.WriteLine("   Output: {0}", s);
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
            }
            // </Snippet3>
        }
        public static void Snippet4()
        {
            // <Snippet4>
            Uri baseAddress = new Uri("http://localhost:8000");
            WebServiceHost host = new WebServiceHost(typeof(Service), baseAddress);
            try
            {
                host.Open();

                WebChannelFactory<IService> cf = new WebChannelFactory<IService>(new Uri("http://localhost:8000"));
                IService channel = cf.CreateChannel();
                string s;

                Console.WriteLine("Calling EchoWithGet via HTTP GET: ");
                s = channel.EchoWithGet("Hello, world");
                Console.WriteLine("   Output: {0}", s);
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
            }
            // </Snippet4>
        }
        public static void Snippet5()
        {
            // <Snippet5>
            Uri baseAddress = new Uri("http://localhost:8000");
            WebServiceHost host = new WebServiceHost(typeof(Service), baseAddress);
            try
            {
                host.Open();

                WebHttpBinding binding = new WebHttpBinding();
                WebChannelFactory<IService> cf = new WebChannelFactory<IService>(binding, new Uri("http://localhost:8000"));
                IService channel = cf.CreateChannel();
                string s;

                Console.WriteLine("Calling EchoWithGet via HTTP GET: ");
                s = channel.EchoWithGet("Hello, world");
                Console.WriteLine("   Output: {0}", s);
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
            }
            // </Snippet5>
        }
        public static void Snippet6()
        {
            // <Snippet6>
            Uri baseAddress = new Uri("http://localhost:8000");
            WebServiceHost host = new WebServiceHost(typeof(Service), baseAddress);
            try
            {
                host.Open();

                // The endpoint name passed to the constructor must match an endpoint element
                // in the application configuration file
                WebChannelFactory<IService> cf = new WebChannelFactory<IService>("MyEndpoint", new Uri("http://localhost:8000"));
                IService channel = cf.CreateChannel();
                string s;

                Console.WriteLine("Calling EchoWithGet via HTTP GET: ");
                s = channel.EchoWithGet("Hello, world");
                Console.WriteLine("   Output: {0}", s);
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
            }
            // </Snippet6>
        }
    }
}
