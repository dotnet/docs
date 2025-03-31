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
    Console.WriteLine($"MaxConcurrentCalls: {currentThrottle.MaxConcurrentCalls.ToString()}.");
    Console.WriteLine($"MaxConnections: {currentThrottle.MaxConcurrentSessions.ToString()}.");
    Console.WriteLine($"MaxInstances: {currentThrottle.MaxConcurrentInstances.ToString()}.");
 	  return "The service greets you: " + msg;
  }

  #endregion
  }
}
// </snippet2>
