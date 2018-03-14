#using <system.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;

namespace MiscCompModSamples
{
   public ref class ActiveDesignerEventHandlerExample
   {
   private:
      ActiveDesignerEventHandlerExample()
      {
      }

      //<Snippet1>
   public:
      void LinkActiveDesignerEvent( IDesignerEventService^ eventService )
      {
         // Registers an event handler for the ActiveDesignerChanged event.
         eventService->ActiveDesignerChanged += gcnew ActiveDesignerEventHandler( this, &MiscCompModSamples::ActiveDesignerEventHandlerExample::OnActiveDesignerEvent );
      }

   private:
      void OnActiveDesignerEvent( Object^ /*sender*/, ActiveDesignerEventArgs^ e )
      {
         // Displays changed designer information on the console.
         if ( e->NewDesigner->RootComponent->Site != nullptr )
         {
            Console::WriteLine( "Name of the component of the new active designer: {0}", e->NewDesigner->RootComponent->Site->Name );
         }
         Console::WriteLine( "Type of the component of the new active designer: {0}", e->NewDesigner->RootComponentClassName );
         if ( e->OldDesigner->RootComponent->Site != nullptr )
         {
            Console::WriteLine( "Name of the component of the previously active designer: {0}", e->OldDesigner->RootComponent->Site->Name );
         }
         Console::WriteLine( "Type of the component of the previously active designer: {0}", e->OldDesigner->RootComponentClassName );
      }
      //</Snippet1>
   };
}
