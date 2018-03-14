#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::ComponentModel::Design::Serialization;
using namespace System::Drawing;
using namespace System::Drawing::Design;

namespace MoreEventArgsExamples
{
   public ref class EventArgsCreators
   {
      //<Snippet1>
   public:
      ResolveNameEventArgs^ CreateResolveNameEventArgs( Object^ value, String^ name )
      {
         ResolveNameEventArgs^ e = gcnew ResolveNameEventArgs( name );
         // The name to resolve                       e.Name
         // Stores an Object matching the name        e.Value
         return e;
      }
      //</Snippet1>

      //<Snippet2>
      PaintValueEventArgs^ CreatePaintValueEventArgs( System::ComponentModel::ITypeDescriptorContext^ context, Object^ value, Graphics^ graphics, Rectangle bounds )
      {
         PaintValueEventArgs^ e = gcnew PaintValueEventArgs( context, value, graphics, bounds );
         // The context of the paint value event         e.Context
         // The Object representing the value to paint   e.Value
         // The graphics to use to paint                 e.Graphics
         // The rectangle in which to paint              e.Bounds
         return e;
      }
      //</Snippet2>

      //<Snippet3>
      ToolboxComponentsCreatedEventArgs^ CreateToolboxComponentsCreatedEventArgs( array<System::ComponentModel::IComponent^>^components )
      {
         ToolboxComponentsCreatedEventArgs^ e = gcnew ToolboxComponentsCreatedEventArgs( components );
         // The components that were just created        e.Components
         return e;
      }
      //</Snippet3>

      //<Snippet4>
      ToolboxComponentsCreatingEventArgs^ CreateToolboxComponentsCreatingEventArgs( System::ComponentModel::Design::IDesignerHost^ host )
      {
         ToolboxComponentsCreatingEventArgs^ e = gcnew ToolboxComponentsCreatingEventArgs( host );
         // The designer host of the document receiving the components        e.DesignerHost
         return e;
      }
      //</Snippet4>
   };
}

[STAThread]
int main(){}
