   public:
      // This example method creates a ComponentEventArgs using the specified argument.
      // Typically, this type of event args is created by a design mode subsystem.
      ComponentEventArgs^ CreateComponentEventArgs( IComponent^ component )
      {
         // The component that is related to the event:  args.Component
         return gcnew ComponentEventArgs( component );
      }