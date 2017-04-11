using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default2 : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //<Snippet2>
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SqlDataSource s = (SqlDataSource)e.Row.FindControl("SqlDataSource2");
            s.FilterParameters[0].DefaultValue = e.Row.Cells[0].Text;
        }
        //</Snippet2>
    }
}
