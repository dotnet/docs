Class CustomChannel
   Inherits BaseChannelWithProperties
   Implements IChannelReceiverHook, IChannelReceiver, IChannel, IChannelSender
   
   ' TransportSink is a private class defined within CustomChannel.
   Private myTransportSink As TransportSink
   
   
   Public ReadOnly Property ChannelSinkChain() As IServerChannelSink Implements IChannelReceiverHook.ChannelSinkChain
      Get
         Return myTransportSink.NextChannelSink
      End Get
   End Property
    
   ' Rest of CustomChannel's implementation...