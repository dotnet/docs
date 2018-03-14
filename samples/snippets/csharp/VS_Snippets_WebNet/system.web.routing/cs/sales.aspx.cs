using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //<Snippet170>
        LocaleLiteral.Text = Page.RouteData.Values["locale"] == null ?
            "All locales" : Page.RouteData.Values["locale"].ToString();
        //</Snippet170>

        //<Snippet171>
        YearLiteral.Text = Page.RouteData.Values["year"].ToString();
        //</Snippet171>
    }
}