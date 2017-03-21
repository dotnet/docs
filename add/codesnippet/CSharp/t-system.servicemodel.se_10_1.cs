        // Host the service within this EXE console application.
        public static void Main()
        {
            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                serviceHost.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
                serviceHost.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new MyUserNamePasswordValidator();

                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("The service is running in the following account: {0}", WindowsIdentity.GetCurrent().Name);
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();
            }
        }