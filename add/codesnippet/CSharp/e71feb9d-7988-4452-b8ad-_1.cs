            // Create a service host.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

            // Create a binding that uses a username/password credential.
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            b.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

            // Add an endpoint.
            sh.AddServiceEndpoint(typeof(ICalculator), b, "UserNamePasswordCalculator");

            // Get a reference to the UserNamePasswordServiceCredential object.
            UserNamePasswordServiceCredential unpCredential = 
                sh.Credentials.UserNameAuthentication;
            // Print out values.
            Console.WriteLine("IncludeWindowsGroup: {0}", 
                unpCredential.IncludeWindowsGroups);
            Console.WriteLine("UserNamePasswordValidationMode: {0}",
                unpCredential.UserNamePasswordValidationMode);
            Console.WriteLine("CachedLogonTokenLifetime.Minutes: {0}",
                unpCredential.CachedLogonTokenLifetime.Minutes );
            Console.WriteLine("CacheLogonTokens: {0}",
                unpCredential.CacheLogonTokens );
            Console.WriteLine("MaxCachedLogonTokens: {0}",
                unpCredential.MaxCachedLogonTokens );
                        
            Console.ReadLine();