            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                // Create a custom binding that contains two binding elements.
                ReliableSessionBindingElement reliableSession = new ReliableSessionBindingElement();
                reliableSession.Ordered = true;

                HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();
                httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous;
                httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;

                CustomBinding binding = new CustomBinding(reliableSession, httpTransport);

                // Add an endpoint using that binding.
                serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, "");

                // Add a MEX endpoint.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.HttpGetUrl = new Uri("http://localhost:8001/servicemodelsamples");
                serviceHost.Description.Behaviors.Add(smb);
              
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