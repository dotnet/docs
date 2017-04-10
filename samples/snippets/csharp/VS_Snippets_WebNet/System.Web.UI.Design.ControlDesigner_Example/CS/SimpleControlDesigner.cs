// <Snippet1>
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

//<Snippet4>
namespace AspNet.Samples
{
    // Create a custom class to render the Text property
    [Designer(typeof(SimpleDesigner)), DefaultProperty("Text"), 
    ToolboxData("<{0}:Simple runat=\"server\"></{0}:Simple>")]
    public sealed class Simple : WebControl
    {
        public Simple()
        { }

        // Create a Text property
        [Browsable(true), Bindable(true), 
            PersistenceMode(PersistenceMode.Attribute)]
        public string Text
        {
            get
            {
                object o = ViewState["TextProp"];
                return (o == null) ? "Sample Text" : (string)o;
            }
            set { ViewState["TextProp"] = value; }
        }

        // Render the text inside the control
        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write(Text);
        }
    }
}
//</Snippet4>

namespace AspNet.Samples
{
    //Create a designer class for the Simple control
    public sealed class SimpleDesigner : ControlDesigner
    {
        // Declare a reference to the Simple class
        private Simple simpleControl;

        public SimpleDesigner()
        { }

        //<Snippet2>
        public override void Initialize(IComponent ponent)
        {
            base.Initialize(ponent);

            // Get a reference to the control
            simpleControl = (Simple)ponent;

            //Set Text to the control's ID
            simpleControl.Text = simpleControl.ID;
        }
        //</Snippet2>

        // Allow resizing the control in the design host
        public override bool AllowResize
        {
            get
            {
                return true;
            }
        }

        //<Snippet5>
        public override string GetDesignTimeHtml()
        {
            if (simpleControl.Text.Length > 0)
            {
                string spec = "<a href='{0}.aspx'>{0}</a>";
                return String.Format(spec, simpleControl.Text);
            }
            else
                return GetEmptyDesignTimeHtml();
        }
        //</Snippet5>
    }
}
//</Snippet1>
