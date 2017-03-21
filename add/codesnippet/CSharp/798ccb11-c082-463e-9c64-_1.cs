            // Create a service host.
            EndpointAddress ea = new EndpointAddress("http://localhost/Calculator");
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            b.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            
            // Create a client. The code is not shown here. See the WCF samples
            // for an example of the CalculatorClient code.

            CalculatorClient cc = new CalculatorClient(b, ea);
            // Get a reference to the Windows client credential object.
            WindowsClientCredential winCred= cc.ClientCredentials.Windows;
            Console.WriteLine("AllowedImpersonationLevel: {0}", 
                winCred.AllowedImpersonationLevel);
            Console.WriteLine("AllowNtlm: {0}", winCred.AllowNtlm);
            Console.WriteLine("Domain: {0}", winCred.ClientCredential.Domain);

            Console.ReadLine();
            // Change the AllowedImpersonationLevel.
            winCred.AllowedImpersonationLevel = 
                System.Security.Principal.TokenImpersonationLevel.Impersonation;

            Console.WriteLine("Changed AllowedImpersonationLevel: {0}", 
                winCred.AllowedImpersonationLevel);
            Console.ReadLine();
            // Open the calculator and use it.
            //cc.Open();
            //Console.WriteLine(cc.Add(11, 11));

            //// Close the client.
            //cc.Close();