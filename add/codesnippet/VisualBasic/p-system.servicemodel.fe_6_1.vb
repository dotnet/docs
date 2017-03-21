	' This method creates a WSFederationHttpBinding.
	Public Shared Function CreateWSFederationHttpBinding(ByVal isClient As Boolean) As WSFederationHttpBinding
	  ' Create an instance of the WSFederationHttpBinding.
	  Dim b As New WSFederationHttpBinding()

	  ' Set the security mode to Message.
	  b.Security.Mode = WSFederationHttpSecurityMode.Message

	  ' Set the Algorithm Suite to Basic256Rsa15.
	  b.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Basic256Rsa15

	  ' Set NegotiateServiceCredential to true.
	  b.Security.Message.NegotiateServiceCredential = True

	  ' Set IssuedKeyType to Symmetric.
	  b.Security.Message.IssuedKeyType = SecurityKeyType.SymmetricKey