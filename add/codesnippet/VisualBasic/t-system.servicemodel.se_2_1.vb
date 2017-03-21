		Dim b As New NetTcpBinding()
		b.Security.Mode = SecurityMode.Message
		Dim c As Type = GetType(ICalculator)
		Dim a As New Uri("net.tcp://MyMachineName/tcpBase")
		Dim baseAddresses() As Uri = { a }
		Dim sh As New ServiceHost(GetType(MyService), baseAddresses)
		sh.AddServiceEndpoint(c, b, "Aloha")
		sh.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint, "af1f50b20cd413ed9cd00c315bbb6dc1c08da5e6")
		sh.Open()