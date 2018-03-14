// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomImageButtonTagKey : System.Web.UI.WebControls.ImageButton
    {
        protected override System.Web.UI.HtmlTextWriterTag TagKey
        {
            get
            {
            // Specify that only the Input HTML tag can be passed to the HtmlTextWriter.
            return System.Web.UI.HtmlTextWriterTag.Input;
            }
        }
    }
}
// </Snippet2>
