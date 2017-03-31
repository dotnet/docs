// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomTextBoxOnPreRender : System.Web.UI.WebControls.TextBox
  {
    protected override void OnPreRender(System.EventArgs e)
    {
      // Run the OnPreRender method on the base class.
      base.OnPreRender(e);

      // Display the TextBox with a 1 point border.
      this.BorderWidth = System.Web.UI.WebControls.Unit.Point(1);
    }
  }
}
// </Snippet2>
