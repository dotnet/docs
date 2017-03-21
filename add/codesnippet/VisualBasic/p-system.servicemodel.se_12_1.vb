			Dim myBinding As New WSHttpBinding()
			myBinding.Security.Mode = SecurityMode.Message
			myBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName


			Dim client As New CalculatorClient("default")

			client.ClientCredentials.UserName.Password = ReturnPassword()

			client.ClientCredentials.UserName.UserName = ReturnUsername()