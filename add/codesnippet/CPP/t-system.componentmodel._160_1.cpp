   public:
      void LinkComponentEvent( IComponentChangeService^ changeService )
      {
         // Registers an event handler for the ComponentAdded,
         // ComponentAdding, ComponentRemoved, and ComponentRemoving events.
         changeService->ComponentAdded += gcnew ComponentEventHandler(
            this, &ComponentEventHandlerExample::OnComponentEvent );
         changeService->ComponentAdding += gcnew ComponentEventHandler(
            this, &ComponentEventHandlerExample::OnComponentEvent );
         changeService->ComponentRemoved += gcnew ComponentEventHandler(
            this, &ComponentEventHandlerExample::OnComponentEvent );
         changeService->ComponentRemoving += gcnew ComponentEventHandler(
            this, &ComponentEventHandlerExample::OnComponentEvent );
      }

   private:
      void OnComponentEvent( Object^ sender, ComponentEventArgs^ e )
      {
         // Displays changed component information on the console.
         if ( e->Component->Site != nullptr )
         {
            Console::WriteLine( "Name of the component related to the event: " +
               e->Component->Site->Name );
         }
         Console::WriteLine( "Type of the component related to the event: " +
            e->Component->GetType()->FullName );
      }