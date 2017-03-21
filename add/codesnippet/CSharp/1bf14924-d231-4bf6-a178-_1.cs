        public void snippet23(CalculatorClient cc)
        {
            X509CertificateRecipientClientCredential rcc = cc.ClientCredentials.ServiceCertificate;
            rcc.SetDefaultCertificate("http://fabrikam.com/sts",
                                     StoreLocation.CurrentUser,
                                     StoreName.TrustedPeople);
        }