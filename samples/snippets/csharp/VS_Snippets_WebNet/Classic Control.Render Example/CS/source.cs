using System;
using System.Data;
using System.Web.UI;

public class Form1: Control
{
// <Snippet1>
[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
protected override void Render(HtmlTextWriter output) {
    if ( (HasControls()) && (Controls[0] is LiteralControl) ) {
        output.Write("<H2>Your Message: " + ((LiteralControl) Controls[0]).Text + "</H2>");
    }
}
// </Snippet1>

}
