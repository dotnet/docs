        public void snippet25(CalculatorClient cc)
        {
            X509CertificateRecipientClientCredential rcc = cc.ClientCredentials.ServiceCertificate;
            rcc.SetScopedCertificate("http://fabrikam.com/sts",
                                     StoreLocation.CurrentUser,
                                     StoreName.TrustedPeople,
                                     new Uri("http://fabrikam.com"));
        }