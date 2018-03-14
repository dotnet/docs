// Snippet for ServiceEndpointCollection
// using System.ServiceModel.Description;

// <snippet1>
using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Xml;

namespace Microsoft.ServiceModel.Samples
{
    // Define an add service contract.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IAdd
    {
        [OperationContract]
        double Add(double n1, double n2);

    }

    // Implement the add service contract.
    public class AddService : IAdd
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        // Host the add service within an EXE console application.
        public static void Main()
        {
            // Set addresses for the service from configuration.
            Uri baseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"]);
          
            // Create a ServiceHost for the AddService type at the addAdddress.
            ServiceHost serviceHost = new ServiceHost(typeof(AddService), baseAddress);

            // Enumerate endpoints (defined in the App.config file).
                Console.WriteLine("All endpoints for the service:");
		ServiceDescription desc = serviceHost.Description;
		foreach (ServiceEndpoint endpoint in desc.Endpoints)
                {
                    Console.WriteLine("Endpoint - address:  {0}", endpoint.Address);
                    Console.WriteLine("           binding:  {0}", endpoint.Binding.Name);
                    Console.WriteLine("           contract: {0}", endpoint.Contract.Name);
                    Console.WriteLine();
                }

             // Find a service endpoint using the base address.
                ServiceEndpoint baseEndpoint = desc.Endpoints.Find(baseAddress);
                Console.WriteLine("A service endpoint at the base address:");
                Console.WriteLine("Endpoint - address:  {0}", baseEndpoint.Address);
                Console.WriteLine("           binding name:  {0}", baseEndpoint.Binding.Name);
                Console.WriteLine("           contract name: {0}", baseEndpoint.Contract.Name);
                Console.WriteLine();

             // Find an endpoint for the IAdd type of service.
                ServiceEndpoint addEndpoint = desc.Endpoints.Find(typeof(IAdd));
                Console.WriteLine("A service endpoint of the IAdd type:");
                Console.WriteLine("Endpoint - address:  {0}", addEndpoint.Address);
                Console.WriteLine("           binding name:  {0}", addEndpoint.Binding.Name);
                Console.WriteLine("           contract name: {0}", addEndpoint.Contract.Name);
                Console.WriteLine();

             // Find all of the endpoints for the IAdd type of service.
                Collection<ServiceEndpoint> addEndpoints = desc.Endpoints.FindAll(typeof(IAdd));
                Console.WriteLine("All the endpoints for the service of the IAdd type:");
                foreach (ServiceEndpoint endpoint in addEndpoints)
                {
                    Console.WriteLine("Endpoint - address:  {0}", endpoint.Address);
                    Console.WriteLine("           binding name:  {0}", endpoint.Binding.Name);
                    Console.WriteLine("           contract name: {0}", endpoint.Contract.Name);
                    Console.WriteLine();
                }

             // Find all of the endpoints for the service with the specific qualified contract name.
                XmlQualifiedName contractQName = new XmlQualifiedName("IAdd","http://Microsoft.ServiceModel.Samples");
                Collection<ServiceEndpoint> contractEndpoints = desc.Endpoints.FindAll(contractQName);
                Console.WriteLine("All endpoints for the service with the contract QName\n\t http://Microsoft.ServiceModel.Samples.IAdd");

                foreach (ServiceEndpoint endpoint in contractEndpoints)
                {
                    Console.WriteLine("Endpoint - address:  {0}", endpoint.Address);
                    Console.WriteLine("           binding name:  {0}", endpoint.Binding.Name);
                    Console.WriteLine("           contract name: {0}", endpoint.Contract.Name);
                    Console.WriteLine("           contract namespace: {0}", endpoint.Contract.Namespace);
                    Console.WriteLine();
                }

             // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();
                

             // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();

             // Close the ServiceHostBase to shutdown the service.
                serviceHost.Close();
        }
    }
}

/* This code produces the following output:

All endpoints for the service:
Endpoint - address:  http://localhost:8000/samples/service
           binding:  WSHttpBinding
           contract: IAdd

Endpoint - address:  net.tcp://localhost:9000/samples/service
           binding:  NetTcpBinding
           contract: IAdd

A service endpoint at the base address:
Endpoint - address:  http://localhost:8000/samples/service
           binding name:  WSHttpBinding
           contract name: IAdd

A service endpoint of the IAdd type:
Endpoint - address:  http://localhost:8000/samples/service
           binding name:  WSHttpBinding
           contract name: IAdd

All the endpoints for the service of the IAdd type:
Endpoint - address:  http://localhost:8000/samples/service
           binding name:  WSHttpBinding
           contract name: IAdd

Endpoint - address:  net.tcp://localhost:9000/samples/service
           binding name:  NetTcpBinding
           contract name: IAdd

All endpoints for the service with the contract QName
         http://Microsoft.ServiceModel.Samples.IAdd
Endpoint - address:  http://localhost:8000/samples/service
           binding name:  WSHttpBinding
           contract name: IAdd
           contract namespace: http://Microsoft.ServiceModel.Samples

Endpoint - address:  net.tcp://localhost:9000/samples/service
           binding name:  NetTcpBinding
           contract name: IAdd
           contract namespace: http://Microsoft.ServiceModel.Samples

The service is ready.
Press <ENTER> to terminate service.
*/

// </snippet1>