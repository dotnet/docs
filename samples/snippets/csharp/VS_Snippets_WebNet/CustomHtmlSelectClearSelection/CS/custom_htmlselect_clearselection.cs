// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlSelectClearSelection : System.Web.UI.HtmlControls.HtmlSelect
    {
        protected override void ClearSelection()
        {
            // For each item in the Items collection, 
            // set the Selected property to false.
            for (int i=0; i < Items.Count; i++)
            Items[i].Selected = false;
        }
    }
}
// </Snippet2>
