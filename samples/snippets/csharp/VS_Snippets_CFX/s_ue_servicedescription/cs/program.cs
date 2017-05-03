using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServiceDescriptionSnippet
{
    [ServiceContract()]
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

    public class CalculatorService: ICalculator
    {
        public double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }

        public double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public double Divide(double n1, double n2)
        {
            return n1 / n2;
        }

        public static void Main()
        {
            // <Snippet0>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            // Enable Mex
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(smb);
 
            serviceHost.Open();

            // <Snippet1>
            // Use Default constructor
            ServiceDescription sd = new ServiceDescription();
            // </Snippet1>

            // <Snippet2>
            // Create ServiceDescription from a collection of service endpoints
            List<ServiceEndpoint> endpoints = new List<ServiceEndpoint>();
            ContractDescription conDescr = new ContractDescription("ICalculator");
            EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8001/Basic");
            ServiceEndpoint ep = new ServiceEndpoint(conDescr, new BasicHttpBinding(), endpointAddress);
            endpoints.Add(ep);
            ServiceDescription sd2 = new ServiceDescription(endpoints);
            // </Snippet2>

            // <Snippet3>
            // Iterate through the list of behaviors in the ServiceDescription
            ServiceDescription svcDesc = serviceHost.Description;
            KeyedByTypeCollection<IServiceBehavior> sbCol = svcDesc.Behaviors;
            foreach (IServiceBehavior behavior in sbCol)
            {
                Console.WriteLine("Behavior: {0}", behavior.ToString());
            }
            // </Snippet3>

            // <Snippet4>
            // svcDesc is a ServiceDescription.
            svcDesc = serviceHost.Description;
            string configName = svcDesc.ConfigurationName;
            Console.WriteLine("Configuration name: {0}", configName);
            // </Snippet4>

            // <Snippet5>
            // Iterate through the endpoints contained in the ServiceDescription
            ServiceEndpointCollection sec = svcDesc.Endpoints;
            foreach (ServiceEndpoint se in sec)
            {
                Console.WriteLine("Endpoint:");
                Console.WriteLine("\tAddress: {0}", se.Address.ToString());
                Console.WriteLine("\tBinding: {0}", se.Binding.ToString());
                Console.WriteLine("\tContract: {0}", se.Contract.ToString());
                KeyedByTypeCollection<IEndpointBehavior> behaviors = se.Behaviors;
                foreach (IEndpointBehavior behavior in behaviors)
                {
                    Console.WriteLine("Behavior: {0}", behavior.ToString());
                }
            }
            // </Snippet5>

            // <Snippet6>
            string name = svcDesc.Name;
            Console.WriteLine("Service Description name: {0}", name);
            // </Snippet6>

            // <Snippet7>
            string namespc = svcDesc.Namespace;
            Console.WriteLine("Service Description namespace: {0}", namespc);
            // </Snippet7>

            // <Snippet8>
            Type serviceType = svcDesc.ServiceType;
            Console.WriteLine("Service Type: {0}", serviceType.ToString());
            // </Snippet8>

            // <Snippet9>
            // Instantiate a service description specifying a service object
            // Note: Endpoints collection and other properties will be null since 
            // we have not specified them
            CalculatorService svcObj = new CalculatorService();
            ServiceDescription sd3 = ServiceDescription.GetService(svcObj);
            String serviceName = sd3.Name;
            Console.WriteLine("Service name: {0}", serviceName);
            // </Snippet9>

            // </Snippet0>

        }
    }
}
