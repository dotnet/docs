using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  [ServiceContractAttribute(Namespace="http://microsoft.wcf.documentation")]
  public interface ISampleService{

    [OperationContractAttribute]
    [FaultContractAttribute(typeof(SampleFault))]
    string SampleMethod(string msg);
  }

  class SampleService : ISampleService
  {
    public string  SampleMethod(string msg)
    {
      Console.WriteLine($"The caller said: \"{msg}\"");
 	    return "The service greets you: " + msg;
    }
  }

  // The detail type of the specified SOAP fault.
  [DataContractAttribute(Namespace = "http://microsoft.wcf.documentation")]
  public class SampleFault
  {
    [DataMemberAttribute(Name="FaultMessage")]
    private string msg;

    public string FaultMessage
    {
      get { return this.msg; }
      set { this.msg = value; }
    }
  }
}
