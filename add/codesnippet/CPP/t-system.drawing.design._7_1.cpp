public:
   [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
   void LinkToolboxComponentsCreatedEvent( ToolboxItem^ item )
   {
      item->ComponentsCreated +=
         gcnew ToolboxComponentsCreatedEventHandler( this, &Form1::OnComponentsCreated );
   }

private:
   void OnComponentsCreated( Object^ sender, ToolboxComponentsCreatedEventArgs^ e )
   {
      // Lists created components on the Console.
      for ( int i = 0; i < e->Components->Length; i++ )
      {
         Console::WriteLine( "Component #" + i + ": " +
            e->Components[ i ]->Site->Name );
      }
   }