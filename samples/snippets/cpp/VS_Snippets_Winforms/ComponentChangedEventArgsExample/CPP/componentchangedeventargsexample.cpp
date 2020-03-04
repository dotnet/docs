#using <system.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;

public ref class ComponentChangedEventArgsExample
{
public:
   ComponentChangedEventArgsExample(){}

   //<Snippet1>
public:
   // This example method creates a ComponentChangedEventArgs using the specified arguments.
   // Typically, this type of event args is created by a design mode subsystem.
   ComponentChangedEventArgs^ CreateComponentChangedEventArgs( Object^ component, MemberDescriptor^ member, Object^ oldValue, Object^ newValue )
   {
      // Creates a component changed event args with the specified arguments.
      ComponentChangedEventArgs^ args = gcnew ComponentChangedEventArgs( component, member, oldValue, newValue );
      
      // The component that has changed:              args->Component
      // The member of the component that changed:    args->Member
      // The old value of the member:                 args->oldValue
      // The new value of the member:                 args->newValue
      return args;
   }
   //</Snippet1>
};
