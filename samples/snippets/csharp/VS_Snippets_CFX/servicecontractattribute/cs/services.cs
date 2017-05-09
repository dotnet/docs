// <snippet1>
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(
    Namespace="http://microsoft.wcf.documentation",
    Name="SampleService",
    ProtectionLevel=ProtectionLevel.EncryptAndSign
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
