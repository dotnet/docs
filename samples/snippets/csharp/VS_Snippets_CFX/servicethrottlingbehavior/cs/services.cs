// <snippet2>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(Namespace="http://microsoft.wcf.documentation")]
  public interface ISampleService{
    [OperationContract]
    string SampleMethod(string msg);
  }

  class SampleService : ISampleService
  {
  #region ISampleService Members

  public string  SampleMethod(string msg)
  {
    ServiceThrottle currentThrottle = OperationContext.Current.EndpointDispatcher.ChannelDispatcher.ServiceThrottle;
    Console.WriteLine("Service called. Current throttle values: " );
    Console.WriteLine("MaxConcurrentCalls: {0}.", currentThrottle.MaxConcurrentCalls.ToString());
    Console.WriteLine("MaxConnections: {0}.", currentThrottle.MaxConcurrentSessions.ToString());
    Console.WriteLine("MaxInstances: {0}.", currentThrottle.MaxConcurrentInstances.ToString());
 	  return "The service greets you: " + msg;
  }

  #endregion
  }
}
// </snippet2>
