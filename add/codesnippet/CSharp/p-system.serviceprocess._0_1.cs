
         // Toggle the Telnet service - 
         // If it is started (running, paused, etc), stop the service.
         // If it is stopped, start the service.
         ServiceController sc = new ServiceController("Telnet");
         Console.WriteLine("The Telnet service status is currently set to {0}", 
                           sc.Status.ToString());

         if  ((sc.Status.Equals(ServiceControllerStatus.Stopped)) ||
              (sc.Status.Equals(ServiceControllerStatus.StopPending)))
         {
            // Start the service if the current status is stopped.

            Console.WriteLine("Starting the Telnet service...");
            sc.Start();
         }  
         else
         {
            // Stop the service if its status is not set to "Stopped".

            Console.WriteLine("Stopping the Telnet service...");
            sc.Stop();
         }  

         // Refresh and display the current service status.
         sc.Refresh();
         Console.WriteLine("The Telnet service status is now set to {0}.", 
                            sc.Status.ToString());
         