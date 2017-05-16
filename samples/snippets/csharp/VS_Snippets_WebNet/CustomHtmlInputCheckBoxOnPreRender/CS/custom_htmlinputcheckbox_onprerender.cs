// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlInputCheckBoxOnPreRender : System.Web.UI.HtmlControls.HtmlInputCheckBox
    {
        protected override void OnPreRender(System.EventArgs e)
        {
            // Call the base class's OnPreRender method.
            base.OnPreRender(e);
            
            // Add a Title attribute to each HtmlInputCheckBox.
            this.Attributes.Add("title", "If you like " + this.Value + ", then select this check box.");
        }
    }
}
// </Snippet2>
