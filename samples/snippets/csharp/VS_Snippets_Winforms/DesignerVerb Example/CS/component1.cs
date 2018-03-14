//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;

/* This sample demonstrates a designer that adds menu commands
    to the design-time shortcut menu for a component.

    To test this sample, build the code for the component as a class library, 
    add the resulting component to the toolbox, open a form in design mode, 
    and drag the component from the toolbox onto the form. 

    The component should appear in the component tray beneath the form. 
    Right-click the component.  The verbs should appear in the shortcut menu.
*/

namespace CSDesignerVerb
{
    // Associate MyDesigner with this component type using a DesignerAttribute
    [Designer(typeof(MyDesigner))]
    public class Component1 : System.ComponentModel.Component
    {
    }

    // This is a designer class which provides designer verb menu commands for 
    // the associated component. This code is called by the design environment at design-time.
    internal class MyDesigner : ComponentDesigner
    {
        DesignerVerbCollection m_Verbs;

        // DesignerVerbCollection is overridden from ComponentDesigner
        public override DesignerVerbCollection Verbs
        {
            get 
            {
                if (m_Verbs == null) 
                {
                    // Create and initialize the collection of verbs
                    m_Verbs = new DesignerVerbCollection();
			
                    m_Verbs.Add( new DesignerVerb("First Designer Verb", new EventHandler(OnFirstItemSelected)) );
                    m_Verbs.Add( new DesignerVerb("Second Designer Verb", new EventHandler(OnSecondItemSelected)) );
                }
                return m_Verbs;
            }
        }

        MyDesigner() 
        {
        }

        private void OnFirstItemSelected(object sender, EventArgs args) 
        {
            // Display a message
            System.Windows.Forms.MessageBox.Show("The first designer verb was invoked.");
        }

        private void OnSecondItemSelected(object sender, EventArgs args) 
        {
            // Display a message
            System.Windows.Forms.MessageBox.Show("The second designer verb was invoked.");
        }
    }
}
//</Snippet1>