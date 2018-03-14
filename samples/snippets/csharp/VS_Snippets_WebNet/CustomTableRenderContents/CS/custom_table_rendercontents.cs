// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomTableRenderContents : System.Web.UI.WebControls.Table
  {
    protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
    {
      // Insert a header row.
      writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Tr);
      writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Th);
      writer.Write("Col 0");
      writer.RenderEndTag();
      writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Th);
      writer.Write("Col 1");
      writer.RenderEndTag();
      writer.RenderEndTag();

      // Call the base RenderContents method.
      base.RenderContents(writer);
    }
  }
}
// </Snippet2>
