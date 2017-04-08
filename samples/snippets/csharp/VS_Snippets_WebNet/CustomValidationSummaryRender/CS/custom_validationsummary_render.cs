// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomValidationSummaryRender : System.Web.UI.WebControls.ValidationSummary
  {
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
      // Write out begining Small HTML tag.
      writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Small);

      // Call the base class's Render method.
      base.Render(writer);

      // Write out ending Small HTML tag.
      writer.RenderEndTag();
    }
  }
}
// </Snippet2>
