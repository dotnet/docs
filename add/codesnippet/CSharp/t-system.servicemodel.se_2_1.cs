	    NetTcpBinding b = new NetTcpBinding();
	    b.Security.Mode = SecurityMode.Message;
	    Type c = typeof(ICalculator);
	    Uri a = new Uri("net.tcp://MyMachineName/tcpBase");
	    Uri[] baseAddresses = new Uri[] { a };
	    ServiceHost sh = new ServiceHost(typeof(MyService), baseAddresses);
	    sh.AddServiceEndpoint(c, b, "Aloha");
	    sh.Credentials.ServiceCertificate.SetCertificate(
		    StoreLocation.LocalMachine,
		    StoreName.My,
		    X509FindType.FindByThumbprint,
		    "af1f50b20cd413ed9cd00c315bbb6dc1c08da5e6");
	    sh.Open();