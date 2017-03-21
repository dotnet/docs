      ToolboxComponentsCreatingEventArgs^ CreateToolboxComponentsCreatingEventArgs( System::ComponentModel::Design::IDesignerHost^ host )
      {
         ToolboxComponentsCreatingEventArgs^ e = gcnew ToolboxComponentsCreatingEventArgs( host );
         // The designer host of the document receiving the components        e.DesignerHost
         return e;
      }