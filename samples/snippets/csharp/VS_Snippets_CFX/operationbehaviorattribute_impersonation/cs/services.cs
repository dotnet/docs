// <snippet1>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(
    Name="SampleHello",
    Namespace="http://microsoft.wcf.documentation"
  )]
  public interface IHello
  {
    [OperationContract]
    string Hello(string greeting);
  }

  public class HelloService : IHello
  {

    public HelloService()
    {
      Console.WriteLine("Service object created: " + this.GetHashCode().ToString());
    }

    ~HelloService()
    {
      Console.WriteLine("Service object destroyed: " + this.GetHashCode().ToString());
    }

    [OperationBehavior(Impersonation=ImpersonationOption.Required)]
    public string Hello(string greeting)
    {
      Console.WriteLine("Called by: " + Thread.CurrentPrincipal.Identity.Name);
      Console.WriteLine("IsAuthenticated: " + Thread.CurrentPrincipal.Identity.IsAuthenticated.ToString());
      Console.WriteLine("AuthenticationType: " + Thread.CurrentPrincipal.Identity.AuthenticationType.ToString());

      Console.WriteLine("Caller sent: " + greeting);
      Console.WriteLine("Sending back: Hi, " + Thread.CurrentPrincipal.Identity.Name);
      return "Hi, " + Thread.CurrentPrincipal.Identity.Name;
    }
  }
}
// </snippet1>
