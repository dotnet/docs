#using <system.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;

namespace MiscCompModSamples
{
   public ref class ComponentRenameEventArgsExample
   {
   public:
      ComponentRenameEventArgsExample()
      {
      }

      //<Snippet1>
   public:
      // This example method creates a ComponentRenameEventArgs using the specified arguments.
      // Typically, this type of event args is created by a design mode subsystem.
      ComponentRenameEventArgs^ CreateComponentRenameEventArgs( Object^ component, String^ oldName, String^ newName )
      {
         // The component that was renamed:          args.Component
         // The previous name of the component:      args.OldName
         // The new name of the component:           args.NewName
         return gcnew ComponentRenameEventArgs( component, oldName, newName );
      }
      //</Snippet1>
   };
}
