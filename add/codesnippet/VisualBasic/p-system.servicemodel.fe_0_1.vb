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

	  ' Set IssuedTokenType to SAML 1.1
	  b.Security.Message.IssuedTokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#samlv1.1"

	  ' Extract the STS certificate from the certificate store.
	  Dim store As New X509Store(StoreName.TrustedPeople, StoreLocation.CurrentUser)
	  store.Open(OpenFlags.ReadOnly)
	  Dim certs As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindByThumbprint, "0000000000000000000000000000000000000000", False)
	  store.Close()

	  ' Create an EndpointIdentity from the STS certificate.
	  Dim identity As EndpointIdentity = EndpointIdentity.CreateX509CertificateIdentity (certs(0))

	  ' Set the IssuerAddress using the address of the STS and the previously created 
	  ' EndpointIdentity.
	  b.Security.Message.IssuerAddress = New EndpointAddress(New Uri("http://localhost:8000/sts/x509"), identity)

	  ' Set the IssuerBinding to a WSHttpBinding loaded from configuration. 
	  ' The IssuerBinding is only used on federated clients.
	  If isClient Then
		  b.Security.Message.IssuerBinding = New WSHttpBinding("Issuer")

	  ' Set the IssuerMetadataAddress using the metadata address of the STS and the
	  ' previously created EndpointIdentity. The IssuerMetadataAddress is only used 
	  ' on federated services.
	  Else
		  b.Security.Message.IssuerMetadataAddress = New EndpointAddress(New Uri("http://localhost:8001/sts/mex"), identity)
	  End If