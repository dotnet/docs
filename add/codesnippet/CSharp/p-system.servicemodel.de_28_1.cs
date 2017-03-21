            // Create the client with the binding and EndpointAddress.
            CalculatorClient calcClient = new CalculatorClient(b, ea);

            // Set the client credential value to a valid certificate.
            calcClient.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser, 
                StoreName.TrustedPeople, 
                X509FindType.FindBySubjectName, 
                "client.com");