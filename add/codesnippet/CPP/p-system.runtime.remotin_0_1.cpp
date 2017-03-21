      int myPort = 8085;

      // Creating the 'IDictionary' to set the server object properties.
      IDictionary^ myDictionary = gcnew Hashtable;
      myDictionary[ "name" ] = "MyServerChannel1";
      myDictionary[ "priority" ] = 2;
      myDictionary[ "port" ] = 8085;

      // Set the properties along with the constructor.
      HttpServerChannel^ myHttpServerChannel = gcnew HttpServerChannel( myDictionary,gcnew BinaryServerFormatterSinkProvider );

      // Register the server channel.
      ChannelServices::RegisterChannel( myHttpServerChannel );
      RemotingConfiguration::RegisterWellKnownServiceType( MyHelloServer::typeid, "SayHello", WellKnownObjectMode::SingleCall );
      myHttpServerChannel->WantsToListen = true;

      // Start listening on a specific port.
      myHttpServerChannel->StartListening( myPort );

      // Get the name of the channel.
      Console::WriteLine( "ChannelName : {0}", myHttpServerChannel->ChannelName );

      // Get the channel priority.
      Console::WriteLine( "ChannelPriority : {0}", myHttpServerChannel->ChannelPriority );

      // Get the schema of the channel.
      Console::WriteLine( "ChannelScheme : {0}", myHttpServerChannel->ChannelScheme );

      // Get the channel URI.
      Console::WriteLine( "GetChannelUri : {0}", myHttpServerChannel->GetChannelUri() );

      // Indicates whether 'IChannelReceiverHook' wants to be hooked into the outside listener service.
      Console::WriteLine( "WantsToListen : {0}", myHttpServerChannel->WantsToListen );