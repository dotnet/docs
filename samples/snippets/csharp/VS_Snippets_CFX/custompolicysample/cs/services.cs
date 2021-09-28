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
      Console.WriteLine("Object {0} created.", this.objectID);
      Console.WriteLine("Session: {0}:", OperationContext.Current.SessionId);
    }

~StatefulService()
	{
    Console.WriteLine("Object {0} destroyed.", this.objectID);
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
