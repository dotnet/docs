// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Samples
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlInputRadioButtonRenderAttributes : System.Web.UI.HtmlControls.HtmlInputRadioButton
    {
        protected override void RenderAttributes(System.Web.UI.HtmlTextWriter writer)
        {
            
            // Call the base class's RenderAttributes method.
            base.RenderAttributes(writer);

            // Write out the control's Title tag.
            writer.Write(" Title=\"Option " + this.Value + "\"");
        }
    }
}
// </Snippet2>
