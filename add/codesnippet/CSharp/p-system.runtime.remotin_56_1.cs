class CustomChannel : BaseChannelWithProperties, IChannelReceiverHook,
   IChannelReceiver, IChannel, IChannelSender {

   // TransportSink is a private class defined within CustomChannel.
   TransportSink transportSink;

   public IServerChannelSink ChannelSinkChain {
      get { return transportSink.NextChannelSink; }
   }

   // Rest of CustomChannel's implementation...