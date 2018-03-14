// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlSelectAddParsedSubObject : System.Web.UI.HtmlControls.HtmlSelect
    {
        protected override void AddParsedSubObject(object obj)
        {
            // If the object is a ListItem, then add the ListItem to the Items collection.
            if (obj is System.Web.UI.WebControls.ListItem)
            {
            Items.Add((System.Web.UI.WebControls.ListItem)obj);
            }
            else
            {
            throw new System.Web.HttpException("You cannot have a child control of type " + obj.GetType().Name.ToString());
            }
        }
    }
}
// </Snippet2>
