// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomButtonRenderContents : System.Web.UI.WebControls.Button
    {
    protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
    {
      // Call the base RenderContents method.
      base.RenderContents(writer);

      // Append some text after the button.
      writer.Write("<br>Click this button for more information.");
    }
  }
}
// </Snippet2>