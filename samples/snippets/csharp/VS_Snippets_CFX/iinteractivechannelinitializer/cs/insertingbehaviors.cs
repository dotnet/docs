// <snippet5>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  public class InspectorInserter : BehaviorExtensionElement, IServiceBehavior, IEndpointBehavior, IOperationBehavior
  {
    #region IServiceBehavior Members

    public void AddBindingParameters(
      ServiceDescription serviceDescription, 
      ServiceHostBase serviceHostBase, 
      System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, 
      BindingParameterCollection bindingParameters
    )
    { return; }

    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
      foreach (ChannelDispatcher chDisp in serviceHostBase.ChannelDispatchers)
      {
        foreach (EndpointDispatcher epDisp in chDisp.Endpoints)
        {
          epDisp.DispatchRuntime.MessageInspectors.Add(new Inspector());
          foreach (DispatchOperation op in epDisp.DispatchRuntime.Operations)
            op.ParameterInspectors.Add(new Inspector());
        }
      }
    }

    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase){ return; }

    #endregion
    //<snippet2>
    #region IEndpointBehavior Members
    public void AddBindingParameters(
      ServiceEndpoint endpoint, BindingParameterCollection bindingParameters
    ) { return; }
    //<snippet10>
    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
      clientRuntime.InteractiveChannelInitializers.Add(new InteractiveChannelInitializer());
      clientRuntime.MessageInspectors.Add(new Inspector());
      foreach (ClientOperation op in clientRuntime.Operations)
        op.ParameterInspectors.Add(new Inspector());
    }
    //</snippet10>

    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    {
      endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new Inspector());
      foreach (DispatchOperation op in endpointDispatcher.DispatchRuntime.Operations)
        op.ParameterInspectors.Add(new Inspector());
    }

    public void Validate(ServiceEndpoint endpoint){ return; }
    //</snippet2>
    #endregion

    #region IOperationBehavior Members
    public void AddBindingParameters(
      OperationDescription operationDescription, BindingParameterCollection bindingParameters
    )
    { return; }

    public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
    {
      clientOperation.ParameterInspectors.Add(new Inspector());
    }

    public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
    {
      dispatchOperation.ParameterInspectors.Add(new Inspector());
    }

    public void Validate(OperationDescription operationDescription){ return; }

    #endregion

    public override Type BehaviorType
    {
      get { return typeof(InspectorInserter); }
    }

    protected override object CreateBehavior()
    { return new InspectorInserter(); }
  }
}
// </snippet5>
