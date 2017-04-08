// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomHyperLinkRenderContents : System.Web.UI.WebControls.HyperLink
  {
    protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
    {
      // Call the base RenderContents method.
      base.RenderContents(writer);

      // Append some text to the HyperLink.
      writer.Write(" Home Page");
    }
  }
}
// </Snippet2>
