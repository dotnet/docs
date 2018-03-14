
// <snippet1>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  class EndpointBehaviorMessageInspector : BehaviorExtensionElement, IEndpointBehavior, IDispatchMessageInspector, IClientMessageInspector
  {
    //<snippet4>
    // IEndpointBehavior Members
    public void AddBindingParameters(ServiceEndpoint serviceEndpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
    {
      return;
    }

    public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime behavior)
    {
      behavior.MessageInspectors.Add(new EndpointBehaviorMessageInspector());
    }

    public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
    {
      endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new EndpointBehaviorMessageInspector());
    }

    public void Validate(ServiceEndpoint serviceEndpoint)
    {
      return;
    }
    //</snippet4>

    //<snippet3>
    // BehaviorExtensionElement members
    public override Type BehaviorType
    {
      get { return typeof(EndpointBehaviorMessageInspector); }
    }

    protected override object CreateBehavior()
    {
      return new EndpointBehaviorMessageInspector();
    }
    //</snippet3>

    //<snippet2>
    // IDispatchMessageInspector Members

    public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel, InstanceContext instanceContext)
    {
      Console.WriteLine("AfterReceiveRequest called.");
      return null;
    }

    public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
    {
      Console.WriteLine("BeforeSendReply called.");
    }
    //</snippet2>


    #region IClientMessageInspector Members

    public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
    {
      Console.WriteLine("AfterReceiveReply called.");
    }

    public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
    {
      Console.WriteLine("BeforeSendRequest called.");
      return null;
    }

    #endregion
  }
}
// </snippet1>
