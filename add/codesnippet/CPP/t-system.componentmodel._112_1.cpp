      // This example method creates a DesignerEventArgs using the specified designer host.
      // Typically, this type of event args is created by the IDesignerEventService.
      DesignerEventArgs^ CreateComponentEventArgs( IDesignerHost^ host )
      {
         DesignerEventArgs^ args = gcnew DesignerEventArgs( host );

         // The designer host of the created or disposed document:  args.Component

         return args;
      }