#using <system.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;

namespace MiscCompModSamples
{
   public ref class DesignerEventHandlerExample
   {
   private:
      DesignerEventHandlerExample()
      {
      }

      //<Snippet1>
   public:
      void LinkDesignerEvent( IDesignerEventService^ eventService )
      {
         // Registers an event handler for the DesignerCreated and DesignerDisposed events.
         eventService->DesignerCreated += gcnew DesignerEventHandler(
            this, &DesignerEventHandlerExample::OnDesignerEvent );
         eventService->DesignerDisposed += gcnew DesignerEventHandler(
            this, &DesignerEventHandlerExample::OnDesignerEvent );
      }

   private:
      void OnDesignerEvent( Object^ sender, DesignerEventArgs^ e )
      {
         // Displays designer event information on the console.
         Console::WriteLine( "Name of the root component of the created or disposed designer: " +
            e->Designer->RootComponentClassName );
      }
      //</Snippet1>
   };
}
