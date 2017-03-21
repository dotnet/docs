            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            ServiceEndpoint endpoint = serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            endpoint.Behaviors.Add(new MyEndpointBehavior());

            Console.WriteLine("List all behaviors:");
            foreach (IEndpointBehavior behavior in endpoint.Behaviors)
            {
                Console.WriteLine("Behavior: {0}", behavior.ToString());
            }