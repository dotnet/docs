' <snippet1>

Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.Text

Namespace Microsoft.WCF.Documentation
  <ServiceContract(Namespace:="http://microsoft.wcf.documentation")> _
  Public Interface ISampleService
	<OperationContract, FaultContractAttribute(GetType(GreetingFault))> _
	Function SampleMethod(ByVal msg As String) As String
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
	Public Function SampleMethod(ByVal msg As String) As String Implements ISampleService.SampleMethod
	  Console.WriteLine("Client said: " & msg)
	  ' Note: Not a contractually specified exception. If 
	  ' ServiceBehaviorAttribute.IncludeExceptionDetailInFaults is set to true,
	  ' this fault is experienced on a WCF client as a FaultException.
	  Throw New Exception("A Greeting error occurred. You said: " & msg)
	End Function
  End Class
End Namespace
' </snippet1>

' <snippet8>
'The service output is: 
'
'EnforceGreetingFaultBehavior created.
'Validate is called.
'The EnforceGreetingFaultBehavior has been applied.
'The service is ready.
'Press <ENTER> to terminate service.
'Client said: Why Hello there!
'ProvideFault called. Converting Exception to GreetingFault....
'HandleError called.
'
'And the client output is:
' 
'Enter the greeting to send:
'Why Hello there!
'A Greeting error occurred. You said: Why Hello there!
'Done!
'</snippet8>

