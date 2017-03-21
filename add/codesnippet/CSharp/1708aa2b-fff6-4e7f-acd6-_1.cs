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

            switch (myAuthProperties.CertificateValidationMode)
            {
                case X509CertificateValidationMode.ChainTrust:
                    Console.WriteLine("ChainTrust");
                    break;
                case X509CertificateValidationMode.Custom:
                    Console.WriteLine("Custom");
                    break;
                case X509CertificateValidationMode.None:
                    Console.WriteLine("ChainTrust");
                    break;
                case X509CertificateValidationMode.PeerOrChainTrust:
                    Console.WriteLine("PeerOrChainTrust");
                    break;
                case X509CertificateValidationMode.PeerTrust:
                    Console.WriteLine("PeerTrust");
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }