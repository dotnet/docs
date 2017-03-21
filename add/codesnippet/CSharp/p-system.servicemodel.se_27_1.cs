                // Create a service host.
                Uri httpUri = new Uri("http://localhost/Calculator");
                ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

                // Create a binding that uses a WindowsServiceCredential.
                WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
                b.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

                // Add an endpoint.
                sh.AddServiceEndpoint(typeof(ICalculator), b, "WindowsCalculator");

                // Get a reference to the WindowsServiceCredential object.
                WindowsServiceCredential winCredential =
                    sh.Credentials.WindowsAuthentication;
                // Print out values.
                Console.WriteLine("IncludeWindowsGroup: {0}",
                    winCredential.IncludeWindowsGroups);
                Console.WriteLine("UserNamePasswordValidationMode: {0}",
                    winCredential.AllowAnonymousLogons);

                Console.ReadLine();