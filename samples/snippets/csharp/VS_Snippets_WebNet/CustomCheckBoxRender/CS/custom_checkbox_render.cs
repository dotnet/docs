// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomCheckBoxRender : System.Web.UI.WebControls.CheckBox
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
        // Call the base class's Render method.
        base.Render(writer);

        // Render a BR HTML tag
        writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Br);

        // Create and render a new Image Web control.
        System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
        image.ID = "Image1";
        image.ImageUrl = "image.jpg"; 
        image.AlternateText = "Image for CheckBox1.";
        image.RenderControl(writer);
        }
    }
}
// </Snippet2>