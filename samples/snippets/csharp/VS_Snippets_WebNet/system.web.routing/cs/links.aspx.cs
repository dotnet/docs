using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//<Snippet110>
using System.Web.Routing;
//</Snippet110>

public partial class Links : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //<Snippet128>
        //<Snippet120>
        RouteValueDictionary parameters = 
            new RouteValueDictionary  
                { 
                    {"locale", "CA" }, 
                    { "year", "2008" } , 
                    { "category", "recreation" }
                };
        //</Snippet120>

        //<Snippet122>
        VirtualPathData vpd = 
            RouteTable.Routes.GetVirtualPath(null, "ExpensesRoute", parameters);
        //</Snippet122>

        //<Snippet124>
        HyperLink6.NavigateUrl = vpd.VirtualPath;
        //</Snippet124>
        //</Snippet128>
    }
}