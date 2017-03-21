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