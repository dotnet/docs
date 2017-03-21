                serviceHost.Credentials.ClientCertificate.Authentication.CertificateValidationMode = 
                    X509CertificateValidationMode.Custom;
                serviceHost.Credentials.ClientCertificate.Authentication.CustomCertificateValidator = 
                    new MyX509CertificateValidator("CN=Contoso.com");