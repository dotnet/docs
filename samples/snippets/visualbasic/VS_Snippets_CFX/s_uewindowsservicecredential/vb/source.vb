Imports Microsoft.VisualBasic
Imports System
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.ServiceModel.Description
Imports System.Security.Cryptography.X509Certificates

Namespace Example
	Public Class Test
		Shared Sub Main()
			Dim t As New Test()
			t.Snippet1()
		End Sub


			Private Sub Snippet1()
				'<snippet1>
				' Create a service host.
				Dim httpUri As New Uri("http://localhost/Calculator")
				Dim sh As New ServiceHost(GetType(Calculator), httpUri)

				' Create a binding that uses a WindowsServiceCredential.
				Dim b As New WSHttpBinding(SecurityMode.Message)
				b.Security.Message.ClientCredentialType = MessageCredentialType.Windows

				' Add an endpoint.
				sh.AddServiceEndpoint(GetType(ICalculator), b, "WindowsCalculator")

				' Get a reference to the WindowsServiceCredential object.
				Dim winCredential As WindowsServiceCredential = sh.Credentials.WindowsAuthentication
				' Print out values.
				Console.WriteLine("IncludeWindowsGroup: {0}", winCredential.IncludeWindowsGroups)
				Console.WriteLine("UserNamePasswordValidationMode: {0}", winCredential.AllowAnonymousLogons)

				Console.ReadLine()
				'</snippet1>
			End Sub
			Private Sub Snippet2()
				'<snippet2>
				' Create a service host.
				Dim httpUri As New Uri("http://localhost/Calculator")
				Dim sh As New ServiceHost(GetType(Calculator), httpUri)

				' Create a binding that uses a WindowsServiceCredential .
				Dim b As New WSHttpBinding(SecurityMode.Message)
				b.Security.Message.ClientCredentialType = MessageCredentialType.Windows

				' Add an endpoint.
				sh.AddServiceEndpoint(GetType(ICalculator), b, "WindowsCalculator")

				' Get a reference to the WindowsServiceCredential object.
				Dim ssCredential As SecureConversationServiceCredential = sh.Credentials.SecureConversationAuthentication

				'</snippet2>
			End Sub
			Private Sub Snippet3()
				'<snippet3>
				' Create a service host.
				Dim httpUri As New Uri("http://localhost/Calculator")
				Dim sh As New ServiceHost(GetType(Calculator), httpUri)

				' Create a binding that uses a WindowsServiceCredential .
				Dim b As New WSHttpBinding(SecurityMode.Message)
				b.Security.Message.ClientCredentialType = MessageCredentialType.Windows

				' Add an endpoint.
				sh.AddServiceEndpoint(GetType(ICalculator), b, "WindowsCalculator")

				' Clone these credentials.
				Dim cloneCredential As ServiceCredentials = sh.Credentials.Clone()

				'</snippet3>
			End Sub
	End Class

	<ServiceContract> _
	Friend Interface ICalculator
		<OperationContract> _
		Function Add(ByVal a As Double, ByVal b As Double) As Double
	End Interface

	Public Class Calculator
		Implements ICalculator
		Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
			Return a + b
		End Function
	End Class
End Namespace