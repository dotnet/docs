// <Snippet2>
using System.Web;
using System.Web.UI;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class CustomHtmlTableRowControlCollection : System.Web.UI.HtmlControls.HtmlTable
    {

       protected override ControlCollection CreateControlCollection()
       {

         return new MyHtmlTableRowControlCollection(this);

       }

       protected class MyHtmlTableRowControlCollection : ControlCollection
       {

         internal MyHtmlTableRowControlCollection(Control owner) : base(owner) { }

         public override void Add(Control child)
         {

           // Always add new rows at the top of the table.
           base.AddAt(0, child);
         }

       }

    }

}
// </Snippet2>
