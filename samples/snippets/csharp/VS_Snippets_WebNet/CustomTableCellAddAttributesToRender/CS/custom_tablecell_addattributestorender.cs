// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomTableCellAddAttributesToRender : System.Web.UI.WebControls.TableCell
  {
    protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
    {
      // Write a Title attribute.
      writer.AddAttribute("title", "CustomAddAttributesToRender");

      // Call the base AddAttributesToRender method.
      base.AddAttributesToRender(writer);

    }
  }
}
// </Snippet2>
