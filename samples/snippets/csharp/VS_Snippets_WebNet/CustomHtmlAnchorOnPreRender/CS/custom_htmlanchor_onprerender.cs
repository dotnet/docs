// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlAnchorOnPreRender : System.Web.UI.HtmlControls.HtmlAnchor
    {
        protected override void OnPreRender(System.EventArgs e)
        {
            // Call the base OnPreRender method.
            base.OnPreRender(e);

            // Write out the HtmlAnchor control's Title tag.
            this.Title = "Text from OnPreRender.";
        }
    }
}
// </Snippet2>
