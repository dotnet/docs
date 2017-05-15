using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class _Default : System.Web.UI.Page 
{
    // <Snippet1>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            Page.Title = "Home page for " + User.Identity.Name;
        }
        else
        {
            Page.Title = "Home page for guest user.";
        }
    }
    // </Snippet1>
}
