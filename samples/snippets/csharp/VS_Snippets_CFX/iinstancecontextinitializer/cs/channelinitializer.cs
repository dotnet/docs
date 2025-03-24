using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  public class ChannelInitializer : IChannelInitializer
  {
    #region IChannelInitializer Members

    public void Initialize(IClientChannel channel)
    {
      Console.WriteLine("IClientChannel.Initialize called.");
      channel.Extensions.Add(new ChannelTrackerExtension());
    }
    #endregion
  }

  public class ChannelTrackerExtension : IExtension<IContextChannel>
  {
    String instanceId;
    IContextChannel channel;

    public ChannelTrackerExtension()
    {
      this.instanceId = Guid.NewGuid().ToString();
    }

    public String InstanceId
    {
      get
      { return this.instanceId; }
    }

    public int ChannelHashCode
    {
      get
      {
        if (this.channel != null)
          return this.channel.GetHashCode();
        else
          return 0;
      }
    }

    #region IExtension<IContextChannel> Members

    public void Attach(IContextChannel owner)
    {
      Console.WriteLine($"Attached to new IContextChannel {owner.GetHashCode()}.");
      this.channel = owner;
    }

    public void Detach(IContextChannel owner)
    {
      Console.WriteLine($"Detached from IContextChannel {owner.GetHashCode()}.");
    }

    #endregion
  }

  public class ChannelTrackerExtensionBehavior : IEndpointBehavior
  {
    #region IEndpointBehavior Members

    public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
    {
      ;
    }

    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
      Console.WriteLine("Channel tracker added.");
      clientRuntime.ChannelInitializers.Add(new ChannelInitializer());
    }

    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    {
      Console.WriteLine("Channel tracker added.");
      endpointDispatcher.ChannelDispatcher.ChannelInitializers.Add(new ChannelInitializer());
    }

    public void Validate(ServiceEndpoint endpoint)
    {
      ;
    }

    #endregion
  }
public class ChannelTrackerExtensionBehaviorElement : System.ServiceModel.Configuration.BehaviorExtensionElement
  {
    public override Type BehaviorType
    {
      get { return typeof(ChannelTrackerExtensionBehavior); }
    }

    protected override object CreateBehavior()
    {
      return new ChannelTrackerExtensionBehavior();
    }
  }
}
