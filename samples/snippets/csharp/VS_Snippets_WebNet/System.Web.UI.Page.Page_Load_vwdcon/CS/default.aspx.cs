using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{

    //<snippet1>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Response.Write("<br>Page has been posted back.");
        }
    }
    //</snippet1>

    //<snippet3>
    protected void NameChange(object sender, EventArgs e)
    {
        //Method for the OnTextChanged event.
    }
    //</snippet3>

}