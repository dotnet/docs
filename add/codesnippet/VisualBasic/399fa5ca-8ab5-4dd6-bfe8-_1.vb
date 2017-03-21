	Friend Class MyServiceCredentialsSecurityTokenManager
		Inherits ServiceCredentialsSecurityTokenManager
		Private credentials As MyServiceCredentials

		Public Sub New(ByVal credentials As MyServiceCredentials)
			MyBase.New(credentials)
			Me.credentials = credentials
		End Sub

		Public Overrides Function CreateSecurityTokenProvider(ByVal requirement As SecurityTokenRequirement) As SecurityTokenProvider
			Dim result As SecurityTokenProvider = Nothing
			If requirement.TokenType = SecurityTokenTypes.X509Certificate Then
				Dim direction As MessageDirection = requirement. GetProperty(Of MessageDirection)(ServiceModelSecurityTokenRequirement. MessageDirectionProperty)
				If direction = MessageDirection.Input Then
					If requirement.KeyUsage = SecurityKeyUsage.Exchange Then
						result = New X509SecurityTokenProvider(credentials.ServiceEncryptingCertificate)
					Else
						result = New X509SecurityTokenProvider(credentials.ClientSigningCertificate)
					End If
				Else
					If requirement.KeyUsage = SecurityKeyUsage.Signature Then
						result = New X509SecurityTokenProvider(credentials.ServiceSigningCertificate)
					Else
						result = New X509SecurityTokenProvider(credentials.ClientEncryptingCertificate)
					End If
				End If
			Else
				result = MyBase.CreateSecurityTokenProvider(requirement)
			End If
			Return result
		End Function
	End Class