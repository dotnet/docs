            Dim b As NetTcpBinding = New NetTcpBinding()
            b.Security.Mode = SecurityMode.Transport
            b.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate
            Dim a As New EndpointAddress("net.tcp://contoso.com/TcpAddress")
            Dim cf As ChannelFactory(Of ICalculator) = New ChannelFactory(Of ICalculator)(b, a)
            cf.Credentials.ClientCertificate.SetCertificate( _
                StoreLocation.LocalMachine, _
                StoreName.My, _
                X509FindType.FindByThumbprint, _
                "0000000000000000000000000000000000000000")