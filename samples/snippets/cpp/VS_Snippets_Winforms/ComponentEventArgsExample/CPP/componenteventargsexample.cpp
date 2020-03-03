#using <system.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;

namespace MiscCompModSamples
{
   public ref class ComponentEventArgsExample
   {
   public:
      ComponentEventArgsExample()
      {
      }

      //<Snippet1>
   public:
      // This example method creates a ComponentEventArgs using the specified argument.
      // Typically, this type of event args is created by a design mode subsystem.
      ComponentEventArgs^ CreateComponentEventArgs( IComponent^ component )
      {
         // The component that is related to the event:  args.Component
         return gcnew ComponentEventArgs( component );
      }
      //</Snippet1>
   };
}
