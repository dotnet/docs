// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomDataListCreateControlStyle : System.Web.UI.WebControls.DataList
    {
        protected override System.Web.UI.WebControls.Style CreateControlStyle()
        {
            // Create a new TableStyle instance based on ViewState values.
            System.Web.UI.WebControls.TableStyle style = new System.Web.UI.WebControls.TableStyle(ViewState);
            
            // Show the GridLines horizontal with no CellSpacing.
            style.GridLines = System.Web.UI.WebControls.GridLines.Horizontal;
            style.CellSpacing = 0;

            // Return the Style
            return style;
        }
    }
}
// </Snippet2>