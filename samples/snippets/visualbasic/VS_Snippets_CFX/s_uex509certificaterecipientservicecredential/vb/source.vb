Imports Microsoft.VisualBasic
Imports System
Imports System.ServiceModel
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates



Namespace Samples

	<ServiceContract> _
	Friend Interface ICalculator
	<OperationContract> _
	Function Add(ByVal x As Integer, ByVal y As Integer) As Integer
	End Interface


	'<snippet1>
	<ServiceContract> _
	Friend Interface IMyService

	'Define the contract operations.

	End Interface

	Friend Class MyService
		Implements IMyService

	'Implement the IMyService operations.

	End Class
	'</snippet1>


	Public Class Test0
		Public Shared Sub Main()
		End Sub

		Private Sub CreateNetTcpBinding()
			'<snippet4>
			Dim b As New NetTcpBinding()
			b.Security.Mode = SecurityMode.Message
			Dim c As Type = GetType(ICalculator)
			Dim a As New Uri("net.tcp://MyMachineName/tcpBase")
			Dim baseAddresses() As Uri = { a }
			Dim sh As New ServiceHost(GetType(MyService), baseAddresses)
			sh.AddServiceEndpoint(c, b, "Aloha")
			sh.Credentials.ServiceCertificate.SetCertificate("CN=Administrator,CN=Users,DC=johndoe,DC=nttest,DC=microsoft,DC=com")
			sh.Open()

			'</snippet4>
		End Sub

	End Class
	Public Class Test1
		Public Shared Sub Main()
		End Sub

		Private Sub CreateNetTcpBinding()
			'<snippet5>
			Dim b As New NetTcpBinding()
			b.Security.Mode = SecurityMode.Message
			Dim c As Type = GetType(ICalculator)
			Dim a As New Uri("net.tcp://MyMachineName/tcpBase")
			Dim baseAddresses() As Uri = { a }
			Dim sh As New ServiceHost(GetType(MyService), baseAddresses)
			sh.AddServiceEndpoint(c, b, "Aloha")
			sh.Credentials.ServiceCertificate.SetCertificate("CN=Administrator,CN=Users,DC=johndoe,DC=nttest,DC=microsoft,DC=com", StoreLocation.LocalMachine, StoreName.My)
			sh.Open()
			'</snippet5>
		End Sub

	End Class
	Public Class Test
		Public Shared Sub Main()
		End Sub

	Private Sub CreateNetTcpBinding()
			'<snippet2>
		Dim b As New NetTcpBinding()
		b.Security.Mode = SecurityMode.Message
		Dim c As Type = GetType(ICalculator)
		Dim a As New Uri("net.tcp://MyMachineName/tcpBase")
		Dim baseAddresses() As Uri = { a }
		Dim sh As New ServiceHost(GetType(MyService), baseAddresses)
		sh.AddServiceEndpoint(c, b, "Aloha")
		sh.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint, "af1f50b20cd413ed9cd00c315bbb6dc1c08da5e6")
		sh.Open()

			'</snippet2>
	End Sub
	End Class
	Public Class Test6
		Public Shared Sub Main()
		End Sub

	Private Sub CreateNetTcpBinding()
		'<snippet7>
		'<snippet6>
		Dim b As New NetTcpBinding()
		b.Security.Mode = SecurityMode.Message
		Dim c As Type = GetType(ICalculator)
		Dim a As New Uri("net.tcp://MyMachineName/tcpBase")
		Dim baseAddresses() As Uri = { a }
		Dim sh As New ServiceHost(GetType(MyService), baseAddresses)
		sh.AddServiceEndpoint(c, b, "Aloha")
		sh.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint, "af1f50b20cd413ed9cd00c315bbb6dc1c08da5e6")
		sh.Open()
		'</snippet6>
		Dim cert As X509Certificate2 = sh.Credentials.ServiceCertificate.Certificate
		'</snippet7>
	End Sub
	End Class
End Namespace
