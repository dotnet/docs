		' The security mode is set to Message.
		Dim binding As New WSHttpBinding(SecurityMode.Message)
		binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows
		Return binding