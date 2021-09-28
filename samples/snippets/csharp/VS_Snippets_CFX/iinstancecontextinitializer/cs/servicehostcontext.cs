﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  class ServiceHostContext : IExtension<ServiceHostBase>, IDisposable
  {
    Guid id;

    public ServiceHostContext()
    {
      this.id = Guid.NewGuid();
    }

    public string ID
    {
      get { return this.id.ToString(); }
    }

    #region IExtension<ServiceHost> Members

    public void Attach(ServiceHostBase owner)
    {
      Console.WriteLine("Attached to new ServiceHost.");
    }

    public void Detach(ServiceHostBase owner)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region IDisposable Members

    public void Dispose()
    {
      Console.WriteLine("Destroying service host: " + this.id);
    }

    #endregion
  }

  public class ServiceHostContextBehavior : IServiceBehavior
  {
    #region IServiceBehavior Members

    public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
    {
      ;
    }

    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
      serviceHostBase.Extensions.Add(new ServiceHostContext());
    }

    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
      ;
    }

    #endregion
  }

  public class ServiceHostContextBehaviorElement : System.ServiceModel.Configuration.BehaviorExtensionElement
  {
    public override Type BehaviorType
    {
      get { return typeof(ServiceHostContextBehavior); }
    }

    protected override object CreateBehavior()
    {
      return new ServiceHostContextBehavior();
    }
  }
}
