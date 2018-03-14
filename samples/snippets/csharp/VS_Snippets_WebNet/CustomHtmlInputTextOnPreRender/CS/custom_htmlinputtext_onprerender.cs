// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlInputTextOnPreRender : System.Web.UI.HtmlControls.HtmlInputText
    {
        protected override void OnPreRender(System.EventArgs e)
        {
            // Call the base class's OnPreRender method.
            base.OnPreRender(e);

            // Set the HtmlInputText object's MaxLength property to 30 characters.
            this.MaxLength = 30;
        }
    }
}
// </Snippet2>
