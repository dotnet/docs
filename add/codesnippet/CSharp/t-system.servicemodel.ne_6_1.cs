	    NetTcpBinding binding = new NetTcpBinding();
	    binding.Security.Mode = SecurityMode.Transport;
	    binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;