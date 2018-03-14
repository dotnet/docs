//<snippet1>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(Namespace="http://Microsoft.WCF.Documentation")]
  public interface ISampleService{

    [OperationContract(
      Action="http://Microsoft.WCF.Documentation/OperationContractMethod",
      Name="OCAMethod",
      ReplyAction="http://Microsoft.WCF.Documentation/ResponseToOCAMethod"
    )]
    string SampleMethod(string msg);

    [OperationContractAttribute(Action = "*")]
    void UnrecognizedMessageHandler(Message msg);
  }

  class SampleService : ISampleService
  {
    public string  SampleMethod(string msg)
    {
      Console.WriteLine("Called with: {0}", msg);
 	    return "The service greets you: " + msg;
    }

    public void UnrecognizedMessageHandler(Message msg)
    {
      Console.WriteLine("Unrecognized message: " + msg.ToString());
    }
  }
}
//</snippet1>

/*
//<snippet2>
<s:Envelope xmlns:a="http://schemas.xmlsoap.org/ws/2004/08/addressing" xmlns:s="http://www.w3.org/2003/05/soap-envelope">
  <s:Header>
    <a:Action s:mustUnderstand="1">http://Microsoft.WCF.Documentation/ResponseToOCAMethod</a:Action> 
  </s:Header>
  <s:Body>
    <OCAMethodResponse xmlns="http://Microsoft.WCF.Documentation">
      <OCAMethodResult>The service greets you: Hello!</OCAMethodResult> 
    </OCAMethodResponse>
  </s:Body>
</s:Envelope>
//</snippet2>
*/