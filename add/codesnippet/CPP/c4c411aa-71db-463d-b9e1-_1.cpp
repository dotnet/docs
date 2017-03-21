      array<String^>^channelUri = gcnew array<String^>(5);
      IChannelDataStore^ myIChannelDataStore = gcnew ChannelDataStore( channelUri );
      IChannelDataStore^ myIChannelDataStore1 = gcnew ChannelDataStore( channelUri );
      myIServerChannelSinkProvider->GetChannelData( myIChannelDataStore );
      myIServerChannelSinkProvider1->GetChannelData( myIChannelDataStore1 );