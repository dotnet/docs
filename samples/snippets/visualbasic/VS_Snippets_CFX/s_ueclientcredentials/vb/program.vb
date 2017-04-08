' Snippet Class:  for ClientCredentials
' snippet digits: 0-4 used 
' References:
'   System.ServiceModel
' 
' History: 
'   06-21-2006 a-arhu created
' 
'
'    //Example
'    //The following code shows how you can use this property to configure the X.509 certificate.
'
'// snippet3
'    // see source.cs below
'    // Configure proxy with 
'    // certificate.
'    proxy.ClientCredentials.ClientCertificate.SetCertificate(
'  		StoreLocation.CurrentUser, 
'  		StoreName.TrustedPeople, 
'  		X509FindType.FindBySubjectName, 
'  		"test1");
' 
'// snippet4
'Example
'The following code shows how to configure a credential.
'   // Configure proxy with 
'   // (username,password).
'   proxy.ClientCredentials.UserName.UserName = "test1";
'   proxy.ClientCredentials.UserName.Password = "1tset";
' 
'
'Example
'The following code shows how to use the object returned by this property to configure the impersonation level.
'// Create a proxy with the given client endpoint configuration.
'            using (CalculatorProxy proxy = new CalculatorProxy())
'            {
'                proxy.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
'

'<snippet0>


Imports System
Imports System.Collections.ObjectModel
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.Security.Permissions
Imports System.Security.Principal
'</snippet0>
<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>
Namespace Microsoft.Security.Samples
	Friend Class Service
		Shared Sub Main(ByVal args() As String)
			Try
				Dim s As New Service()
				s.NetTcpSecurityWindows()
				Console.ReadLine()
			Catch exc As System.InvalidOperationException
				Console.WriteLine("Message: {0}", exc.Message)
			Catch exc As System.ServiceModel.AddressAlreadyInUseException
				Console.WriteLine("Message: {0}", exc.Message)
			Catch exc As System.ServiceModel.ProtocolException
				Console.WriteLine("Message: {0}", exc.Message)
			Catch exc As Exception
				Console.WriteLine(exc.Message)
				Console.WriteLine(exc.InnerException.Message)
				Console.ReadLine()
			End Try

		End Sub

		Private Sub NetTcpSecurityWindows()
			'<snippet1>
			' Create a NetTcpBinding and set its security properties. The
			' security mode is Message, and the client must be authenticated with
			' Windows. Therefore, the client must be on the same Windows domain.
			Dim b As New NetTcpBinding()
			b.Security.Mode = SecurityMode.Message
			b.Security.Message.ClientCredentialType = MessageCredentialType.Windows

			' Set a Type variable for use when constructing the endpoint.
			Dim c As Type = GetType(ICalculator)

			' Create a base address for the service.
			Dim tcpBaseAddress As New Uri("net.tcp://machineName.Domain.Contoso.com:8036/serviceName")
			' The base address is in an array of URI objects.
			Dim baseAddresses() As Uri = { tcpBaseAddress }
			' Create the ServiceHost with type and base addresses.
			Dim sh As New ServiceHost(GetType(CalculatorClient), baseAddresses)

			' Add an endpoint to the service using the service type and binding.
			sh.AddServiceEndpoint(c, b, "")
			sh.Open()
            Dim address = sh.Description.Endpoints(0).ListenUri.AbsoluteUri
			Console.WriteLine("Listening @ {0}", address)
			Console.WriteLine("Press enter to close the service")
			Console.ReadLine()
			'</snippet1>
		End Sub

		Private Sub SecureHttp()
 '<snippet2>
			' Create a WSHttpBinding and set its security properties. The
			' security mode is Message, and the client is authenticated with 
			' a certificate.
			Dim ea As New EndpointAddress("http://contoso.com/")
			Dim b As New WSHttpBinding()
			b.Security.Mode = SecurityMode.Message
			b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate

' <snippet3>
			' Create the client with the binding and EndpointAddress.
			Dim calcClient As New CalculatorClient(b, ea)

			' Set the client credential value to a valid certificate.
			calcClient.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.TrustedPeople, X509FindType.FindBySubjectName, "client.com")
' </snippet3>

' <snippet4>
		   ' Configure the proxy with 
		   ' (username,password).
		   calcClient.ClientCredentials.UserName.UserName = "username"
		   calcClient.ClientCredentials.UserName.Password = "changethispassword"
' </snippet4>

			' Use the object returned by the property 
			' to configure the impersonation level.

' <snippet5>
			' Create a client object with the given client endpoint configuration.
		   Dim client As New CalculatorClient()
		  Try
				client.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation
			Catch timeProblem As TimeoutException
			  Console.WriteLine("The service operation timed out. " & timeProblem.Message)
			  Console.ReadLine()
			  client.Abort()
			Catch commProblem As CommunicationException
			  Console.WriteLine("There was a communication problem. " & commProblem.Message + commProblem.StackTrace)
			  Console.ReadLine()
			  client.Abort()
			End Try
' </snippet5>

' </snippet2>
		End Sub
	End Class


	'------------------------------------------------------------------------------
	' <auto-generated>
	'     This code was generated by a tool.
	'     Runtime Version:2.0.50727.42
	'
	'     Changes to this file may cause incorrect behavior and will be lost if
	'     the code is regenerated.
	' </auto-generated>
	'------------------------------------------------------------------------------



'    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	<System.ServiceModel.ServiceContractAttribute(Namespace := "http://Microsoft.ServiceModel.Samples", ConfigurationName := "ICalculator")> _
	Public Interface ICalculator

		<System.ServiceModel.OperationContractAttribute(Action := "http://Microsoft.ServiceModel.Samples/ICalculator/Add", ReplyAction := "http://Microsoft.ServiceModel.Samples/ICalculator/AddResponse")> _
		Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
	End Interface

	' [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	Public Interface ICalculatorChannel
	Inherits ICalculator, System.ServiceModel.IClientChannel
	End Interface

	' [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	<System.Diagnostics.DebuggerStepThroughAttribute()> _
	Public Class CalculatorClient
		Inherits System.ServiceModel.ClientBase(Of ICalculator)
		Implements ICalculator

		Public Sub New()
		End Sub

		Public Sub New(ByVal endpointConfigurationName As String)
			MyBase.New(endpointConfigurationName)
		End Sub

		Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
			MyBase.New(endpointConfigurationName, remoteAddress)
		End Sub

		Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
			MyBase.New(endpointConfigurationName, remoteAddress)
		End Sub

		Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
			MyBase.New(binding, remoteAddress)
		End Sub

		Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
			Return MyBase.Channel.Add(n1, n2)
		End Function
	End Class

End Namespace


