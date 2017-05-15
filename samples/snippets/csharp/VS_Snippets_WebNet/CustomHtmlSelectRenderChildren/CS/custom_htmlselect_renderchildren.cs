// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlSelectRenderChildren : System.Web.UI.HtmlControls.HtmlSelect
    {
        protected override void RenderChildren(System.Web.UI.HtmlTextWriter writer)
        {
            // Create a default OPTION.
            System.Web.UI.WebControls.ListItem listItem = new System.Web.UI.WebControls.ListItem("<Select an option> ","");
            this.Items.Insert(0, listItem);
            
            // Call base's RenderChildren method.
            base.RenderChildren(writer);
        }
    }
}
// </Snippet2>
