// <snippet1>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(
    Name="HelloWorld",
    Namespace="http://Microsoft.WCF.Documentation"
  )]
  public interface ISampleService{
    [OperationContract]
    string SampleMethod(string msg);
  }

  class SampleService : ISampleService
  {
  #region ISampleService Members

  public string  SampleMethod(string msg)
  {
 	  return "The service greets you: " + msg;
  }

  #endregion
  }
}
// </snippet1>
