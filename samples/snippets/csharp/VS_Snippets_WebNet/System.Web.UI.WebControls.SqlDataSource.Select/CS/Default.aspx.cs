using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    // <Snippet2>
    protected void CheckReorderStatus()
    {
        DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        int reorderedProducts = (int)dv.Table.Rows[0][0];
        if (reorderedProducts > 0)
        {
            Label1.Text = "Number of products on reorder: " + reorderedProducts;
        }
        else
        {
            Label1.Text = "No products on reorder.";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        CheckReorderStatus();
    }
    // </Snippet2>
}
