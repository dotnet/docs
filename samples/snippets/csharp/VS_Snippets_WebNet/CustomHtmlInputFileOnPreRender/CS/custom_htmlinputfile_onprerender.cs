// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlInputFileOnPreRender : System.Web.UI.HtmlControls.HtmlInputFile
    {
        protected override void OnPreRender(System.EventArgs e)
        {
            // Call the base OnPreRender method.
            base.OnPreRender(e);
            
            // Add a Title attribute to the HtmlInputFile control.
            this.Attributes.Add("title", "Click the Browse button to select a file to upload.");
        }
    }
}
// </Snippet2>
