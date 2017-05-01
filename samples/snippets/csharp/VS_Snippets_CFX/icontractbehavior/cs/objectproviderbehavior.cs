// <snippet4>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;

namespace Microsoft.WCF.Documentation
{
  // <snippet1>
  public class ObjectProviderBehavior : IInstanceProvider
  {

    string message;
    SampleService service = null;

    public ObjectProviderBehavior(string msg)
    {
      Console.WriteLine("The non-default constructor has been called.");
      this.message = msg;
      this.service = new SampleService("Singleton sample service.");
    }

    #region IInstanceProvider Members

    public object GetInstance(InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
    {
      Console.WriteLine("GetInstance is called:");
      return this.service;
    }

    public object GetInstance(InstanceContext instanceContext)
    {
      Console.WriteLine("GetInstance is called:");
      return this.service;
    }

    public void ReleaseInstance(InstanceContext instanceContext, object instance)
    {
      Console.WriteLine("ReleaseInstance is called. The SingletonBehaviorAttribute never releases.");
    }

    #endregion
  }
  // </snippet1>

  // <snippet2>
  public class SingletonBehaviorAttribute : Attribute, IContractBehaviorAttribute, IContractBehavior
  {

    #region IContractBehaviorAttribute Members

    public Type TargetContract
    {
      get { return typeof(ISampleService); }
    }

    #endregion

    #region IContractBehavior Members

    public void AddBindingParameters(ContractDescription description, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection parameters)
    {
      return;
    }

    public void ApplyClientBehavior(ContractDescription description, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
      return;
    }

    public void ApplyDispatchBehavior(ContractDescription description, ServiceEndpoint endpoint, DispatchRuntime dispatch)
    {
      dispatch.InstanceProvider = new ObjectProviderBehavior("Custom ObjectProviderBehavior constructor.");
    }

    public void Validate(ContractDescription description, ServiceEndpoint endpoint)
    {
      return;
    }

    #endregion
  }
  // </snippet2>
}
// </snippet4>
