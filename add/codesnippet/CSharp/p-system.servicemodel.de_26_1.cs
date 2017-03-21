            X509CertificateRecipientClientCredential rcc =
                client.ClientCredentials.ServiceCertificate;

            X509Certificate2 cert = new X509Certificate2();
            rcc.ScopedCertificates.Add(new Uri("http://fabrikam.com/sts"), cert);