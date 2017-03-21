			Dim b As New NetTcpBinding()
			b.Security.Mode = SecurityMode.Message
			Dim c As Type = GetType(ICalculator)
			Dim a As New Uri("net.tcp://MyMachineName/tcpBase")
			Dim baseAddresses() As Uri = { a }
			Dim sh As New ServiceHost(GetType(MyService), baseAddresses)
			sh.AddServiceEndpoint(c, b, "Aloha")
			sh.Credentials.ServiceCertificate.SetCertificate("CN=Administrator,CN=Users,DC=johndoe,DC=nttest,DC=microsoft,DC=com")
			sh.Open()
