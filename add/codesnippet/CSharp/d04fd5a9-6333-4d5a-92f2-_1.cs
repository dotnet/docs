        public void snippet21(CalculatorClient cc)
        {
            X509CertificateRecipientClientCredential rcc = cc.ClientCredentials.ServiceCertificate;
            X509ServiceCertificateAuthentication xauth = rcc.Authentication;
        }