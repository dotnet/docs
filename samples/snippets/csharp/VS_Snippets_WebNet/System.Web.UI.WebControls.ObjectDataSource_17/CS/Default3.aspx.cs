using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    // <Snippet2>
    protected void rowsToDisplay_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = int.Parse(rowsToDisplay.SelectedValue);
    }
    // </Snippet2>
}
