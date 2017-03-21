   public:
      void LinkComponentChangingEvent( IComponentChangeService^ changeService )
      {
         // Registers an event handler for the ComponentChanging event.
         changeService->ComponentChanging += gcnew ComponentChangingEventHandler(
            this, &ComponentChangingEventHandlerExample::OnComponentChanging );
      }

   private:
      void OnComponentChanging( Object^ sender, ComponentChangingEventArgs^ e )
      {
         // Displays changing component information on the console.
         Console::WriteLine( "Type of the component that is about to change: " +
            e->Component->GetType()->FullName );
         Console::WriteLine( "Name of the member of the component that is about to change: " +
            e->Member->Name );
      }