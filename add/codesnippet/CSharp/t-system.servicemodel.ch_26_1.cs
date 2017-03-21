            string queueName = @".\private$\ServiceModelSamples";

            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                BinaryMessageEncodingBindingElement encodingBindingElement = new BinaryMessageEncodingBindingElement();
                MsmqTransportBindingElement transportBindingElement = new MsmqTransportBindingElement();
                CustomBinding binding = new CustomBinding(encodingBindingElement, transportBindingElement);
                
                serviceHost.AddServiceEndpoint(
                    typeof(IQueueCalculator),
                    binding,
                    "net.msmq://localhost/private/ServiceModelSamples");

                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHost to shutdown the service.
                serviceHost.Close();