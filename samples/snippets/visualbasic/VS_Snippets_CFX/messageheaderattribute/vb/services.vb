' <snippet1>
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Channels

Namespace Microsoft.WCF.Documentation
  ' <snippet5>
  <ServiceContract(Namespace := "Microsoft.WCF.Documentation")> _
  Friend Interface IMessagingHello
	<OperationContract(Action := "http://GreetingMessage/Action", ReplyAction := "http://HelloResponseMessage/Action")> _
	Function Hello(ByVal msg As HelloGreetingMessage) As HelloResponseMessage
  End Interface
  ' </snippet5>

  ' <snippet4>
  <MessageContract> _
  Public Class HelloResponseMessage
	Private localResponse As String = String.Empty
	Private extra As String = String.Empty

	<MessageBodyMember(Name := "ResponseToGreeting", Namespace := "http://www.examples.com")> _
	Public Property Response() As String
	  Get
		  Return localResponse
	  End Get
	  Set(ByVal value As String)
		  localResponse = value
	  End Set
	End Property

	<MessageHeader(Name := "OutOfBandData", Namespace := "http://www.examples.com", MustUnderstand:=True)> _
	Public Property ExtraValues() As String
	  Get
		  Return extra
	  End Get
	  Set(ByVal value As String)
		  Me.extra = value
	  End Set
	End Property

'   
'    The following is the response message, edited for clarity.
'    
'    <s:Envelope>
'      <s:Header>
'        <a:Action s:mustUnderstand="1">http://HelloResponseMessage/Action</a:Action>
'        <h:OutOfBandData s:mustUnderstand="1" xmlns:h="http://www.examples.com">Served by object 13804354.</h:OutOfBandData>
'      </s:Header>
'      <s:Body>
'        <HelloResponseMessage xmlns="Microsoft.WCF.Documentation">
'          <ResponseToGreeting xmlns="http://www.examples.com">Service received: Hello.</ResponseToGreeting>
'        </HelloResponseMessage>
'      </s:Body>    
'    </s:Envelope>
'    
  End Class
 ' </snippet4>
 ' <snippet3>
  <MessageContract> _
  Public Class HelloGreetingMessage
	Private localGreeting As String

	<MessageBodyMember(Name := "Salutations", Namespace := "http://www.examples.com")> _
	Public Property Greeting() As String
	  Get
		  Return localGreeting
	  End Get
	  Set(ByVal value As String)
		  localGreeting = value
	  End Set
	End Property
  End Class

'  
'   The following is the request message, edited for clarity.
'    
'    <s:Envelope>
'      <s:Header>
'        <!-- Note: Some header content has been removed for clarity.
'        <a:Action>http://GreetingMessage/Action</a:Action> 
'        <a:To s:mustUnderstand="1"></a:To>
'      </s:Header>
'      <s:Body u:Id="_0" xmlns:u="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd">
'        <HelloGreetingMessage xmlns="Microsoft.WCF.Documentation">
'          <Salutations xmlns="http://www.examples.com">Hello.</Salutations>
'        </HelloGreetingMessage>
'      </s:Body>
'   </s:Envelope>
'   
  ' </snippet3>

  ' <snippet2>
  Friend Class MessagingHello
	  Implements IMessagingHello
	Public Function Hello(ByVal msg As HelloGreetingMessage) As HelloResponseMessage Implements IMessagingHello.Hello
	  Console.WriteLine("Caller sent: " & msg.Greeting)
	  Dim responseMsg As New HelloResponseMessage()
	  responseMsg.Response = "Service received: " & msg.Greeting
	  responseMsg.ExtraValues = String.Format("Served by object {0}.", Me.GetHashCode().ToString())
	  Console.WriteLine("Returned response message.")
	  Return responseMsg
	End Function
  End Class
  ' </snippet2>
End Namespace
' </snippet1>
