// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomLabelRenderContents : System.Web.UI.WebControls.Label
  {
    protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
    {
      // Call the base RenderContents method.
      base.RenderContents(writer);

      // Append some text to the Label.
      writer.Write("<BR>Experience Windows Server 2003 and Visual Studio® .NET 2003.");
    }
  }
}
// </Snippet2>
