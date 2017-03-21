        ' Create a service host.
        Dim httpUri As New Uri("http://localhost/Calculator")
        Dim sh As New ServiceHost(GetType(Calculator), httpUri)

        ' Create a binding that uses a certificate.
        Dim b As New WSHttpBinding(SecurityMode.Message)
        b.Security.Message.ClientCredentialType = _
        MessageCredentialType.Certificate

        ' Get a reference to the authentication object.
        Dim myAuthProperties As X509ClientCertificateAuthentication = _
        sh.Credentials.ClientCertificate.Authentication()

        Select Case myAuthProperties.CertificateValidationMode
            Case X509CertificateValidationMode.ChainTrust
                Console.WriteLine("ChainTrust")
            Case X509CertificateValidationMode.Custom
                Console.WriteLine("Custom")
            Case X509CertificateValidationMode.None
                Console.WriteLine("ChainTrust")
            Case X509CertificateValidationMode.PeerOrChainTrust
                Console.WriteLine("PeerOrChainTrust")
            Case X509CertificateValidationMode.PeerTrust
                Console.WriteLine("PeerTrust")
            Case Else
                Console.WriteLine("Default")
        End Select