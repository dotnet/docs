ref class CustomChannel: public BaseChannelWithProperties, public IChannelReceiverHook, public IChannelReceiver, public IChannel, public IChannelSender
{
public:

   property IServerChannelSink^ ChannelSinkChain 
   {
      // TransportSink is a private class defined within CustomChannel.
      virtual IServerChannelSink^ get()
      {
         return transportSink->NextChannelSink;
      }
   }

   // Rest of CustomChannel's implementation...