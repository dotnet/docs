Imports System
Imports System.ServiceModel
Imports System.Security.Permissions
Imports System.Runtime.Serialization
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security.Tokens
Imports System.Data
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Text

<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>
Namespace Example
	Public Class Test
		'<snippet1>
		Private Sub Run()
			Dim b As New WSHttpBinding(SecurityMode.Message)
			Dim baseAddress As New Uri("http://localhost:1066/calculator")
			Dim sh As New ServiceHost(GetType(Calculator), baseAddress)
			sh.AddServiceEndpoint(GetType(ICalculator), b, "")

			' Find the ContractDescription of the operation to find.
			Dim cd As ContractDescription = sh.Description.Endpoints(0).Contract
			Dim myOperationDescription As OperationDescription = cd.Operations.Find("Add")

			' Find the serializer behavior.
			Dim serializerBehavior As XmlSerializerOperationBehavior = myOperationDescription.Behaviors. Find(Of XmlSerializerOperationBehavior)()

			' If the serializer is not found, create one and add it.
			If serializerBehavior Is Nothing Then
				serializerBehavior = New XmlSerializerOperationBehavior(myOperationDescription)
				myOperationDescription.Behaviors.Add(serializerBehavior)
			End If

			' Change style of the serialize attribute.
			serializerBehavior.XmlSerializerFormatAttribute.Style = OperationFormatStyle.Document

			sh.Open()
			Console.WriteLine("Listening")
			Console.ReadLine()
			sh.Close()
		End Sub
		'</snippet1>


		Shared Sub Main()
			Try
				Dim t As New Test()
				t.Run()
			Catch exc As System.Exception
				Console.WriteLine(exc.Message)
				Console.ReadLine()
			End Try
		End Sub
	End Class
	<ServiceContract> _
	Friend Interface ICalculator
		<OperationContract> _
		Function Add(ByVal a As Double, ByVal b As Double) As Double

		<OperationContract> _
		Function GetInfo(ByVal request As String) As Object

	End Interface

	<MessageContract(ProtectionLevel := System.Net.Security.ProtectionLevel.Sign)> _
	Public Class Calculator
		Implements ICalculator

		Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
			Return a + b
		End Function


		Public Function GetInfo(ByVal request As String) As Object Implements ICalculator.GetInfo
			If request = "Version" Then
				Return "1.0"
			Else
				Dim x As New ComplexNumber()
				x.numberID_Value = "Calculator 1.0"
				Return x
			End If
		End Function
	End Class

	<DataContract> _
	Public Class ComplexNumber
		<DataMember> _
		Public numberID_Value As String
	End Class
End Namespace
