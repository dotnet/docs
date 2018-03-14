using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  [ServiceContractAttribute(
    Namespace="http://microsoft.wcf.documentation",
    SessionMode=SessionMode.Required
  )]
  public interface ISampleService{

    [OperationContractAttribute]
    [FaultContractAttribute(typeof(SampleFault))]
    string SampleMethod(string msg);
  }
  // <snippet1>
  class SampleService : ISampleService
  {
    private Guid id;
    private string session;

    public SampleService()
    {
      id = Guid.NewGuid();
      session = OperationContext.Current.SessionId;
      Console.WriteLine("Object {0} has been created.", id);
      Console.WriteLine("For session {0}", session);
    }
    [OperationBehavior(
            ReleaseInstanceMode=ReleaseInstanceMode.BeforeAndAfterCall
    )]
    public string  SampleMethod(string msg)
    {
      Console.WriteLine("The caller said: \"{0}\"", msg);
      Console.WriteLine("For session {0}", OperationContext.Current.SessionId);
      return "The service greets you: " + msg;
    }

    ~SampleService()
    {
      Console.WriteLine("Object {0} has been destroyed.", id);
      Console.WriteLine("For session {0}", session);
    }
  }
  // </snippet1>

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
