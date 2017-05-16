using System;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Description;
using UE.ServiceModel.Samples;

namespace UE.ServiceModel.Samples
{
    class Snippets
    {
        public void snippet3()
        {
            // <Snippet4>
            // <Snippet3>
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "binding1";
            // </Snippet3>
            binding.Namespace = "http:\\My.ServiceModel.Samples";
            // </Snippet4>

            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service/calc");

            // Create a ServiceHost for the ICalculator type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(ICalculator), baseAddress))
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
        }
        public void snippet5()
        {
            // <Snippet5>
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "binding1";
            binding.Namespace = "http:\\My.ServiceModel.Samples";
            BindingElementCollection elements = binding.CreateBindingElements();
            // </Snippet5> 

            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service/calc");

            // Create a ServiceHost for the ICalculator type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(ICalculator), baseAddress))
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
        }
        public void snippet6()
        {
            // <Snippet6>
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "binding1";
            binding.Namespace = "http:\\My.ServiceModel.Samples";
            binding.CloseTimeout = new TimeSpan(0, 5, 0);
            // </Snippet6>

            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service/calc");

            // Create a ServiceHost for the ICalculator type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(ICalculator), baseAddress))
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
        }

        public void snippet7()
        {
            // <Snippet7>
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "binding1";
            binding.Namespace = "http:\\My.ServiceModel.Samples";
            binding.OpenTimeout = new TimeSpan(0, 0, 30);
            // </Snippet7>

            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service/calc");

            // Create a ServiceHost for the ICalculator type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(ICalculator), baseAddress))
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
        }

        public void snippet8()
        {
            // <Snippet8>
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "binding1";
            binding.Namespace = "http:\\My.ServiceModel.Samples";
            binding.ReceiveTimeout = new TimeSpan(0, 5, 0);
            // </Snippet8>

            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service/calc");

            // Create a ServiceHost for the ICalculator type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(ICalculator), baseAddress))
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
        }

        public void snippet9()
        {
            // <Snippet9>
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "binding1";
            binding.Namespace = "http:\\My.ServiceModel.Samples";
            binding.SendTimeout = new TimeSpan(0, 5, 0);
            // </Snippet9>

            // <Snippet10>
            string scheme = binding.Scheme;
            Console.WriteLine("Binding is using the {0} scheme", scheme);
            // </Snippet10>


            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service/calc");

            // Create a ServiceHost for the ICalculator type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(ICalculator), baseAddress))
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
        }

    }

}
