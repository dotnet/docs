// <snippet1>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(
    Name = "SampleDuplexHello",
    Namespace = "http://microsoft.wcf.documentation",
    CallbackContract = typeof(IHelloCallbackContract),
    SessionMode = SessionMode.Required
  )]
  public interface IDuplexHello
  {
    [OperationContract(IsOneWay = true)]
    void Hello(string greeting);
  }

  public interface IHelloCallbackContract
  {
    [OperationContract(IsOneWay = true)]
    void Reply(string responseToGreeting);
  }

  [ServiceBehaviorAttribute(InstanceContextMode=InstanceContextMode.PerSession)]
  public class DuplexHello : IDuplexHello
  {

    public DuplexHello()
    {
      Console.WriteLine("Service object created: " + this.GetHashCode().ToString());
    }

    ~DuplexHello()
    {
      Console.WriteLine("Service object destroyed: " + this.GetHashCode().ToString());
    }

    public void Hello(string greeting)
    {
      Console.WriteLine("Caller sent: " + greeting);
      Console.WriteLine("Session ID: " + OperationContext.Current.SessionId);
      Console.WriteLine("Waiting two seconds before returning call.");
      // Put a slight delay to demonstrate asynchronous behavior on client.
      Thread.Sleep(2000);
      IHelloCallbackContract callerProxy
        = OperationContext.Current.GetCallbackChannel<IHelloCallbackContract>();
      string response = "Service object " + this.GetHashCode().ToString() + " received: " + greeting;
      Console.WriteLine("Sending back: " + response);
      callerProxy.Reply(response);
    }
  }
}
// </snippet1>
