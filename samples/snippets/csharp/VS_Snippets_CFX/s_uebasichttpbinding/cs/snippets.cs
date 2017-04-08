using System;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace UE.ServiceModel.Samples
{
    class Snippets
    {
        public static void Snippet3()
        {
            // <Snippet3>
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Message);
            binding.Name = "binding1";
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            BasicHttpSecurityMode sMode = binding.Security.Mode;

            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service/calc");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, address);

            // Open the ServiceHostBase to create listeners and start listening for messages.
            serviceHost.Open();

            // The service can now be accessed.
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();
	    
            // Close the ServiceHostBase to shutdown the service.
            serviceHost.Close();
            
            // </Snippet3>
        }
        public static void Snippet4()
        {           
            // <Snippet4>
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "binding1";
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.Security.Mode = BasicHttpSecurityMode.None;
            
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service/calc");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, address);
    
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
            // </Snippet4>
        }

        public static void Snippet5()
        {
            // <Snippet5>
            BasicHttpBinding binding = new BasicHttpBinding("myBinding");
            binding.Name = "binding1";
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.Security.Mode = BasicHttpSecurityMode.Message;

            // <Snippet6>
            BasicHttpSecurity security = binding.Security;
            BasicHttpMessageSecurity msgSecurity = security.Message;
            // </Snippet6>

            // <Snippet7>
            SecurityAlgorithmSuite sas = msgSecurity.AlgorithmSuite;
            BasicHttpMessageCredentialType credType = msgSecurity.ClientCredentialType;
            // </Snippet7>

            Console.WriteLine("The algorithm suite used is {0}", sas.ToString());
            Console.WriteLine("The client credential type used is {0}", credType.ToString());
            // </Snippet5>
        }

        public static void Snippet8()
        {
            // <Snippet8>
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "binding1";
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.Security.Mode = BasicHttpSecurityMode.Message;
            
            // <Snippet9>
            BasicHttpSecurity security = binding.Security;
            BasicHttpMessageSecurity msgSecurity = security.Message;
            // </Snippet9>

            // <Snippet10>
            BasicHttpSecurityMode secMode = security.Mode;
            // </Snippet10>

            // <Snippet11>
            HttpTransportSecurity transSec = security.Transport;
            // </Snippet11>

            Console.WriteLine("The message-level security setting is {0}", secMode.ToString());
            Console.WriteLine("The transport-level security setting is {0}", transSec.ToString());
            // </Snippet8>
        }
    }
}
