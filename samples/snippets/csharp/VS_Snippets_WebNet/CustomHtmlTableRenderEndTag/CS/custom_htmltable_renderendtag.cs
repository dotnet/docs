// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlTableRenderEndTag : System.Web.UI.HtmlControls.HtmlTable
    {
        protected override void RenderEndTag(System.Web.UI.HtmlTextWriter writer)
        {
            // Write out the current TagName.
            writer.WriteEndTag(this.TagName);
            
            // Write out a new line.
            writer.WriteLine();
        }
    }
}
// </Snippet2>
