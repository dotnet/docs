		' securityMode is Message
		' reliableSessionEnabled is true
		Dim binding As New WSHttpBinding(SecurityMode.Message, True)
		binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows