using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble
{
// <snippet1>
  public class ParentControl : Control 
  {
     [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
     protected override bool OnBubbleEvent(object sender, EventArgs e)
     {
        Context.Response.Write("<br><br>ParentControl's OnBubbleEvent called.");
        Context.Response.Write("<br>Source of event is: " + sender.ToString());
        return true;
     }
     [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
     protected override void Render( HtmlTextWriter myWriter)
     {
        myWriter.Write("ParentControl");
        RenderChildren(myWriter);
     }
  }
// </snippet1>

// <snippet2>
  public class ChildControl : Button
  {
     [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
     protected override void OnClick(EventArgs e) 
     {
        base.OnClick(e);
        Context.Response.Write("<br><br>ChildControl's OnClick called.");
        // Bubble this event to parent.
        RaiseBubbleEvent(this, e);
     }
// </snippet2>  
}
}