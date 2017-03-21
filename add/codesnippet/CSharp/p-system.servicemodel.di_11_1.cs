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