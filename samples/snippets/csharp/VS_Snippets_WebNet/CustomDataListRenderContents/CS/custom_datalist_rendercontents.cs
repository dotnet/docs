// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomDataListRenderContents : System.Web.UI.WebControls.DataList
    {
        protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
        {
            // Place some text before the DataList.
            writer.Write("Here is some text from the RenderContent method.<br>");

            // Call the base RenderContents method.
            base.RenderContents(writer);
        }
    }
}
// </Snippet2>
