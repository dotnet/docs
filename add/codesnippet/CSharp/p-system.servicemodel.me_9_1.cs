                WSHttpBinding binding = new WSHttpBinding();
                binding.Security.Mode = SecurityMode.Message;
                binding.Security.Message.ClientCredentialType =
                    MessageCredentialType.UserName;
                binding.Security.Message.NegotiateServiceCredential = false;

                CalculatorClient CalculatorClient = new CalculatorClient("myBinding");
                CalculatorClient.ClientCredentials.ServiceCertificate.
                    SetDefaultCertificate("Al", StoreLocation.CurrentUser, StoreName.My);