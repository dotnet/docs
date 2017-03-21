        private void Run()
        {
            WSHttpBinding b = new WSHttpBinding();
            b.Name = "HttpOrderedReliableSessionBinding";

            // Get a reference to the OptionalreliableSession object of the 
            // binding and set its properties to new values.
            OptionalReliableSession myReliableSession = b.ReliableSession;
            myReliableSession.Enabled = true; // The default is false.
            myReliableSession.Ordered = false; // The default is true. 
            myReliableSession.InactivityTimeout = 
                new TimeSpan(0, 15, 0); // The default is 10 minutes.
            // Create a URI for the service's base address.
            Uri baseAddress = new Uri("http://localhost:8008/Calculator");

            // Create a service host.
            ServiceHost sh = new ServiceHost(typeof(Calculator), baseAddress);

            // Optional: Print out the binding information. 
            PrintBindingInfo(b);
            // Create a URI for an endpoint, then add a service endpoint using the
            // binding with the latered OptionalReliableSession settings.
            sh.AddServiceEndpoint(typeof(ICalculator), b, "ReliableCalculator");
            sh.Open();

            Console.WriteLine("Listening...");
            Console.ReadLine();
            sh.Close();

        }

        private void PrintBindingInfo(WSHttpBinding b)
        {
            Console.WriteLine(b.Name);
            Console.WriteLine("Enabled: {0}", b.ReliableSession.Enabled);
            Console.WriteLine("Ordered: {0}", b.ReliableSession.Ordered);
            Console.WriteLine("Inactivity in Minutes: {0}",
                b.ReliableSession.InactivityTimeout.TotalMinutes);
        }