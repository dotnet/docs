' snippet code for \WSHttpBinding\WSHttpBinding.vb
'<snippet0>

Imports System
Imports System.ServiceModel
Imports System.Collections.Generic
Imports System.IdentityModel.Tokens
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens
Imports System.Security.Permissions

' Define a service contract for the calculator. 
<ServiceContract()> _
Public Interface ICalculator
	<OperationContract(IsOneWay := False)> _
	Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
	<OperationContract(IsOneWay := False)> _
	Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
	<OperationContract(IsOneWay := False)> _
	Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
	<OperationContract(IsOneWay := False)> _
	Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
End Interface

'<snippet3>
Public NotInheritable Class CustomBindingCreator

	Public Shared Sub snippetSecurity()
		'<Snippet8>
		Dim wsHttpBinding As New WSHttpBinding()
		Dim whSecurity As WSHttpSecurity = wsHttpBinding.Security
		'</Snippet8>
	End Sub


	Public Shared Sub snippetCreateBindingElements()
		'<Snippet9>
		Dim wsHttpBinding As New WSHttpBinding()
		Dim beCollection As BindingElementCollection = wsHttpBinding.CreateBindingElements()
		'</Snippet9>
	End Sub


	Private Sub snippetCreateMessageSecurity()
		'<Snippet10>
		Dim wsHttpBinding As New WSHttpBinding()
        '</Snippet10>
	End Sub

	Public Shared Sub snippetGetTransport()
		'<Snippet11>
		Dim wsHttpBinding As New WSHttpBinding()
        '</Snippet11>
	End Sub

	Public Shared Sub snippetAllowCookies()
		' <Snippet12>
		Dim wsHttpBinding As New WSHttpBinding()
		wsHttpBinding.AllowCookies = True
		' </Snippet12>
	End Sub

	Public Shared Function GetBinding() As Binding
		' <Snippet6>
		' securityMode is Message
		' reliableSessionEnabled is true
		Dim binding As New WSHttpBinding(SecurityMode.Message, True)
		binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows
		' </Snippet6>

		Dim security As WSHttpSecurity = binding.Security
		Return binding

	End Function

	Public Shared Function GetBinding2() As Binding

		' <Snippet7>
		' The security mode is set to Message.
		Dim binding As New WSHttpBinding(SecurityMode.Message)
		binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows
		Return binding
		' </Snippet7>

	End Function

	'<snippet4>
	' This method creates a WSFederationHttpBinding.
	Public Shared Function CreateWSFederationHttpBinding() As WSFederationHttpBinding
		' Create an instance of the WSFederationHttpBinding
		Dim b As New WSFederationHttpBinding()

		' Set the security mode to Message
		b.Security.Mode = WSFederationHttpSecurityMode.Message

		' Set the Algorithm Suite to Basic256Rsa15
		b.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Basic256Rsa15

		' Set NegotiateServiceCredential to true
		b.Security.Message.NegotiateServiceCredential = True

		' Set IssuedKeyType to Symmetric
		b.Security.Message.IssuedKeyType = SecurityKeyType.SymmetricKey

		' Set IssuedTokenType to SAML 1.1
		b.Security.Message.IssuedTokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#samlv1.1"

		' Extract the STS certificate from the certificate store
		Dim store As New X509Store(StoreName.TrustedPeople, StoreLocation.CurrentUser)
		store.Open(OpenFlags.ReadOnly)
        Dim certs As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindByThumbprint, "cd 54 88 85 0d 63 db ac 92 59 05 af ce b8 b1 de c3 67 9e 3f", False)
		store.Close()

		' Create an EndpointIdentity from the STS certificate
		Dim identity As EndpointIdentity = EndpointIdentity.CreateX509CertificateIdentity(certs(0))

		' Set the IssuerAddress using the address of the STS and the previously created EndpointIdentity
		b.Security.Message.IssuerAddress = New EndpointAddress(New Uri("http://localhost:8000/sts/x509"), identity)

		' <Snippet5>
		' Set the IssuerBinding to a WSHttpBinding loaded from config
		b.Security.Message.IssuerBinding = New WSHttpBinding("Issuer")
		' </Snippet5>

		' Set the IssuerMetadataAddress using the metadata address of the STS and the previously created EndpointIdentity
		b.Security.Message.IssuerMetadataAddress = New EndpointAddress(New Uri("http://localhost:8001/sts/mex"), identity)

		' Create a ClaimTypeRequirement
		Dim ctr As New ClaimTypeRequirement("http://example.org/claim/c1", False)

		' Add the ClaimTypeRequirement to ClaimTypeRequirements
		b.Security.Message.ClaimTypeRequirements.Add(ctr)

		' Return the created binding
		Return b
	End Function
	'</snippet4>

End Class
'</snippet3>

' Service class which implements the service contract. 
Public Class CalculatorService
	Implements ICalculator
	Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
        Dim result = n1 + n2
		Return result
	End Function
	Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
        Dim result = n1 - n2
		Return result
	End Function
	Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply
        Dim result = n1 * n2
		Return result
	End Function
	Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
        Dim result = n1 / n2
		Return result
	End Function


	' Host the service within this EXE console application. 
	Public Shared Sub Main()
		' Create a WSHttpBinding and set its property values. 
		'<snippet1>
        Dim binding As New WSHttpBinding()
        With binding
            .Name = "binding1"
            .HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
            .Security.Mode = SecurityMode.Message
            .ReliableSession.Enabled = False
            .TransactionFlow = False
        End With
		
		'</snippet1>
		'Specify a base address for the service endpoint. 
		Dim baseAddress As New Uri("http://localhost:8000/servicemodelsamples/service")
		' Create a ServiceHost for the CalculatorService type 
		' and provide it with a base address. 
		Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)
		serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, baseAddress)
		' Open the ServiceHostBase to create listeners 
		' and start listening for messages. 
		serviceHost.Open()
		' The service can now be accessed. 
		Console.WriteLine("The service is ready.")
		Console.WriteLine("Press <ENTER> to terminate service.")
		Console.WriteLine()
		Console.ReadLine()
		' Close the ServiceHost to shutdown the service. 
		serviceHost.Close()
	End Sub
End Class
'</snippet0>