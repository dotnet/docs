// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomLinkButtonRenderContents : System.Web.UI.WebControls.LinkButton
  {
    protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
    {
      // Call the base RenderContents method.
      base.RenderContents(writer);

      // Append some text to the LinkButton.
      writer.Write(" Home Page");
    }
  }
}
// </Snippet2>
