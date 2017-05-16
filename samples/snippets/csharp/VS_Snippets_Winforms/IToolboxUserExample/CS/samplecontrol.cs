//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

// This example contains an IRootDesigner that implements the IToolboxUser interface.
// This example demonstrates how to enable the GetToolSupported method of an IToolboxUser
// designer in order to disable specific toolbox items, and how to respond to the 
// invocation of a ToolboxItem in the ToolPicked method of an IToolboxUser implementation.
namespace IToolboxUserExample
{
    // This example component class demonstrates the associated IRootDesigner which 
    // implements the IToolboxUser interface. When designer view is invoked, Visual 
    // Studio .NET attempts to display a design mode view for the class at the top 
    // of a code file. This can sometimes fail when the class is one of multiple types 
    // in a code file, and has a DesignerAttribute associating it with an IRootDesigner. 
    // Placing a derived class at the top of the code file solves this problem. A 
    // derived class is not typically needed for this reason, except that placing the 
    // RootDesignedComponent class in another file is not a simple solution for a code 
    // example that is packaged in one segment of code.
    public class RootViewSampleComponent : RootDesignedComponent
	{
	}

	// The following attribute associates the SampleRootDesigner with this example component.
	[DesignerAttribute(typeof(SampleRootDesigner), typeof(IRootDesigner))]
	public class RootDesignedComponent : System.Windows.Forms.Control
	{
	}

    // This example IRootDesigner implements the IToolboxUser interface and provides a 
    // Windows Forms view technology view for its associated component using an internal 
    // Control type.     
    // The following ToolboxItemFilterAttribute enables the GetToolSupported method of this
    // IToolboxUser designer to be queried to check for whether to enable or disable all 
    // ToolboxItems which create any components whose type name begins with "System.Windows.Forms".
    [ToolboxItemFilterAttribute("System.Windows.Forms", ToolboxItemFilterType.Custom)]
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class SampleRootDesigner : ParentControlDesigner, IRootDesigner, IToolboxUser
    {
        // This field is a custom Control type named RootDesignerView. This field references
        // a control that is shown in the design mode document window.
        private RootDesignerView view;

        // This string array contains type names of components that should not be added to 
        // the component managed by this designer from the Toolbox.  Any ToolboxItems whose 
        // type name matches a type name in this array will be marked disabled according to  
        // the signal returned by the IToolboxUser.GetToolSupported method of this designer.
        private string[] blockedTypeNames =
        {
            "System.Windows.Forms.ListBox",
            "System.Windows.Forms.GroupBox"
        };

        // IRootDesigner.SupportedTechnologies is a required override for an IRootDesigner.
        // This designer provides a display using the Windows Forms view technology.
        ViewTechnology[] IRootDesigner.SupportedTechnologies 
        {
            get { return new ViewTechnology[] {ViewTechnology.Default}; }
        }

        // This method returns an object that provides the view for this root designer. 
        object IRootDesigner.GetView(ViewTechnology technology) 
        {
            // If the design environment requests a view technology other than Windows 
            // Forms, this method throws an Argument Exception.
            if (technology != ViewTechnology.Default)            
                throw new ArgumentException("An unsupported view technology was requested", 
                "Unsupported view technology.");            
            
            // Creates the view object if it has not yet been initialized.
            if (view == null)                            
                view = new RootDesignerView(this);          
  
            return view;
        }

        //<Snippet2>
        // This method can signal whether to enable or disable the specified
        // ToolboxItem when the component associated with this designer is selected.
        bool IToolboxUser.GetToolSupported(ToolboxItem tool)
        {       
            // Search the blocked type names array for the type name of the tool
            // for which support for is being tested. Return false to indicate the
            // tool should be disabled when the associated component is selected.
            for( int i=0; i<blockedTypeNames.Length; i++ )
                if( tool.TypeName == blockedTypeNames[i] )
                    return false;
            
            // Return true to indicate support for the tool, if the type name of the
            // tool is not located in the blockedTypeNames string array.
            return true;
        }
        //</Snippet2>
    
        //<Snippet3>
        // This method can perform behavior when the specified tool has been invoked.
        // Invocation of a ToolboxItem typically creates a component or components, 
        // and adds any created components to the associated component.
        void IToolboxUser.ToolPicked(ToolboxItem tool)
        {
        }
        //</Snippet3>

        // This control provides a Windows Forms view technology view object that 
        // provides a display for the SampleRootDesigner.
        [DesignerAttribute(typeof(ParentControlDesigner), typeof(IDesigner))]
        internal class RootDesignerView : Control
        {
            // This field stores a reference to a designer.
            private IDesigner m_designer;

            public RootDesignerView(IDesigner designer)
            {
                // Perform basic control initialization.
                m_designer = designer;
                BackColor = Color.Blue;
                Font = new Font(Font.FontFamily.Name, 24.0f);                
            }

            // This method is called to draw the view for the SampleRootDesigner.
            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);
                // Draw the name of the component in large letters.
                pe.Graphics.DrawString(m_designer.Component.Site.Name, Font, Brushes.Yellow, ClientRectangle);
            }
        }
    }
}
//</Snippet1>