            string queueName = ".\\private$\\ServiceModelSamples";

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            string baseAddress = "http://localhost:8000/queuedCalculator";
            string endpointAddress = "net.msmq://localhost/private/ServiceModelSamples";

            // Create a ServiceHost for the CalculatorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), new Uri(baseAddress)))
            {
                NetMsmqBinding binding = new NetMsmqBinding();
                serviceHost.AddServiceEndpoint(typeof(IQueueCalculator), binding, endpointAddress);

                // Add a MEX endpoint.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
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