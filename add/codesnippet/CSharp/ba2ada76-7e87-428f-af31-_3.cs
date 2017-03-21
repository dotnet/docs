    // BehaviorExtensionElement members
    public override Type BehaviorType
    {
      get { return typeof(EndpointBehaviorMessageInspector); }
    }

    protected override object CreateBehavior()
    {
      return new EndpointBehaviorMessageInspector();
    }