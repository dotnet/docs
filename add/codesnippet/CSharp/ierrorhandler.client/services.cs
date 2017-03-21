// <snippet1>
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(Namespace="http://microsoft.wcf.documentation")]
  public interface ISampleService{
    [OperationContract]
    [FaultContractAttribute(typeof(GreetingFault))]
    string SampleMethod(string msg);
  }
 
  [DataContractAttribute]
  public class GreetingFault
  { 
    private string report;

    public GreetingFault(string message)
    {
      this.report = message;
    }

    [DataMemberAttribute]
    public string Message
    {
      get { return this.report; }
      set { this.report = value; }
    }
  }

  class SampleService : ISampleService
  {
    public string  SampleMethod(string msg)
    {
      Console.WriteLine("Client said: " + msg);
      // Note: Not a contractually specified exception. If 
      // ServiceBehaviorAttribute.IncludeExceptionDetailInFaults is set to true,
      // this fault is experienced on a WCF client as a FaultException.
      throw new Exception("A Greeting error occurred. You said: " + msg);
    }
  }
}
// </snippet1>

/* <snippet8>
The service output is: 

EnforceGreetingFaultBehavior created.
Validate is called.
The EnforceGreetingFaultBehavior has been applied.
The service is ready.
Press <ENTER> to terminate service.
Client said: Why Hello there!
ProvideFault called. Converting Exception to GreetingFault....
HandleError called.

And the client output is:
 
Enter the greeting to send:
Why Hello there!
A Greeting error occurred. You said: Why Hello there!
Done!
*/ //</snippet8> 

