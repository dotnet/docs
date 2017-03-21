            // Get the current Timeout.
            System.TimeSpan currentTimeout = 
                formsAuthentication.Timeout;
          
            // Set the Timeout.
            formsAuthentication.Timeout = 
                System.TimeSpan.FromMinutes(10);
