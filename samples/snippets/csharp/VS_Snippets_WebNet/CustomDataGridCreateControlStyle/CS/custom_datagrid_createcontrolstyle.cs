// <Snippet2>
using System.Web;
using System.Security.Permissions;
namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomDataGridCreateControlStyle : System.Web.UI.WebControls.DataGrid
    {
        protected override System.Web.UI.WebControls.Style CreateControlStyle()
        {
            // Create a new TableStyle instance based on ViewState values.
            System.Web.UI.WebControls.TableStyle style = new System.Web.UI.WebControls.TableStyle(ViewState);
            
            // Show the GridLines with no CellSpacing.
            style.GridLines = System.Web.UI.WebControls.GridLines.Both;
            style.CellSpacing = 0;

            // Return the Style
            return style;
        }
    }
}
// </Snippet2>