      String^ myString = nullptr;
      Operation^ myOperation = gcnew Operation;
      myDescription = ServiceDescription::Read( "Operation_2_Input_CS.wsdl" );
      array<Message^>^myMessage = gcnew array<Message^>(myDescription->Messages->Count);

      // Copy the messages from the service description.
      myDescription->Messages->CopyTo( myMessage, 0 );
      for ( int i = 0; i < myDescription->Messages->Count; i++ )
      {
         array<MessagePart^>^myMessagePart = gcnew array<MessagePart^>(myMessage[ i ]->Parts->Count);

         // Copy the message parts into a MessagePart.
         myMessage[ i ]->Parts->CopyTo( myMessagePart, 0 );
         for ( int j = 0; j < myMessage[ i ]->Parts->Count; j++ )
         {
            myString = String::Concat( myString, myMessagePart[ j ]->Name, " " );
         }
      }

      // message part names.
      myOperation->ParameterOrderString = myString;
      array<String^>^myString1 = myOperation->ParameterOrder;
      int k = 0;
      Console::WriteLine( "The list of message part names is as follows:" );
      while ( k < 5 )
      {
         Console::WriteLine( myString1[ k ] );
         k++;
      }