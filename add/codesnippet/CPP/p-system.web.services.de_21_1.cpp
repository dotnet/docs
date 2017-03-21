   // Get the message part collection for each message.
   for ( int i = 0; i < myMessageCollection->Count; ++i )
   {
      Console::WriteLine( "Message      : {0}", myMessageCollection[ i ]->Name );

      // Get the message part collection.
      MessagePartCollection^ myMessagePartCollection = myMessageCollection[ i ]->Parts;

      // Display the part collection.
      for ( int k = 0; k < myMessagePartCollection->Count; k++ )
      {
         Console::WriteLine( "\t       Part Name     : {0}", myMessagePartCollection[ k ]->Name );
         Console::WriteLine( "\t       Message Name  : {0}", myMessagePartCollection[ k ]->Message->Name );
      }
      Console::WriteLine( "" );
   }