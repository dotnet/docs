'<snippet1>
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Text

Namespace Microsoft.WCF.Documentation
  <ServiceContract(Namespace:="http://Microsoft.WCF.Documentation")> _
  Public Interface ISampleService

        <OperationContract(Action:="http://Microsoft.WCF.Documentation/OperationContractMethod", _
                           Name:="OCAMethod", ReplyAction:="http://Microsoft.WCF.Documentation/ResponseToOCAMethod")> _
        Function SampleMethod(ByVal msg As String) As String

	<OperationContractAttribute(Action := "*")> _
	Sub UnrecognizedMessageHandler(ByVal msg As Message)
  End Interface

  Friend Class SampleService
	  Implements ISampleService
	Public Function SampleMethod(ByVal msg As String) As String Implements ISampleService.SampleMethod
	  Console.WriteLine("Called with: {0}", msg)
		 Return "The service greets you: " & msg
	End Function

	Public Sub UnrecognizedMessageHandler(ByVal msg As Message) Implements ISampleService.UnrecognizedMessageHandler
	  Console.WriteLine("Unrecognized message: " & msg.ToString())
	End Sub
  End Class
End Namespace
'</snippet1>

'
'//<snippet2>
'<s:Envelope xmlns:a="http://schemas.xmlsoap.org/ws/2004/08/addressing" xmlns:s="http://www.w3.org/2003/05/soap-envelope">
'  <s:Header>
'    <a:Action s:mustUnderstand="1">http://Microsoft.WCF.Documentation/ResponseToOCAMethod</a:Action> 
'  </s:Header>
'  <s:Body>
'    <OCAMethodResponse xmlns="http://Microsoft.WCF.Documentation">
'      <OCAMethodResult>The service greets you: Hello!</OCAMethodResult> 
'    </OCAMethodResponse>
'  </s:Body>
'</s:Envelope>
'//</snippet2>
'