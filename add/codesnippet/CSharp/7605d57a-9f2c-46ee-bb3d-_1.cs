            NetTcpBinding b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.Message;
            Type c = typeof(ICalculator);
            Uri a = new Uri("net.tcp://MyMachineName/tcpBase");
            Uri[] baseAddresses = new Uri[] { a };
            ServiceHost sh = new ServiceHost(typeof(MyService), baseAddresses);
            sh.AddServiceEndpoint(c, b, "Aloha");
            sh.Credentials.ServiceCertificate.SetCertificate(
                "CN=Administrator,CN=Users,DC=johndoe,DC=nttest,DC=microsoft,DC=com",
                StoreLocation.LocalMachine,
                StoreName.My);
            sh.Open();