//<snippet5>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//<snippet1>
using System.ServiceModel;
using System.ServiceModel.Description;
//</snippet1>

namespace SelfHost
{
    //<snippet2>
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string SayHello(string name);
    }

    public class HelloWorldService : IHelloWorldService
    {
        public string SayHello(string name)
        {
            return string.Format("Hello, {0}", name);
        }
    }
    //</snippet2>

    class Program
    {
        static void Main(string[] args)
        {
            //<snippet3>
            Uri baseAddress = new Uri("http://localhost:8080/hello");
            //</snippet3>

            //<snippet4>
            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(HelloWorldService), baseAddress))
            {
                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                Console.WriteLine($"The service is ready at {baseAddress}");
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
            //</snippet4>
        }
    }
}
//</snippet5>