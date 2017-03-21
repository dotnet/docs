            Uri baseAddress = new Uri("http://localhost:8000");
            WebServiceHost host = new WebServiceHost(typeof(Service), baseAddress);
            try
            {
                host.Open();
            
                // The endpoint name passed to the constructor must match an endpoint element
                // in the application configuration file
                WebChannelFactory<IService> cf = new WebChannelFactory<IService>("MyEndpoint");
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