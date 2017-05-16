
Imports System
Imports System.ServiceModel
Imports System.Text
Imports System.IO
Imports System.Security.Permissions

<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>
Namespace Stuff
	Public NotInheritable Class Test

		Private Sub New()
		End Sub

		Public Shared Sub Main()
			Dim myPassword As String = Returnpassword()
			Console.WriteLine(myPassword)
		End Sub
		'<snippet1>
		Public Shared Function Returnpassword() As String
			Console.WriteLine("Provide a valid machine or domain account. [domain\user]")
			Console.WriteLine("   Enter username:")
			Dim username As String = Console.ReadLine()
			Console.WriteLine("   Enter password:")
            Dim password = ""
			Dim info As ConsoleKeyInfo = Console.ReadKey(True)
			Do While info.Key <> ConsoleKey.Enter
				If info.Key <> ConsoleKey.Backspace Then
					password &= info.KeyChar
					info = Console.ReadKey(True)
				ElseIf info.Key = ConsoleKey.Backspace Then
					If (Not String.IsNullOrEmpty(password)) Then
						password = password.Substring (0, password.Length - 1)
					End If
					info = Console.ReadKey(True)
				End If
			Loop
            For i = 0 To password.Length - 1
                Console.Write("*")
            Next i
		Return password
		End Function
		'</snippet1>
	End Class
End Namespace
Namespace Samples
	Public Class Test
		Private Sub AuthenticateWithUserName()
			'<snippet10>
			'<snippet7>
			Dim myBinding As New WSHttpBinding()
			myBinding.Security.Mode = SecurityMode.Message
			myBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName
			'</snippet7>


			'<snippet2>
			Dim client As New CalculatorClient("default")
			'</snippet2>

			'<snippet3>
			client.ClientCredentials.UserName.Password = ReturnPassword()
			'</snippet3>

			'<snippet4>
			client.ClientCredentials.UserName.UserName = ReturnUsername()
			'</snippet4>
			'</snippet10>
			'<snippet5>
            Dim value1 = client.Add(100, 15.99)
			'</snippet5>

			'<snippet6>
			client.Close()
			'</snippet6>



		End Sub

		Private Function ReturnUsername() As String
			Return "hah"
		End Function

		Private Function ReturnPassword() As String
			Return "hah"
		End Function
	End Class


	<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), System.ServiceModel.ServiceContractAttribute()> _
	Public Interface ICalculator

		<System.ServiceModel.OperationContractAttribute(Action := "http://tempuri.org/ICalculator/Divide", ReplyAction := "http://tempuri.org/ICalculator/DivideResponse")> _
		Function Divide(ByVal a As Double, ByVal b As Double) As Double

		<System.ServiceModel.OperationContractAttribute(Action := "http://tempuri.org/ICalculator/CalculateTax", ReplyAction := "http://tempuri.org/ICalculator/CalculateTaxResponse")> _
		Function Add(ByVal a As Double, ByVal b As Double) As Double
	End Interface

	<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
	Public Interface ICalculatorChannel
	Inherits ICalculator, System.ServiceModel.IClientChannel
	End Interface

	<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
	Partial Public Class CalculatorClient
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

		Public Function Divide(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Divide
			Return MyBase.Channel.Divide(a, b)
		End Function

		Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
			Return MyBase.Channel.Add(a, b)
		End Function
	End Class
End Namespace
