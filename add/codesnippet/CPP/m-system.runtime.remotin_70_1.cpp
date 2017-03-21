      // Extract the channel URI and the remote well known object URI from the specified URL.
      Console::WriteLine( "Parsed : {0}", myHttpServerChannel->Parse( String::Concat( myHttpServerChannel->GetChannelUri(), "/SayHello" ),  myString ) );
      Console::WriteLine( "Remote WellKnownObject : {0}", myString );
      Console::WriteLine( "Hit <enter> to stop listening..." );
      Console::ReadLine();

      // Stop listening to channel.
      myHttpServerChannel->StopListening( myPort );