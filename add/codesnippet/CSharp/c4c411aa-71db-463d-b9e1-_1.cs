      string[] channelUri = new String[5];
      IChannelDataStore myIChannelDataStore  = new ChannelDataStore(channelUri);
      IChannelDataStore myIChannelDataStore1 = new ChannelDataStore(channelUri);
      myIServerChannelSinkProvider.GetChannelData(myIChannelDataStore);
      myIServerChannelSinkProvider1.GetChannelData(myIChannelDataStore1);