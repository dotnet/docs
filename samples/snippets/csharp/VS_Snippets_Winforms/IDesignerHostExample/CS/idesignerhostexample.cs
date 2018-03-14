// <Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace IDesignerHostExample
{	
    // IDesignerHostExampleComponent is a component associated 
    // with the IDesignerHostExampleDesigner that demonstrates 
    // acquisition and use of the IDesignerHost service 
    // to list project components.
    [DesignerAttribute(typeof(IDesignerHostExampleDesigner))]
    public class IDesignerHostExampleComponent : System.ComponentModel.Component
    {
        public IDesignerHostExampleComponent()
        {}

        protected override void Dispose( bool disposing )
        {
            base.Dispose( disposing );
        }
    }

    // You can double-click the component of an IDesignerHostExampleDesigner 
    // to show a form containing a listbox that lists the name and type 
    // of each component or control in the current design-time project.
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class IDesignerHostExampleDesigner : IDesigner
    {
        private System.ComponentModel.IComponent component;

        public IDesignerHostExampleDesigner()
        {}

        public void DoDefaultAction()
        {
            ListComponents();
        }

        public void Initialize(System.ComponentModel.IComponent component)
        {
            this.component = component;
            MessageBox.Show("Double-click the IDesignerHostExample component to view a list of project components.");
        }

        // Displays a list of components in the current design 
        // document when the default action of the designer is invoked.
        private void ListComponents()
        {
            using (DesignerHostListForm listform = new DesignerHostListForm())
            {
                // Obtain an IDesignerHost service from the design environment.
                IDesignerHost host = (IDesignerHost)this.component.Site.GetService(typeof(IDesignerHost));
                // Get the project components container (control containment depends on Controls collections)
                IContainer container = host.Container;
                // Add each component's type name and name to the list box.
                foreach (IComponent component in container.Components)
                {
                    listform.listBox1.Items.Add(component.GetType().Name + " : " + component.Site.Name);
                }
                // Display the form.
                listform.ShowDialog();
            }
        }

        public System.ComponentModel.IComponent Component
        {
            get
            {
                return this.component;
            }
        }

        public System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerbCollection dvc = new DesignerVerbCollection();
                dvc.Add( new DesignerVerb("List Components", new EventHandler(ListHandler)) );
                return dvc;
            }
        }

        private void ListHandler(object sender, EventArgs e)
        {
            ListComponents();
        }

        public void Dispose() {	}
    }

    // Provides a form containing a listbox that can display 
    // a list of project components.
    public class DesignerHostListForm : System.Windows.Forms.Form
    {
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button ok_button;
        
        public DesignerHostListForm()
        {
            this.Name = "DesignerHostListForm";
            this.Text = "List of design-time project components";
            this.SuspendLayout();
            this.listBox1 = new System.Windows.Forms.ListBox();						
            this.listBox1.Location = new System.Drawing.Point(8, 8);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(385, 238);
            this.listBox1.TabIndex = 0;	
            this.listBox1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);		
            this.ok_button = new System.Windows.Forms.Button();
            this.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok_button.Location = new System.Drawing.Point(232, 256);
            this.ok_button.Name = "ok_button";
            this.ok_button.TabIndex = 1;
            this.ok_button.Text = "OK";
            this.ok_button.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.ClientSize = new System.Drawing.Size(400, 285);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.ok_button, this.listBox1 });
            this.ResumeLayout(false);	
        }

        protected override void Dispose( bool disposing )
        {			
            base.Dispose( disposing );
        }	
    }
}
// </Snippet1>