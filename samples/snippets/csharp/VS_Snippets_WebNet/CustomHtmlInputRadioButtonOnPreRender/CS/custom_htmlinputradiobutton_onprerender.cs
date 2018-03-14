// <Snippet2>
using System.Web;
using System.Security.Permissions;
namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlInputRadioButtonOnPreRender : System.Web.UI.HtmlControls.HtmlInputRadioButton
    {
        protected override void OnPreRender(System.EventArgs e)
        {
            // Run the OnPreRender method on the base class.
            base.OnPreRender(e);
            
            // Add a Title attribute.
            this.Attributes.Add("title", "Option " + this.Value);
        }
    }
}
// </Snippet2>
