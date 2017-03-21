   array<Binding^>^myBindings = gcnew array<Binding^>(myServiceDescription->Bindings->Count);

   // Copy BindingCollection to an Array.
   myServiceDescription->Bindings->CopyTo( myBindings, 0 );
   Console::WriteLine( "\n\n Displaying array copied from BindingCollection" );
   for ( int i = 0; i < myServiceDescription->Bindings->Count; ++i )
   {
      Console::WriteLine( "\nBinding {0}", i );
      Console::WriteLine( "\t Name : {0}", myBindings[ i ]->Name );
      Console::WriteLine( "\t Type : {0}", myBindings[ i ]->Type );
   }