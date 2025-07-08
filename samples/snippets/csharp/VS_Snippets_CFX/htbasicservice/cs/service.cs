// <Snippet10>
// Service.cs
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
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri("http://localhost:8000/"));
            // </Snippet2>
            try
            {
                // <Snippet3>
                ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
                // </Snippet3>
                host.Open();
                // <Snippet6>
                using (ChannelFactory<IService> cf = new ChannelFactory<IService>(new WebHttpBinding(), "http://localhost:8000"))
                // </Snippet6>
                {
                    // <Snippet7>
                    cf.Endpoint.Behaviors.Add(new WebHttpBehavior());
                    // </Snippet7>

                    // <Snippet8>
                    IService channel = cf.CreateChannel();

                    string s;

                    Console.WriteLine("Calling EchoWithGet via HTTP GET: ");
                    s = channel.EchoWithGet("Hello, world");
                    Console.WriteLine($"   Output: {s}");

                    Console.WriteLine("");
                    Console.WriteLine("This can also be accomplished by navigating to");
                    Console.WriteLine("http://localhost:8000/EchoWithGet?s=Hello, world!");
                    Console.WriteLine("in a web browser while this sample is running.");

                    Console.WriteLine("");

                    Console.WriteLine("Calling EchoWithPost via HTTP POST: ");
                    s = channel.EchoWithPost("Hello, world");
                    Console.WriteLine($"   Output: {s}");
                    // </Snippet8>
                    Console.WriteLine("");
                }

                Console.WriteLine("Press <ENTER> to terminate");
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

// </Snippet10>