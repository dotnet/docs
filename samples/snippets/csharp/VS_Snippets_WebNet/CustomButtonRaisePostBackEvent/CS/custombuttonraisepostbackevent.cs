// <Snippet2>
namespace Samples.AspNet.CS.Controls
{
  [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
  public class CustomButtonRaisePostBackEvent : System.Web.UI.WebControls.Button, System.Web.UI.IPostBackEventHandler
  {
    private string message = System.String.Empty;

    protected override void Render(System.Web.UI.HtmlTextWriter writer) 
    {
      // Render a HTML submit button.
      writer.Write("<INPUT TYPE='submit' name='" + this.UniqueID + "' value='Click Me' />"); 
      writer.Write("<BR>" + message);
    }
    
    // Re-implement the IPostBackEventHandler's RaisePostBackEvent method.
    // Note: C# allows this, where VB.NET does not.
    public void RaisePostBackEvent(System.String eventArgument)
    {
      // Raise the Click event of the custom Button web control.
      OnClick(new System.EventArgs());

      // Don't call the Page.Validate or OnCommand events,
      // which the base IPostBackEventHandler's RaisePostBackEvent method does.
    }

    protected override void OnClick(System.EventArgs e)
    {
      message = "RaisePostBackEvent method successful!";
    }
  }
}
// </Snippet2>