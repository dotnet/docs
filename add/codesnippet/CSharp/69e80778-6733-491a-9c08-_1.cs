            // Create a WSHttpBinding and set its security properties. The
            // security mode is Message, and the client is authenticated with 
            // a certificate.
            EndpointAddress ea = new EndpointAddress("http://contoso.com/");
            WSHttpBinding b = new WSHttpBinding();
            b.Security.Mode = SecurityMode.Message;
            b.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate;

            // Create the client with the binding and EndpointAddress.
            CalculatorClient cc = new CalculatorClient(b, ea);

            // Set the client credential value to a valid certificate.
            cc.ClientCredentials.ClientCertificate.SetCertificate(
                "CN=MyName, OU=MyOrgUnit, C=US",
                StoreLocation.CurrentUser, 
                StoreName.TrustedPeople);