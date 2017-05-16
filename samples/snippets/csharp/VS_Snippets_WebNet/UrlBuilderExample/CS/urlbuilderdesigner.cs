using System;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Security.Permissions;

namespace CDWebControl
{
    //<Snippet2>
    // Example designer provides a designer verb menu command to launch the 
    // BuildUrl method of the UrlBuilder.
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class UrlBuilderDesigner : System.Web.UI.Design.UserControlDesigner
    {
        public UrlBuilderDesigner()
        {
        }

        // Provides a designer verb menu command for invoking the BuildUrl 
        // method of the UrlBuilder.
        public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerbCollection dvc = new DesignerVerbCollection();                
                dvc.Add( new DesignerVerb("Launch URL Builder UI", new EventHandler(this.launchUrlBuilder)) );
                return dvc;
            }
        }
                
        
        //<Snippet1>
        // This method handles the "Launch Url Builder UI" menu command.
        // Invokes the BuildUrl method of the System.Web.UI.Design.UrlBuilder.
        private void launchUrlBuilder(object sender, EventArgs e)
        {
            // Create a parent control.
            System.Windows.Forms.Control c = new System.Windows.Forms.Control();            
            c.CreateControl();            
                        
            // Launch the Url Builder using the specified control
            // parent, initial URL, empty relative base URL path,
            // window caption, filter string and URLBuilderOptions value.
            UrlBuilder.BuildUrl(
                this.Component, 
                c, 
                "http://www.example.com", 
                "Select a URL", 
                "", 
                UrlBuilderOptions.None);                      
        }        
        //</Snippet1>
    }

    // Example Web control displays the value of its text property.
    // This control is associated with the UrlBuilderDesigner.
    [DesignerAttribute(typeof(UrlBuilderDesigner), typeof(IDesigner))]
    public class UrlBuilderControl : System.Web.UI.WebControls.WebControl
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
