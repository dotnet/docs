using System;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;

namespace BasicWebProgramming
{
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

    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
