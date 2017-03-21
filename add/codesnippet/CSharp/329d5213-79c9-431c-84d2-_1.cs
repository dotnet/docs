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
            