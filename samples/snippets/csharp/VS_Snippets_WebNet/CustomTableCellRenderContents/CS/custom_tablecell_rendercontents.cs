// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomTableCellRenderContents : System.Web.UI.WebControls.TableCell
  {
    protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
    {
      // Insert text into each TableCell.
      writer.Write("TableCell: ");

      // Call the base RenderContents method.
      base.RenderContents(writer);
    }
  }
}
// </Snippet2>
