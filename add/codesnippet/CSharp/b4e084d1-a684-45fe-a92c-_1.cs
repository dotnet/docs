   class CustomChannel : BaseChannelWithProperties, IChannelReceiverHook,
                         IChannelReceiver, IChannel, IChannelSender {

      public void AddHookChannelUri(string channelUri) {

         if (channelUri != null) {
            string [] uris = dataStore.ChannelUris;
				
            // This implementation only allows one URI to be hooked in.
            if (uris == null) {
               string [] newUris = new string[1];
               newUris[0] = channelUri;
               dataStore.ChannelUris = newUris;
               wantsToListen = false;
            } else {
               string msg = "This channel is already listening for " +
                  "data, and can't be hooked into at this stage.";
               throw new System.Runtime.Remoting.RemotingException(msg);
            }
         }
      }
      // The rest of CustomChannel's implementation.