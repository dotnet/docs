   // Create a Message Array.
   array<Message^>^myMessages = gcnew array<Message^>(myServiceDescription->Messages->Count);

   // Copy MessageCollection to an array.
   myServiceDescription->Messages->CopyTo( myMessages, 0 );
   Console::WriteLine( "" );
   Console::WriteLine( "Displaying Messages that were copied to Messagearray ..." );
   Console::WriteLine( "" );
   for ( int i = 0; i < myServiceDescription->Messages->Count; ++i )
      Console::WriteLine( "Message Name : {0}", myMessages[ i ]->Name );