                ServiceHost myServiceHost = new ServiceHost(typeof(CalculatorService));
                // Create a binding to use.
                WSHttpBinding binding = new WSHttpBinding();
                binding.Security.Mode = SecurityMode.Message;
                binding.Security.Message.ClientCredentialType =
                    MessageCredentialType.Certificate;

                // Set the client certificate.
                myServiceHost.Credentials.ClientCertificate.SetCertificate(
                    StoreLocation.CurrentUser,
                    StoreName.My,
                    X509FindType.FindBySubjectName,
                    "client.com");