// <Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;
using System.Reflection;

namespace ControlDesignerSamples.CS
{
    // Define a simple designer associated with a 
    // simple text web control.
	
    // Mark the designer with the SupportsPreviewControlAttribute set
    // to true.  This means the base.UsePreviewControl returns true,
    // and base.ViewControl returns a temporary preview copy of the control.
    [SupportsPreviewControl(true)]
    public class SimpleTextControlDesigner : TextControlDesigner
    {		
        // Override the base GetDesignTimeHtml method to display 
        // the design time text in italics.
        public override string GetDesignTimeHtml()
        {
            string html = String.Empty;
 
            try
            {
                // Initialize the return string to the default
                // design time html of the base TextControlDesigner.
                html = base.GetDesignTimeHtml();

                // Get the ViewControl for the associated control.
                Label ctrl = (Label)ViewControl;

                ctrl.Style.Add(HtmlTextWriterStyle.FontStyle, "Italic");
                html = base.GetDesignTimeHtml();

            }
            catch (System.Exception e)
            {
               if (String.IsNullOrEmpty(html))
               {
                   html = GetErrorDesignTimeHtml(e);
               }
            }
            
            return html;
        }

    }

    // Derive a simple Web control from Label to render a text string.
    // Associate this control with the SimpleTextControlDesigner.
    [DesignerAttribute("ControlDesignerSamples.CS.SimpleTextControlDesigner"),
    ToolboxData("<{0}:MyLabelControl Runat=\"Server\"><{0}:MyLabelControl>")]
    public class MyLabelControl : Label
    {
        // Use the Label control implementation, but associate
        // the derived class with the custom control designer.
    }
}
// </Snippet1>