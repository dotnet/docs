        public static void Main()
        {
            // Get base address from appsettings in configuration.
            Uri baseAddress = new Uri(ConfigurationManager.
                AppSettings["baseAddress"]);

            // Create a ServiceHost for the CalculatorService type 
            // and provide the base address.
            using (ServiceHost serviceHost = new 
                ServiceHost(typeof(CalculatorService), baseAddress))
            {
                // Create a new auditing behavior and set the log location.
                ServiceSecurityAuditBehavior newAudit = 
                    new ServiceSecurityAuditBehavior();
                newAudit.AuditLogLocation = 
                    AuditLogLocation.Application;
                newAudit.MessageAuthenticationAuditLevel = 
                    AuditLevel.SuccessOrFailure;
                newAudit.ServiceAuthorizationAuditLevel = 
                    AuditLevel.SuccessOrFailure;
                newAudit.SuppressAuditFailure = false;
                // Remove the old behavior and add the new.
                serviceHost.Description.
                    Behaviors.Remove<ServiceSecurityAuditBehavior>();
                serviceHost.Description.Behaviors.Add(newAudit);
                // Open the ServiceHostBase to create listeners 
                // and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                serviceHost.Close();
            }
        }