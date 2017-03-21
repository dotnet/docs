
         // Check whether the Alerter service is started.

         ServiceController sc  = new ServiceController();
         sc.ServiceName = "Alerter";
         Console.WriteLine("The Alerter service status is currently set to {0}", 
                            sc.Status.ToString());

         if (sc.Status == ServiceControllerStatus.Stopped)
         {
            // Start the service if the current status is stopped.

            Console.WriteLine("Starting the Alerter service...");
            try 
            {
               // Start the service, and wait until its status is "Running".
               sc.Start();
               sc.WaitForStatus(ServiceControllerStatus.Running);
            
               // Display the current service status.
               Console.WriteLine("The Alerter service status is now set to {0}.", 
                                  sc.Status.ToString());
            }
            catch (InvalidOperationException)
            {
               Console.WriteLine("Could not start the Alerter service.");
            }
         }