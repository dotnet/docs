using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(
    Namespace="http://microsoft.wcf.documentation",
    SessionMode=SessionMode.Required
  )]
  public interface IStatefulService
  {
    [OperationContract]
    string GetSessionID();
  }

  [ServiceBehavior(
    InstanceContextMode = InstanceContextMode.PerSession
  )]
  public class StatefulService : IStatefulService
  {

    private string objectID = null;

    StatefulService()
    {
      this.objectID = Guid.NewGuid().ToString();
      Console.WriteLine($"Object {this.objectID} created.");
      Console.WriteLine($"Session: {OperationContext.Current.SessionId}:");
    }

~StatefulService()
	{
    Console.WriteLine($"Object {this.objectID} destroyed.");
	}

    #region IStatefulService Members

    public string GetSessionID()
    {
      return String.Format(
        "{0}\r\n{1}\r\n",
        OperationContext.Current.SessionId,
        "objectID: " + this.objectID);
    }

    #endregion
  }
}
