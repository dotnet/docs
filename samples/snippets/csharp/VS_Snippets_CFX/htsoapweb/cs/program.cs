// <Snippet13>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;

namespace Microsoft.ServiceModel.Samples.BasicWebProgramming
{
    // <Snippet0>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet]
        string EchoWithGet(string s);

        [OperationContract]
        [WebInvoke]
        string EchoWithPost(string s);
    }
    // </Snippet0>

    // <Snippet1>
    public class Service : IService
    {
        public string EchoWithGet(string s)
        {
            return "You said " + s;
        }

        public string EchoWithPost(string s)
        {
            return "You said " + s;
        }
    }
    // </Snippet1>
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet2>
            ServiceHost host = new ServiceHost(typeof(Service), new Uri("http://localhost:8000"));
            // </Snippet2>
            // <Snippet3>
            host.AddServiceEndpoint(typeof(IService), new BasicHttpBinding(), "Soap");
            // </Snippet3>
            // <Snippet4>
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "Web");
            endpoint.Behaviors.Add(new WebHttpBehavior());
            // </Snippet4>

            try
            {
                // <Snippet5>
                host.Open();
                // </Snippet5>

                // <Snippet6>
                using (WebChannelFactory<IService> wcf = new WebChannelFactory<IService>(new Uri("http://localhost:8000/Web")))
                // </Snippet6>
                {
                    // <Snippet8>
                    IService channel = wcf.CreateChannel();

                    string s;

                    Console.WriteLine("Calling EchoWithGet by HTTP GET: ");
                    s = channel.EchoWithGet("Hello, world");
                    Console.WriteLine($"   Output: {s}");

                    Console.WriteLine("");
                    Console.WriteLine("This can also be accomplished by navigating to");
                    Console.WriteLine("http://localhost:8000/Web/EchoWithGet?s=Hello, world!");
                    Console.WriteLine("in a web browser while this sample is running.");

                    Console.WriteLine("");

                    Console.WriteLine("Calling EchoWithPost by HTTP POST: ");
                    s = channel.EchoWithPost("Hello, world");
                    Console.WriteLine($"   Output: {s}");
                    // </Snippet8>
                    Console.WriteLine("");
                }
                // <Snippet10>
                using (ChannelFactory<IService> scf = new ChannelFactory<IService>(new BasicHttpBinding(), "http://localhost:8000/Soap"))
                // </Snippet10>
                {
                    // <Snippet11>
                    IService channel = scf.CreateChannel();

                    string s;

                    Console.WriteLine("Calling EchoWithGet on SOAP endpoint: ");
                    s = channel.EchoWithGet("Hello, world");
                    Console.WriteLine($"   Output: {s}");

                    Console.WriteLine("");

                    Console.WriteLine("Calling EchoWithPost on SOAP endpoint: ");
                    s = channel.EchoWithPost("Hello, world");
                    Console.WriteLine($"   Output: {s}");
                    // </Snippet11>
                    Console.WriteLine("");
                }

                Console.WriteLine("Press [Enter] to terminate");
                Console.ReadLine();
                // <Snippet9>
                host.Close();
                // </Snippet9>
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine($"An exception occurred: {cex.Message}");
                host.Abort();
            }
        }
    }
}
// </Snippet13>
