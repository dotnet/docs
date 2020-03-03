#using <system.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;

namespace MiscCompModSamples
{
   public ref class ComponentChangedEventHandlerExample
   {
   private:
      ComponentChangedEventHandlerExample(){}

      //<Snippet1>
   public:
      void LinkComponentChangedEvent( IComponentChangeService^ changeService )
      {
         // Registers an event handler for the ComponentChanged event.
         changeService->ComponentChanged += gcnew ComponentChangedEventHandler(
            this, &ComponentChangedEventHandlerExample::OnComponentChanged );
      }

   private:
      void OnComponentChanged( Object^ sender, ComponentChangedEventArgs^ e )
      {
         // Displays changed component information on the console.
         Console::WriteLine( "Type of the component that has changed: " +
            e->Component->GetType()->FullName );
         Console::WriteLine( "Name of the member of the component that has changed: " +
            e->Member->Name );
         Console::WriteLine( "Old value of the member: " + e->OldValue );
         Console::WriteLine( "New value of the member: " + e->NewValue );
      }
      //</Snippet1>
   };
}
