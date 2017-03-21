		' Set the IssuerBinding to a WSHttpBinding loaded from config
		b.Security.Message.IssuerBinding = New WSHttpBinding("Issuer")