' <snippet1>

Imports System
Imports System.Collections.Generic
Imports System.Net.Security
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.Text

Namespace Microsoft.WCF.Documentation
  <ServiceContract(Namespace:="http://microsoft.wcf.documentation")> _
  Public Interface ISampleService
	' <snippet4>
	<OperationContract, FaultContractAttribute(GetType(GreetingFault), Action:="http://www.contoso.com/GreetingFault", ProtectionLevel:=ProtectionLevel.EncryptAndSign)> _
	Function SampleMethod(ByVal msg As String) As String
	' </snippet4>
  End Interface

  <DataContractAttribute> _
  Public Class GreetingFault
	Private report As String

	Public Sub New(ByVal message As String)
	  Me.report = message
	End Sub

	<DataMemberAttribute> _
	Public Property Message() As String
	  Get
		  Return Me.report
	  End Get
	  Set(ByVal value As String)
		  Me.report = value
	  End Set
	End Property
  End Class

  Friend Class SampleService
	  Implements ISampleService
  #Region "ISampleService Members"

  Public Function SampleMethod(ByVal msg As String) As String Implements ISampleService.SampleMethod
	Console.WriteLine("Client said: " & msg)
	' Generate intermittent error behavior.
	Dim rand As New Random(DateTime.Now.Millisecond)
	Dim test As Integer = rand.Next(5)
	If test Mod 2 <> 0 Then
	  Return "The service greets you: " & msg
	Else
	  ' <snippet5>
	  Throw New FaultException(Of GreetingFault)(New GreetingFault("A Greeting error occurred. You said: " & msg))
	End If
	  ' </snippet5>
  End Function

  #End Region
  End Class
End Namespace
' </snippet1>
