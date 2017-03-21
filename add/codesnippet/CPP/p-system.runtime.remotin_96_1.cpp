      // Retrieve and print information about the registered channels.
      array<IChannel^>^myIChannelArray = ChannelServices::RegisteredChannels;
      for ( int i = 0; i < myIChannelArray->Length; i++ )
      {
         Console::WriteLine( "Name of Channel: {0}", myIChannelArray[ i ]->ChannelName );
         Console::WriteLine( "Priority of Channel: {0}", myIChannelArray[ i ]->ChannelPriority );

      }