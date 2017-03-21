            serviceHost.Credentials.ClientCertificate.Authentication. _
                CertificateValidationMode = X509CertificateValidationMode.Custom
            serviceHost.Credentials.ClientCertificate.Authentication. _
               CustomCertificateValidator = New MyX509CertificateValidator("CN=Contoso.com")