        public void snippet22(CalculatorClient cc)
        {
            X509CertificateRecipientClientCredential rcc = cc.ClientCredentials.ServiceCertificate;
            rcc.SetDefaultCertificate(StoreLocation.CurrentUser,
                                     StoreName.TrustedPeople,
                                     X509FindType.FindBySubjectName,
                                     "FabrikamSTS");
        }