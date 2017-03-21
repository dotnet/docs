				Dim binding As New NetTcpBinding()
				' Specify the mode, then the credential type.
				binding.Security.Mode = SecurityMode.Message
				binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName
				binding.Security.Message.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Basic256