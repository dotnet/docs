Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.Text

Namespace Microsoft.WCF.Documentation
  <ServiceContractAttribute(Namespace:="http://microsoft.wcf.documentation", SessionMode:=SessionMode.Required)> _
  Public Interface ISampleService

	<OperationContractAttribute, FaultContractAttribute(GetType(SampleFault))> _
	Function SampleMethod(ByVal msg As String) As String
  End Interface
  ' <snippet1>
  Friend Class SampleService
	  Implements ISampleService
	Private id As Guid
	Private session As String

	Public Sub New()
	  id = Guid.NewGuid()
	  session = OperationContext.Current.SessionId
	  Console.WriteLine("Object {0} has been created.", id)
	  Console.WriteLine("For session {0}", session)
	End Sub
	<OperationBehavior(ReleaseInstanceMode:=ReleaseInstanceMode.BeforeAndAfterCall)> _
	Public Function SampleMethod(ByVal msg As String) As String Implements ISampleService.SampleMethod
	  Console.WriteLine("The caller said: ""{0}""", msg)
	  Console.WriteLine("For session {0}", OperationContext.Current.SessionId)
	  Return "The service greets you: " & msg
	End Function

	Protected Overrides Sub Finalize()
	  Console.WriteLine("Object {0} has been destroyed.", id)
	  Console.WriteLine("For session {0}", session)
	End Sub
  End Class
  ' </snippet1>

  ' The detail type of the specified SOAP fault.
  <DataContractAttribute(Namespace := "http://microsoft.wcf.documentation")> _
  Public Class SampleFault
	<DataMemberAttribute(Name:="FaultMessage")> _
	Private msg As String

	Public Property FaultMessage() As String
	  Get
		  Return Me.msg
	  End Get
	  Set(ByVal value As String)
		  Me.msg = value
	  End Set
	End Property
  End Class
End Namespace
