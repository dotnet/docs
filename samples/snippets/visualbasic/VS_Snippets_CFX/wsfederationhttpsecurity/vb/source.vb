'  =============================================================================
'
'  Sample for Class: WSFederationHttpSecurity
'
'            Author: ricksal
'
'================================================================================
'<snippet0>
'<snippet1>

Imports System
Imports System.Collections.Generic
Imports System.IdentityModel.Tokens
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens
Imports System.Security.Permissions
<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>
Namespace Samples
  '</snippet1>
  Public NotInheritable Class CustomBindingCreator
	'<snippet2>
	  '<snippet11>
	  '<snippet10>
	  '<snippet9>
	  '<snippet8>
	  '<snippet4>
	  '<snippet7>
	  '<snippet6>
	  '<snippet5>
	  '<snippet3>
	' This method creates a WSFederationHttpBinding.
	Public Shared Function CreateWSFederationHttpBinding(ByVal isClient As Boolean) As WSFederationHttpBinding
	  ' Create an instance of the WSFederationHttpBinding.
	  Dim b As New WSFederationHttpBinding()

	  ' Set the security mode to Message.
	  b.Security.Mode = WSFederationHttpSecurityMode.Message
	  '</snippet3>

	  ' Set the Algorithm Suite to Basic256Rsa15.
	  b.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Basic256Rsa15
	  '</snippet5>

	  ' Set NegotiateServiceCredential to true.
	  b.Security.Message.NegotiateServiceCredential = True
	  '</snippet6>

	  ' Set IssuedKeyType to Symmetric.
	  b.Security.Message.IssuedKeyType = SecurityKeyType.SymmetricKey
	  '</snippet7>

	  ' Set IssuedTokenType to SAML 1.1
	  b.Security.Message.IssuedTokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#samlv1.1"
	  '</snippet4>

		  '<snippet12>  
	  ' Extract the STS certificate from the certificate store.
	  Dim store As New X509Store(StoreName.TrustedPeople, StoreLocation.CurrentUser)
	  store.Open(OpenFlags.ReadOnly)
	  Dim certs As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindByThumbprint, "0000000000000000000000000000000000000000", False)
	  store.Close()

	  ' Create an EndpointIdentity from the STS certificate.
	  Dim identity As EndpointIdentity = EndpointIdentity.CreateX509CertificateIdentity (certs(0))
	  '</snippet12>  

	  ' Set the IssuerAddress using the address of the STS and the previously created 
	  ' EndpointIdentity.
	  b.Security.Message.IssuerAddress = New EndpointAddress(New Uri("http://localhost:8000/sts/x509"), identity)
	  '</snippet8>

	  ' Set the IssuerBinding to a WSHttpBinding loaded from configuration. 
	  ' The IssuerBinding is only used on federated clients.
	  If isClient Then
		  b.Security.Message.IssuerBinding = New WSHttpBinding("Issuer")
	  '</snippet9>

	  ' Set the IssuerMetadataAddress using the metadata address of the STS and the
	  ' previously created EndpointIdentity. The IssuerMetadataAddress is only used 
	  ' on federated services.
	  Else
		  b.Security.Message.IssuerMetadataAddress = New EndpointAddress(New Uri("http://localhost:8001/sts/mex"), identity)
	  End If
	  '</snippet10>

	  ' Create a ClaimTypeRequirement.
	  Dim ctr As New ClaimTypeRequirement("http://example.org/claim/c1", False)

	  ' Add the ClaimTypeRequirement to ClaimTypeRequirements
	  b.Security.Message.ClaimTypeRequirements.Add(ctr)
	  '</snippet11>

	  ' Return the created binding
	  Return b
	End Function
	'</snippet2>

	' It is a good practice to create a private constructor for a class that only 
	' defines static methods.
	Private Sub New()
	End Sub

  End Class
  '</snippet0>
End Namespace
