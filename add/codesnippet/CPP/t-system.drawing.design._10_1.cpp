public:
   [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
   void LinkToolboxComponentsCreatingEvent( ToolboxItem^ item )
   {
      item->ComponentsCreating +=
         gcnew ToolboxComponentsCreatingEventHandler( this, &Form1::OnComponentsCreating );
   }

private:
   void OnComponentsCreating( Object^ sender, ToolboxComponentsCreatingEventArgs^ e )
   {
      // Displays ComponentsCreating event information on the Console.
      Console::WriteLine( "Name of the class of the root component of " +
         "the designer host receiving new components: " +
         e->DesignerHost->RootComponentClassName );
   }