            // Get MSMQ queue name from appsettings in configuration.
            string queueName = @".\private$\Orders";

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            // Create a ServiceHost for the CalculatorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService)))
            {
                
                MsmqIntegrationBindingElement msmqBindingElement = new MsmqIntegrationBindingElement();

                String strScheme = msmqBindingElement.Scheme;
                Console.WriteLine("Scheme = " + strScheme);

                Type[] types = msmqBindingElement.TargetSerializationTypes;
                
                CustomBinding binding = new CustomBinding(msmqBindingElement);


                serviceHost.AddServiceEndpoint(typeof(IOrderProcessor), binding, @"msmq.formatname:DIRECT=OS:.\private$\Orders");

                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();
            }