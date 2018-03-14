using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Routing;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // <Snippet2>
        RouteValueDictionary parameters = new RouteValueDictionary { { "action", "show" }, { "categoryName", "bikes" } };
        VirtualPathData vpd = RouteTable.Routes.GetVirtualPath(null, parameters);
        HyperLink1.NavigateUrl = vpd.VirtualPath;
        // </Snippet2>
    }
}
