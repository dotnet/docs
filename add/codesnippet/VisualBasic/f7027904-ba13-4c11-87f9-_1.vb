		Protected Sub New(ByVal other As MyClientCredentials)
			MyBase.New(other)
			Me.clientEncryptingCert = other.clientEncryptingCert
			Me.clientSigningCert = other.clientSigningCert
			Me.serviceEncryptingCert = other.serviceEncryptingCert
			Me.serviceSigningCert = other.serviceSigningCert
		End Sub