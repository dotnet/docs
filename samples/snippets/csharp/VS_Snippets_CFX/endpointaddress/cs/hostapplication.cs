// <snippet0>
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

using System.Text;

namespace Microsoft.WCF.Documentation
{
  class HostApplication
  {

    static void Main()
    {
      HostApplication app = new HostApplication();
      app.Run();
    }

    private void Run()
    {

            // Get base address from app settings in configuration
            Uri baseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"]);

            //Create new address headers for special services and add them to an array
            AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader(
                "specialservice1", "http://localhost:8000/service", 1);
            AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader(
                "specialservice2", "http://localhost:8000/service", 2);

            // Enumerate address headers and their properties from the array.
            AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
            foreach (AddressHeader addressHeader in addressHeaders)
            {
                Console.WriteLine("AddressHeader - namespace:\t\t{0}", addressHeader.Namespace);
                Console.WriteLine("              - name:\t\t\t{0}", addressHeader.Name);
                Console.WriteLine("              - value:\t\t\t{0}", addressHeader.GetValue<int>());
                Console.WriteLine("              - type:\t\t\t{0}", addressHeader.GetType());
                Console.WriteLine("              - hashcode:\t\t{0}", addressHeader.GetHashCode());
                Console.WriteLine("              - equals addressHeader1:\t{0}", addressHeader.Equals(addressHeader1));
             //   Console.WriteLine("              - Is SOAP1.1 supported:\t{0}", addressHeader.ToMessageHeader().IsMessageVersionSupported(MessageVersion.WSAddressingSoap10));
                Console.WriteLine();
            }
            Console.WriteLine();

            //Add the array of address headers to an endpoint address
            EndpointAddress endpointAddress = new EndpointAddress(
                        new Uri("http://localhost:8003/servicemodelsamples/service"), addressHeaders);

            //Create a "special" service endpoint that uses the endpointAddress.
            string WSHttpBindingName = "Binding1";
            ServiceEndpoint specialServiceEndpoint = new ServiceEndpoint(
                ContractDescription.GetContract(typeof(CalculatorService)), new WSHttpBinding(WSHttpBindingName), endpointAddress
                );

            // Create a ServiceHost for the CalculatorService type that uses the base address.
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            //Add the specialServiceEndpoint to the serviceHost.
            serviceHost.Description.Endpoints.Add(specialServiceEndpoint);

            // Enumerate the service endpoints and some of their properties from the serviceHost.
            Console.WriteLine("Service endpoints:");
            ServiceDescription desc = serviceHost.Description;
            foreach (ServiceEndpoint endpoint in desc.Endpoints)
            {
                Console.WriteLine("Endpoint - address:  {0}", endpoint.Address);
                Console.WriteLine("         - binding name:\t\t{0}", endpoint.Binding.Name);
                // Console.WriteLine("         - binding name:\t\t{0}", endpoint.);
                Console.WriteLine("         - contract name:\t\t{0}", endpoint.Contract.Name);
                Console.WriteLine("         - contains addressHeader1:\t{0}", endpoint.Address.Headers.Contains(addressHeader1));
                Console.WriteLine("         - count of address headers:\t{0}", endpoint.Address.Headers.Count);
                Console.WriteLine();
            }

            Console.WriteLine();

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
    }
  }
// </snippet0>
