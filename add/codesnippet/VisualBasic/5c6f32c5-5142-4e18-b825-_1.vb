	Friend Class MyClientCredentialsSecurityTokenManager
		Inherits ClientCredentialsSecurityTokenManager
		Private credentials As MyClientCredentials

		Public Sub New(ByVal credentials As MyClientCredentials)
			MyBase.New(credentials)
			Me.credentials = credentials
		End Sub

		Public Overrides Function CreateSecurityTokenProvider(ByVal requirement As SecurityTokenRequirement) As SecurityTokenProvider
			Dim result As SecurityTokenProvider = Nothing
			If requirement.TokenType = SecurityTokenTypes.X509Certificate Then
				Dim direction As MessageDirection = requirement.GetProperty (Of MessageDirection)(ServiceModelSecurityTokenRequirement. MessageDirectionProperty)
				If direction = MessageDirection.Output Then
					If requirement.KeyUsage = SecurityKeyUsage.Signature Then
						result = New X509SecurityTokenProvider(Me.credentials.ClientSigningCertificate)
					Else
						result = New X509SecurityTokenProvider(Me.credentials. ServiceEncryptingCertificate)
					End If
				Else
					If requirement.KeyUsage = SecurityKeyUsage.Signature Then
						result = New X509SecurityTokenProvider(Me. credentials.ServiceSigningCertificate)
					Else
						result = New X509SecurityTokenProvider(credentials. ClientEncryptingCertificate)
					End If
				End If
			Else
				result = MyBase.CreateSecurityTokenProvider(requirement)
			End If

			Return result
		End Function

		Public Overrides Function CreateSecurityTokenAuthenticator(ByVal tokenRequirement As SecurityTokenRequirement, <System.Runtime.InteropServices.Out()> ByRef outOfBandTokenResolver As SecurityTokenResolver) As SecurityTokenAuthenticator
			Return MyBase.CreateSecurityTokenAuthenticator(tokenRequirement, outOfBandTokenResolver)
		End Function
	End Class