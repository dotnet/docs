// <snippet1>
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(Namespace="http://microsoft.wcf.documentation")]
  public interface ISampleService{
    // <snippet4>
    [OperationContract]
    [FaultContractAttribute(
      typeof(GreetingFault),
      Action="http://www.contoso.com/GreetingFault",
      ProtectionLevel=ProtectionLevel.EncryptAndSign
      )]
    string SampleMethod(string msg);
    // </snippet4>
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
  #region ISampleService Members

  public string  SampleMethod(string msg)
  {
    Console.WriteLine("Client said: " + msg);
    // Generate intermittent error behavior.
    Random rnd = new Random(DateTime.Now.Millisecond);
    int test = rnd.Next(5);
    if (test % 2 != 0)
      return "The service greets you: " + msg; 
    else
      // <snippet5>
      throw new FaultException<GreetingFault>(new GreetingFault("A Greeting error occurred. You said: " + msg));
      // </snippet5>
  }

  #endregion
  }
}
// </snippet1>
