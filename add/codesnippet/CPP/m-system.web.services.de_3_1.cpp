      // Get message from ServiceDescription.
      Message^ myMessage1 = myServiceDescription->Messages[ "AddHttpPostIn" ];
      Console::WriteLine( "ServiceDescription : {0}", myMessage1->ServiceDescription );
      
      array<String^>^myParts = gcnew array<String^>(2);
      myParts[ 0 ] = "a";
      myParts[ 1 ] = "b";
      array<MessagePart^>^myMessageParts = myMessage1->FindPartsByName( myParts );
      Console::WriteLine( "Results of FindPartsByName operation:" );
      for ( int i = 0; i < myMessageParts->Length; ++i )
      {
         Console::WriteLine( "Part Name: {0}", myMessageParts[ i ]->Name );
         Console::WriteLine( "Part Type: {0}", myMessageParts[ i ]->Type );
      }