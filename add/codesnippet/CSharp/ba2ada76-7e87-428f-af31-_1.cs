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