   for ( int i = 0; i < myServiceDescription->Bindings->Count; ++i )
   {
      Console::WriteLine( "\nBinding {0}", i );

      // Get Binding at index i.
      myBinding = myServiceDescription->Bindings[ i ];
      Console::WriteLine( "\t Name : {0}", myBinding->Name );
      Console::WriteLine( "\t Type : {0}", myBinding->Type );
   }