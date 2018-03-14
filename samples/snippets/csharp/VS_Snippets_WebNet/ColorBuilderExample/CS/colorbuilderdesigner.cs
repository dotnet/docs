using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CDWebControl
{

    //<Snippet2>
    // Example designer provides a designer verb menu command to launch the 
    // BuildColor method of the ColorBuilder.
    [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand, Name="FullTrust")]
    [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
    public class ColorBuilderDesigner : System.Web.UI.Design.UserControlDesigner
    {
        public ColorBuilderDesigner()
        {
        }

        // Provides a designer verb menu command for invoking the BuildColor 
        // method of the ColorBuilder.
        public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerbCollection dvc = new DesignerVerbCollection();                               
                dvc.Add( new DesignerVerb("Launch Color Builder UI", new EventHandler(this.launchColorBuilder)) ); 
                return dvc;
            }
        }

        // This method handles the "Launch Color Builder UI" menu command.
        // Invokes the BuildColor method of the System.Web.UI.Design.ColorBuilder.
        private void launchColorBuilder(object sender, EventArgs e)
        {
            //<Snippet1>
            // Create a parent control.
            System.Windows.Forms.Control c = new System.Windows.Forms.Control();            
            c.CreateControl();            
            
            // Launch the Color Builder using the specified control 
            // parent and an initial HTML format ("RRGGBB") color string.
            System.Web.UI.Design.ColorBuilder.BuildColor(this.Component, c, "405599");
            //</Snippet1>
        }
    }

    // Example Web control displays the value of its text property.
    // This control is associated with the ColorBuilderDesigner.
    [DesignerAttribute(typeof(ColorBuilderDesigner), typeof(IDesigner))]
    public class ColorBuilderControl : System.Web.UI.WebControls.WebControl
    {
        private string text;

        [Bindable(true),
        Category("Appearance"),
        DefaultValue("")]
        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            output.Write(Text);
        }
    }
    //</Snippet2>
}