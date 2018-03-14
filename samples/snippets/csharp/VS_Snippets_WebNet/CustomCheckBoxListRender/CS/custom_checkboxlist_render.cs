// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomCheckBoxListRender : System.Web.UI.WebControls.CheckBoxList
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
        // Create and render a new Image Web control.
        System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
        image.ID = "Image1";
        image.ImageUrl = "image.jpg"; 
        image.AlternateText = "Image for CheckBoxList1.";
        image.RenderControl(writer);

        // Call the base class's Render method.
        base.Render(writer);
        }
    }
}
// </Snippet2>