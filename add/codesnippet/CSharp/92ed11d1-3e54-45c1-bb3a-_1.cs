            // Create a service host.
            EndpointAddress ea = new EndpointAddress("http://localhost/Calculator");
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Transport);
            b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Digest;
            
            // Create a client. The code is not shown here. See the WCF samples
            // for an example of the CalculatorClient code.

            CalculatorClient cc = new CalculatorClient(b, ea);
            // Get a reference to the Windows client credential object.
            HttpDigestClientCredential digestCred = cc.ClientCredentials.HttpDigest;
            Console.WriteLine("AllowedImpersonationLevel: {0}",
                digestCred.AllowedImpersonationLevel);
            Console.WriteLine("Domain: {0}", digestCred.ClientCredential.Domain);

            Console.ReadLine();
            // Change the AllowedImpersonationLevel.
            digestCred.AllowedImpersonationLevel = 
                System.Security.Principal.TokenImpersonationLevel.Impersonation;

            Console.WriteLine("Changed AllowedImpersonationLevel: {0}",
                digestCred.AllowedImpersonationLevel);
            Console.ReadLine();
            // Open the calculator and use it.
            //cc.Open();
            //Console.WriteLine(cc.Add(11, 11));

            //// Close the client.
            //cc.Close();