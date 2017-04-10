// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlImageRenderAttributes : System.Web.UI.HtmlControls.HtmlImage
    {
        protected override void RenderAttributes(System.Web.UI.HtmlTextWriter writer)
        {
            // Call the base class's RenderAttributes method.
            base.RenderAttributes(writer);
            
            // Write out the HtmlImage control's alt tag.
            writer.Write(" alt=\"Text from custom RenderAttributes method.\"");
        }
    }
}
// </Snippet2>
