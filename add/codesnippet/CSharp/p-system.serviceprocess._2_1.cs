         ServiceController sc = new ServiceController("Messenger");
         ServiceController[] scServices= sc.ServicesDependedOn;

         // Display the services that the Messenger service is dependent on.
         if (scServices.Length == 0)
         {
            Console.WriteLine("{0} service is not dependent on any other services.", 
                               sc.ServiceName);
         }
         else 
         {
            Console.WriteLine("{0} service is dependent on the following:",
                               sc.ServiceName);

            foreach (ServiceController scTemp in scServices)
            {
               Console.WriteLine(" {0}", scTemp.DisplayName);
            }
         }