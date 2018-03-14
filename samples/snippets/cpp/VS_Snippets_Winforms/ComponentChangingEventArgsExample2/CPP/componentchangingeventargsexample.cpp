#using <system.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;

namespace MiscCompModSamples
{
   public ref class ComponentChangingEventArgsExample
   {
   public:
      ComponentChangingEventArgsExample(){}

      //<Snippet1>
   public:
      // This example method creates a ComponentChangingEventArgs using the specified arguments.
      // Typically, this type of event args is created by a design mode subsystem.
      ComponentChangingEventArgs^ CreateComponentChangingEventArgs( Object^ component, MemberDescriptor^ member )
      {
         // The component that is about to change:       args.Component
         // The member that is about to change:          args.Member
         return gcnew ComponentChangingEventArgs( component,member );
      }
      //</Snippet1>
   };
}
