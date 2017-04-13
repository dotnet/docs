// <Snippet1>
using System;
using System.Web;
using System.Web.UI;

namespace SimpleControlSamples {

    public class InnerContent : Control {
	[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="Execution")] 
       protected override void Render(HtmlTextWriter output) {

           if ( (HasControls()) && (Controls[0] is LiteralControl) ) {
               output.Write("<H2>Your message : ");
               Controls[0].RenderControl(output);
               output.Write("</H2>");
           }
       }
    }    
}
   
// </Snippet1>
