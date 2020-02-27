using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security;
using System.Security.Permissions;
// <snippet2>
namespace Samples.AspNet.CS
{
    [PermissionSet(SecurityAction.Demand, Unrestricted = true)]
    public class CustomPageParserFilter : PageParserFilter
    {
        public override bool AllowCode
        {
            get 
            {
                return false;
            }
        }
    }
}
// </snippet2>