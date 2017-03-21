            // Create a service host.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

            // Create a binding that uses Windows security.
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            b.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

            // Get a reference to the authentication object.
            X509ClientCertificateAuthentication myAuthProperties =
                sh.Credentials.ClientCertificate.Authentication;
            // Configure IncludeWindowsGroups.
            myAuthProperties.IncludeWindowsGroups = true;