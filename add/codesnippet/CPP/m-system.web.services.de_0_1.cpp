      // Get another message from ServiceDescription.
      Message^ myMessage2 = myServiceDescription->Messages[ "DivideHttpGetOut" ];
      MessagePart^ myMessagePart = myMessage2->FindPartByName( "Body" );
      Console::WriteLine( "Results of FindPartByName operation:" );
      Console::WriteLine( "Part Name: {0}", myMessagePart->Name );
      Console::WriteLine( "Part Element: {0}", myMessagePart->Element );