ref class CustomChannel: public BaseChannelWithProperties, public IChannelReceiverHook, public IChannelReceiver, public IChannel, public IChannelSender
{
public:
   virtual void AddHookChannelUri( String^ channelUri )
   {
      if ( channelUri != nullptr )
      {
         array<String^>^uris = dataStore->ChannelUris;

         // This implementation only allows one URI to be hooked in.
         if ( uris == nullptr )
         {
            array<String^>^newUris = gcnew array<String^>(1);
            newUris[ 0 ] = channelUri;
            dataStore->ChannelUris = newUris;
            wantsToListen = false;
         }
         else
         {
            String^ msg = "This channel is already listening for data, and can't be hooked into at this stage.";
            throw gcnew System::Runtime::Remoting::RemotingException( msg );
         }
      }
   }

   // The rest of CustomChannel's implementation.