            Uri baseAddress = new Uri("http://localhost:8000");
            WebServiceHost host = new WebServiceHost(typeof(Service), baseAddress);
            try
            {
                host.Open();

                WebHttpBinding binding = new WebHttpBinding();
                ContractDescription desc = ContractDescription.GetContract(typeof(IService));
                EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8000");
                ServiceEndpoint endpoint = new ServiceEndpoint(desc, binding, endpointAddress);

                WebChannelFactory<IService> cf = new WebChannelFactory<IService>(endpoint);
                IService channel = cf.CreateChannel();
                string s;

                Console.WriteLine("Calling EchoWithGet via HTTP GET: ");
                s = channel.EchoWithGet("Hello, world");
                Console.WriteLine("   Output: {0}", s);
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
            }