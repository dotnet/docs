#using <system.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;

namespace MiscCompModSamples
{
   public ref class ComponentRenameEventHandlerExample
   {
   private:
      ComponentRenameEventHandlerExample()
      {
      }

      //<Snippet1>
   public:
      void LinkComponentRenameEvent( IComponentChangeService^ changeService )
      {
         // Registers an event handler for the ComponentRename event.
         changeService->ComponentRename += gcnew ComponentRenameEventHandler(
            this, &ComponentRenameEventHandlerExample::OnComponentRename );
      }

   private:
      void OnComponentRename( Object^ /*sender*/, ComponentRenameEventArgs^ e )
      {
         // Displayss component renamed information on the console.
         Console::WriteLine( "Type of the component that has been renamed: " +
            e->Component->GetType()->FullName );
         Console::WriteLine( "New name of the component that has been renamed: " +
            e->NewName );
         Console::WriteLine( "Old name of the component that has been renamed: " +
            e->OldName );
      }
      //</Snippet1>
   };
}
