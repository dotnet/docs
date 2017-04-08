// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlInputHiddenOnPreRender : System.Web.UI.HtmlControls.HtmlInputHidden
    {
        protected override void OnPreRender(System.EventArgs e)
        {
            // Call the base class's OnPreRender method.
            base.OnPreRender(e);
            
            // Encode the Hidden Input value as HTML.
            this.Value = System.Web.HttpContext.Current.Server.HtmlEncode(this.Value);
        }
    }
}
// </Snippet2>
