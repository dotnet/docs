// <snippet3>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(Namespace="http://microsoft.wcf.documentation")]
  public interface ISampleService{
    [OperationContract]
    string SampleMethod(string msg);
  }

  [SingletonBehavior]
  public class SampleService : ISampleService
  {
  #region ISampleService Members
    string message;

    public SampleService(string msg)
    {
      this.message = msg;
    }

  public string  SampleMethod(string msg)
  {
    Console.WriteLine("The caller said: " + msg);
 	  return this.message;
  }

  #endregion
  }
}
// </snippet3>
