// <Snippet2>
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

[PartialCaching(100)]
public partial class SimpleControl : System.Web.UI.UserControl
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        ItemsRemaining.Text = GetAvailableItems().ToString();
        CacheTime.Text = DateTime.Now.ToLongTimeString();
    }

    private int GetAvailableItems()
    {
        SqlConnection sqlConnection = new SqlConnection
            ("Initial Catalog=Northwind;Data Source=localhost;Integrated Security=SSPI;");
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "GetRemainingItems";
        sqlConnection.Open();
        int items = (int)sqlCommand.ExecuteScalar();
        sqlConnection.Close();
        return items;
    }
}
// </Snippet2>