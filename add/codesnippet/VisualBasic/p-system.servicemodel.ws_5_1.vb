	' This method creates a WSFederationHttpBinding.
	Public Shared Function CreateWSFederationHttpBinding(ByVal isClient As Boolean) As WSFederationHttpBinding
	  ' Create an instance of the WSFederationHttpBinding.
	  Dim b As New WSFederationHttpBinding()

	  ' Set the security mode to Message.
	  b.Security.Mode = WSFederationHttpSecurityMode.Message