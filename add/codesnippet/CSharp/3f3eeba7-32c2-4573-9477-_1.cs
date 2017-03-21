        public void snippet24(CalculatorClient cc)
        {
            X509CertificateRecipientClientCredential rcc = cc.ClientCredentials.ServiceCertificate;
            X509Certificate2 cert = rcc.DefaultCertificate;
        }