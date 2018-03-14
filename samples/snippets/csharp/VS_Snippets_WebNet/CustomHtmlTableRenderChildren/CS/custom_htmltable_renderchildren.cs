// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlTableRenderChildren : System.Web.UI.HtmlControls.HtmlTable
    {
        protected override void RenderChildren(System.Web.UI.HtmlTextWriter writer)
        {
            // Call the base class's RenderChildren method.
            base.RenderChildren(writer);
            
            // Write out a new table row.
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Td);
            writer.Write("4,1");
            writer.RenderEndTag();
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Td);
            writer.Write("4,2");
            writer.RenderEndTag();
            writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Td);
            writer.Write("4,3");
            writer.RenderEndTag();
            writer.RenderEndTag();
        }
    }
}
// </Snippet2>
