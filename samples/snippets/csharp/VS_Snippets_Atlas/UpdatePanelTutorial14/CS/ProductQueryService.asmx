<%-- <Snippet20> --%>
<%@ WebService Language="C#" Class="Samples.ProductQueryService" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
// <Snippet22>
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
// </Snippet22>
namespace Samples
{
    [ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProductQueryService : System.Web.Services.WebService
    {

        // <Snippet21>
        [WebMethod]
        public string GetProductQuantity(string productID)
        {
            SqlConnection cn =
                new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(
                "SELECT [UnitsInStock] FROM [Alphabetical list of products] WHERE ([ProductID] = @ProductID)", cn);
            cmd.Parameters.Add("productID", productID);
            String unitsInStock = "";
            cn.Open();
            using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                    unitsInStock = dr[0].ToString();
            }
            System.Threading.Thread.Sleep(3000);
            return unitsInStock;
        }
        // </Snippet21>
    }
}
// </Snippet20>
