// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class CustomCheckBoxOnPreRender : System.Web.UI.WebControls.CheckBox
    {
        protected override void OnPreRender(System.EventArgs e)
        {
        // Run the OnPreRender method on the base class.
        base.OnPreRender(e);

        // Display a LightGray BackColor for the CheckBox.
        this.BackColor = System.Drawing.Color.LightGray;
        }
    }
}
// </Snippet2>