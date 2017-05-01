// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomCheckBoxListCreateControlStyle : System.Web.UI.WebControls.CheckBoxList
    {
        protected override System.Web.UI.WebControls.Style CreateControlStyle()
        {
        // Initializes and return a new instance of the TableStyle class.
        return new System.Web.UI.WebControls.TableStyle(this.ViewState);
        }
    }
}
// </Snippet2>