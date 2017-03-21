        public void snippet20(CalculatorClient client)
        {
            X509CertificateRecipientClientCredential rcc = client.ClientCredentials.ServiceCertificate;
            rcc.SetScopedCertificate(StoreLocation.CurrentUser,
                                     StoreName.TrustedPeople,
                                     X509FindType.FindBySubjectName,
                                     "FabrikamSTS",
                                     new Uri("http://fabrikam.com/sts"));
        }