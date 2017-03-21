            // Create a service host.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

            // Get a reference to the authentication object.
            X509ClientCertificateAuthentication myAuthProperties =
                sh.Credentials.ClientCertificate.Authentication;
                        
            // Configure custom certificate validation.
            myAuthProperties.CertificateValidationMode =
                X509CertificateValidationMode.Custom;
            // Specify a custom certificate validator (not shown here) that inherits 
            // from the X509CertificateValidator class.
            // creds.ClientCertificate.Authentication.CustomCertificateValidator =
            //    new MyCertificateValidator();