                NetTcpBinding b = new NetTcpBinding();
                b.Security.Mode = SecurityMode.Transport;
                b.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
                EndpointAddress a = new EndpointAddress("net.tcp://contoso.com/TcpAddress");
                ChannelFactory<ICalculator> cf = new ChannelFactory<ICalculator>(b, a);
                cf.Credentials.ClientCertificate.SetCertificate(
                    StoreLocation.LocalMachine,
                    StoreName.My,
                    X509FindType.FindByThumbprint,
                    "0000000000000000000000000000000000000000");