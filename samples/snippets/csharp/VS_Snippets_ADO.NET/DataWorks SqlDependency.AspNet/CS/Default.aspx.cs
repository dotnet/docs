using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Caching;
//using Microsoft.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    // <Snippet1>
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "Cache Refresh: " +
        DateTime.Now.ToLongTimeString();

        // Create a dependency connection to the database.
        SqlDependency.Start(GetConnectionString());

        using (SqlConnection connection =
            new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand command =
                new SqlCommand(GetSQL(), connection))
            {
                SqlCacheDependency dependency =
                    new SqlCacheDependency(command);
                // Refresh the cache after the number of minutes
                // listed below if a change does not occur.
                // This value could be stored in a configuration file.
                int numberOfMinutes = 3;
                DateTime expires =
                    DateTime.Now.AddMinutes(numberOfMinutes);

                Response.Cache.SetExpires(expires);
                Response.Cache.SetCacheability(HttpCacheability.Public);
                Response.Cache.SetValidUntilExpires(true);

                Response.AddCacheDependency(dependency);

                connection.Open();

                GridView1.DataSource = command.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }
    // </Snippet1>

    // <Snippet2>
    private string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file.
        return "Data Source=(local);Integrated Security=true;" +
          "Initial Catalog=AdventureWorks;";
    }
    private string GetSQL()
    {
        return "SELECT Production.Product.ProductID, " +
        "Production.Product.Name, " +
        "Production.Location.Name AS Location, " +
        "Production.ProductInventory.Quantity " +
        "FROM Production.Product INNER JOIN " +
        "Production.ProductInventory " +
        "ON Production.Product.ProductID = " +
        "Production.ProductInventory.ProductID " +
        "INNER JOIN Production.Location " +
        "ON Production.ProductInventory.LocationID = " +
        "Production.Location.LocationID " +
        "WHERE ( Production.ProductInventory.Quantity <= 100 ) " +
        "ORDER BY Production.ProductInventory.Quantity, " +
        "Production.Product.Name;";
    }
    // </Snippet2>
}
