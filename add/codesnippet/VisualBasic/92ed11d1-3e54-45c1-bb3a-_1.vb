            ' Create a service host.
            Dim ea As New EndpointAddress("http://localhost/Calculator")
            Dim b As New WSHttpBinding(SecurityMode.Transport)
            b.Security.Transport.ClientCredentialType = _
            HttpClientCredentialType.Digest

            ' Create a client. The code is not shown here. See the WCF samples
            ' for an example of the CalculatorClient code.
            Dim cc As New CalculatorClient(b, ea)
            ' Get a reference to the Windows client credential object.
            Dim digestCred As HttpDigestClientCredential = cc.ClientCredentials.HttpDigest
            Console.WriteLine("AllowedImpersonationLevel: {0}", _
                             digestCred.AllowedImpersonationLevel)
            Console.WriteLine("Domain: {0}", digestCred.ClientCredential.Domain)

            Console.ReadLine()
            ' Change the AllowedImpersonationLevel.
            digestCred.AllowedImpersonationLevel = _
            System.Security.Principal.TokenImpersonationLevel.Impersonation

            Console.WriteLine("Changed AllowedImpersonationLevel: {0}", _
            digestCred.AllowedImpersonationLevel)
            Console.ReadLine()
            ' Open the calculator and use it.
            ' cc.Open()
            ' Console.WriteLine(cc.Add(11, 11))
            ' Close the client.
            ' cc.Close()