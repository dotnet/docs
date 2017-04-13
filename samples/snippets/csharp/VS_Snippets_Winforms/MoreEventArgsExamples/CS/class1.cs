using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;

namespace MoreEventArgsExamples
{
	class Class1
	{
		[STAThread]
		static void Main(string[] args)
		{

		}
	}

    public class EventArgsCreators
    {
        //<Snippet1>
        public ResolveNameEventArgs CreateResolveNameEventArgs(object value, string name)        
        {           
            ResolveNameEventArgs e = new ResolveNameEventArgs(name);
            // The name to resolve                       e.Name       
            // Stores an object matching the name        e.Value            
            return e;
        }
        //</Snippet1>

        //<Snippet2>
        public PaintValueEventArgs CreatePaintValueEventArgs(System.ComponentModel.ITypeDescriptorContext context, object value, Graphics graphics, Rectangle bounds)
        {
            PaintValueEventArgs e = new PaintValueEventArgs(context, value, graphics, bounds);
            // The context of the paint value event         e.Context
            // The object representing the value to paint   e.Value
            // The graphics to use to paint                 e.Graphics
            // The rectangle in which to paint              e.Bounds                       
            return e;
        }
        //</Snippet2>

        //<Snippet3>
        public ToolboxComponentsCreatedEventArgs CreateToolboxComponentsCreatedEventArgs(System.ComponentModel.IComponent[] components)
        {
            ToolboxComponentsCreatedEventArgs e = new ToolboxComponentsCreatedEventArgs(components);
            // The components that were just created        e.Components            
            return e;
        }
        //</Snippet3>

        
        //<Snippet4>
        public ToolboxComponentsCreatingEventArgs CreateToolboxComponentsCreatingEventArgs(System.ComponentModel.Design.IDesignerHost host)
        {
            ToolboxComponentsCreatingEventArgs e = new ToolboxComponentsCreatingEventArgs(host);
            // The designer host of the document receiving the components        e.DesignerHost            
            return e;
        }
        //</Snippet4>
    }
}
