// <snippet1>
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.WCF.Documentation
{
  // <snippet5>
  [ServiceContract(Namespace = "Microsoft.WCF.Documentation")]
  interface IMessagingHello
  {
    [OperationContract(
     Action = "http://GreetingMessage/Action",
     ReplyAction = "http://HelloResponseMessage/Action"
    )]
    HelloResponseMessage Hello(HelloGreetingMessage msg);
  }
  // </snippet5>

  // <snippet4>
  [MessageContract]
  public class HelloResponseMessage
  {
    private string localResponse = String.Empty;
    private string extra = String.Empty;

    [MessageBodyMember(
      Name = "ResponseToGreeting",
      Namespace = "http://www.examples.com")]
    public string Response
    {
      get { return localResponse; }
      set { localResponse = value; }
    }

    [MessageHeader(
      Name = "OutOfBandData",
      Namespace = "http://www.examples.com",
      MustUnderstand=true
    )]
    public string ExtraValues
    {
      get { return extra; }
      set { this.extra = value; }
   }

   /*
    The following is the response message, edited for clarity.
    
    <s:Envelope>
      <s:Header>
        <a:Action s:mustUnderstand="1">http://HelloResponseMessage/Action</a:Action>
        <h:OutOfBandData s:mustUnderstand="1" xmlns:h="http://www.examples.com">Served by object 13804354.</h:OutOfBandData>
      </s:Header>
      <s:Body>
        <HelloResponseMessage xmlns="Microsoft.WCF.Documentation">
          <ResponseToGreeting xmlns="http://www.examples.com">Service received: Hello.</ResponseToGreeting>
        </HelloResponseMessage>
      </s:Body>    
    </s:Envelope>
    */
 }
 // </snippet4>
 // <snippet3>
  [MessageContract]
  public class HelloGreetingMessage
  {
    private string localGreeting;

    [MessageBodyMember(
      Name = "Salutations", 
      Namespace = "http://www.examples.com"
    )]
    public string Greeting
    {
      get { return localGreeting; }
      set { localGreeting = value; }
    }
  }

  /*
   The following is the request message, edited for clarity.
    
    <s:Envelope>
      <s:Header>
        <!-- Note: Some header content has been removed for clarity.
        <a:Action>http://GreetingMessage/Action</a:Action> 
        <a:To s:mustUnderstand="1"></a:To>
      </s:Header>
      <s:Body u:Id="_0" xmlns:u="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd">
        <HelloGreetingMessage xmlns="Microsoft.WCF.Documentation">
          <Salutations xmlns="http://www.examples.com">Hello.</Salutations>
        </HelloGreetingMessage>
      </s:Body>
   </s:Envelope>
   */
  // </snippet3>

  // <snippet2>
  class MessagingHello : IMessagingHello
  {
    public HelloResponseMessage Hello(HelloGreetingMessage msg)
    {
      Console.WriteLine("Caller sent: " + msg.Greeting);
      HelloResponseMessage responseMsg = new HelloResponseMessage();
      responseMsg.Response = "Service received: " + msg.Greeting;
      responseMsg.ExtraValues = String.Format("Served by object {0}.", this.GetHashCode().ToString());
      Console.WriteLine("Returned response message.");
      return responseMsg;
    }
  }
  // </snippet2>
}
// </snippet1>
