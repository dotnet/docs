// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomXmlAddParsedSubObject : System.Web.UI.WebControls.Xml
    {
        protected override void AddParsedSubObject(object obj)
        {
            // Call the base AddParseSubObject method.
            base.AddParsedSubObject(obj);

            // Note: This method does not get called when transforming XML.
        }
    }
}
// </Snippet2>
