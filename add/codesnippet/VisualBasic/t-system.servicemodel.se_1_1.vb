            ' Create a service host.
            Dim ea As New EndpointAddress("http://localhost/Calculator")
            Dim b As New WSHttpBinding(SecurityMode.Message)
            b.Security.Message.ClientCredentialType = _
            MessageCredentialType.Windows

            ' Create a client. The code is not shown here. See the WCF samples
            ' for an example of the CalculatorClient code.
            Dim cc As New CalculatorClient(b, ea)
            ' Get a reference to the Windows client credential object.
            Dim winCred As WindowsClientCredential = cc.ClientCredentials.Windows
            Console.WriteLine("AllowedImpersonationLevel: {0}", _
                             winCred.AllowedImpersonationLevel)
            Console.WriteLine("AllowNtlm: {0}", winCred.AllowNtlm)
            Console.WriteLine("Domain: {0}", winCred.ClientCredential.Domain)

            Console.ReadLine()
            ' Change the AllowedImpersonationLevel.
            winCred.AllowedImpersonationLevel = _
            System.Security.Principal.TokenImpersonationLevel.Impersonation

            Console.WriteLine("Changed AllowedImpersonationLevel: {0}", _
            winCred.AllowedImpersonationLevel)
            Console.ReadLine()
            ' Open the calculator and use it.
            ' cc.Open()
            ' Console.WriteLine(cc.Add(11, 11))
            ' Close the client.
            ' cc.Close()