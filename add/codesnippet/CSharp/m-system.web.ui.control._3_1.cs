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