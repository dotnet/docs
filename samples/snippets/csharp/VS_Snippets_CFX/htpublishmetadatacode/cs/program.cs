// <Snippet11>
// <Snippet0>
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Metadata.Samples
{
    [ServiceContract]
    public interface ISimpleService
    {
        [OperationContract]
        string SimpleMethod(string msg);
    }

    class SimpleService : ISimpleService
    {
        public string SimpleMethod(string msg)
        {
            Console.WriteLine("The caller passed in " + msg);
            return "Hello " + msg;
        }
    }
    // </Snippet0>

    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            ServiceHost svcHost = new ServiceHost(typeof(SimpleService), new Uri("http://localhost:8001/MetadataSample"));
            // </Snippet1>
            // <Snippet2>
            try
            {
            // </Snippet2>
                // <Snippet4>
                // Check to see if the service host already has a ServiceMetadataBehavior
                ServiceMetadataBehavior smb = svcHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
                // If not, add one
                if (smb == null)
                    smb = new ServiceMetadataBehavior();
                // </Snippet4>
                // <Snippet5>
                smb.HttpGetEnabled = true;
                // </Snippet5>
                // <Snippet6>
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                // </Snippet6>
                // <Snippet7>
                svcHost.Description.Behaviors.Add(smb);
                // </Snippet7>
                // <Snippet8>
                // Add MEX endpoint
                svcHost.AddServiceEndpoint(
                  ServiceMetadataBehavior.MexContractName,
                  MetadataExchangeBindings.CreateMexHttpBinding(),
                  "mex"
                );
                // </Snippet8>
                // <Snippet9>
                // Add application endpoint
                svcHost.AddServiceEndpoint(typeof(ISimpleService), new WSHttpBinding(), "");
                // </Snippet9>
                // <Snippet10>
                // Open the service host to accept incoming calls
                svcHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                svcHost.Close();
                // </Snippet10>
            // <Snippet3>
            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message);
                Console.Read();
            }
            // </Snippet3>
        }
    }
}
// </Snippet11>