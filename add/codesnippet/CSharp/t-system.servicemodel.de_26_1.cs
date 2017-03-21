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

            // Use Default constructor
            ServiceDescription sd = new ServiceDescription();

            // Create ServiceDescription from a collection of service endpoints
            List<ServiceEndpoint> endpoints = new List<ServiceEndpoint>();
            ContractDescription conDescr = new ContractDescription("ICalculator");
            EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8001/Basic");
            ServiceEndpoint ep = new ServiceEndpoint(conDescr, new BasicHttpBinding(), endpointAddress);
            endpoints.Add(ep);
            ServiceDescription sd2 = new ServiceDescription(endpoints);

            //// <Snippet3>
            //// Iterate through the list of behaviors in the ServiceDescription
            ServiceDescription svcDesc = serviceHost.Description;
            KeyedByTypeCollection<IServiceBehavior> sbCol = svcDesc.Behaviors;
            foreach (IServiceBehavior behavior in sbCol)
            {
                Console.WriteLine("Behavior: {0}", behavior.ToString());
            }

            // svcDesc is a ServiceDescription.
            svcDesc = serviceHost.Description;
            string configName = svcDesc.ConfigurationName;
            Console.WriteLine("Configuration name: {0}", configName);

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

            string name = svcDesc.Name;
            Console.WriteLine("Service Description name: {0}", name);

            string namespc = svcDesc.Namespace;
            Console.WriteLine("Service Description namespace: {0}", namespc);

            Type serviceType = svcDesc.ServiceType;
            Console.WriteLine("Service Type: {0}", serviceType.ToString());

            // Instantiate a service description specifying a service object
            // Note: Endpoints collection and other properties will be null since 
            // we have not specified them
            CalculatorService svcObj = new CalculatorService();
            ServiceDescription sd3 = ServiceDescription.GetService(svcObj);
            String serviceName = sd3.Name;
            Console.WriteLine("Service name: {0}", serviceName);
