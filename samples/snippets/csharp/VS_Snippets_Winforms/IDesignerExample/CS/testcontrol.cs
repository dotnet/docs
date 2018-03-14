//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace IDesignerExample
{	
    // A DesignerAttribute associates the example IDesigner with an example control.
    [DesignerAttribute(typeof(ExampleIDesigner))]
    public class TestControl : System.Windows.Forms.UserControl
    {				
        public TestControl()
        {	
        }
    }

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class ExampleIDesigner : System.ComponentModel.Design.IDesigner
    {
        // Local reference to the designer's component.
        private IComponent component; 
        // Public accessor to the designer's component.
        public System.ComponentModel.IComponent Component
        {
            get
            {
                return component;
            }            
        }

        public ExampleIDesigner()
        {            
        }

        public void Initialize(System.ComponentModel.IComponent component)
        {
            // This method is called after a designer for a component is created,
            // and stores a reference to the designer's component.
            this.component = component;
        }        
        
        // This method peforms the 'default' action for the designer. The default action 
        // for a basic IDesigner implementation is invoked when the designer's component 
        // is double-clicked. By default, a component associated with a basic IDesigner 
        // implementation is displayed in the design-mode component tray.
        public void DoDefaultAction()
        {
            // Shows a message box indicating that the default action for the designer was invoked.
            MessageBox.Show("The DoDefaultAction method of an IDesigner implementation was invoked.", "Information");
        }

        // Returns a collection of designer verb menu items to show in the 
        // shortcut menu for the designer's component.
        public System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerbCollection verbs = new DesignerVerbCollection();
                DesignerVerb dv1 = new DesignerVerb("Display Component Name", new EventHandler(this.ShowComponentName));
                verbs.Add( dv1 );
                return verbs;
            }
        }

        // Event handler for displaying a message box showing the designer's component's name.
        private void ShowComponentName(object sender, EventArgs e)
        {
            if( this.Component != null )
                MessageBox.Show( this.Component.Site.Name, "Designer Component's Name" );
        }

        // Provides an opportunity to release resources before object destruction.
        public void Dispose()
        {        
        }
    }
}
//</Snippet1>