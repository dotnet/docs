      ToolboxComponentsCreatedEventArgs^ CreateToolboxComponentsCreatedEventArgs( array<System::ComponentModel::IComponent^>^components )
      {
         ToolboxComponentsCreatedEventArgs^ e = gcnew ToolboxComponentsCreatedEventArgs( components );
         // The components that were just created        e.Components
         return e;
      }