public:
   void LinkResolveNameEvent( IDesignerSerializationManager^ serializationManager )
   {
      // Registers an event handler for the ResolveName event.
      serializationManager->ResolveName +=
         gcnew ResolveNameEventHandler( this, &Form1::OnResolveName );
   }

private:
   void OnResolveName( Object^ sender, ResolveNameEventArgs^ e )
   {
      // Displays ResolveName event information on the console.
      Console::WriteLine( "Name of the name to resolve: " + e->Name );
      Console::WriteLine( "ToString output of the Object that no name was resolved for: " +
         e->Value );
   }