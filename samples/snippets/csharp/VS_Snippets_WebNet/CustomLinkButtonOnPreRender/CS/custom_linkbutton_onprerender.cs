// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomLinkButtonOnPreRender : System.Web.UI.WebControls.LinkButton
  {
    protected override void OnPreRender(System.EventArgs e)
    {
      // Run the OnPreRender method on the base class.
      base.OnPreRender(e);

      // Always display the LinkButton without a border.
      this.BorderWidth =  System.Web.UI.WebControls.Unit.Point(0);
    }
  }
}
// </Snippet2>
