            Uri baseAddress = new Uri("http://localhost:8000");
            WebServiceHost host = new WebServiceHost(typeof(Service), baseAddress);
            try
            {
                host.Open();

                WebChannelFactory<IService> cf = new WebChannelFactory<IService>(baseAddress);
                IService channel = cf.CreateChannel();
                string s;

                Console.WriteLine("Calling EchoWithGet via HTTP GET: ");
                s = channel.EchoWithGet("Hello, world");
                Console.WriteLine("   Output: {0}", s);

                Console.WriteLine("");

                Console.WriteLine("Calling EchoWithPost via HTTP POST: ");
                s = channel.EchoWithPost("Hello, world");
                Console.WriteLine("   Output: {0}", s);

                Console.WriteLine("");
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
            }