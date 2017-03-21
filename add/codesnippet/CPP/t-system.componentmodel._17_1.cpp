   public:
      // This example method creates a ComponentChangingEventArgs using the specified arguments.
      // Typically, this type of event args is created by a design mode subsystem.
      ComponentChangingEventArgs^ CreateComponentChangingEventArgs( Object^ component, MemberDescriptor^ member )
      {
         // The component that is about to change:       args.Component
         // The member that is about to change:          args.Member
         return gcnew ComponentChangingEventArgs( component,member );
      }