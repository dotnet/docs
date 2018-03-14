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

			' Create a binding that uses a username/password credential.
			Dim b As New WSHttpBinding(SecurityMode.Message)
			b.Security.Message.ClientCredentialType = MessageCredentialType.UserName

			' Add an endpoint.
			sh.AddServiceEndpoint(GetType(ICalculator), b, "UserNamePasswordCalculator")

			' Get a reference to the UserNamePasswordServiceCredential object.
			Dim unpCredential As UserNamePasswordServiceCredential = sh.Credentials.UserNameAuthentication
			' Print out values.
			Console.WriteLine("IncludeWindowsGroup: {0}", unpCredential.IncludeWindowsGroups)
			Console.WriteLine("UserNamePasswordValidationMode: {0}", unpCredential.UserNamePasswordValidationMode)
			Console.WriteLine("CachedLogonTokenLifetime.Minutes: {0}", unpCredential.CachedLogonTokenLifetime.Minutes)
			Console.WriteLine("CacheLogonTokens: {0}", unpCredential.CacheLogonTokens)
			Console.WriteLine("MaxCachedLogonTokens: {0}", unpCredential.MaxCachedLogonTokens)

			Console.ReadLine()
			'</snippet1>
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