            // Create a service host.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

            // Create a binding that uses a certificate.
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            b.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate; 

            // Get a reference to the authentication object.
            X509ClientCertificateAuthentication myAuthProperties =
                sh.Credentials.ClientCertificate.Authentication;
            // Configure peer trust.
            myAuthProperties.CertificateValidationMode =
                X509CertificateValidationMode.PeerTrust;
            myAuthProperties.TrustedStoreLocation =
                StoreLocation.LocalMachine;