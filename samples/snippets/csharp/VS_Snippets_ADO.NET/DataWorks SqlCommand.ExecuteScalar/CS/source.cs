using System;
using System.Data;
using System.Data.SqlClient;

static class Class1
{
    static void Main()
    {
        var ret = AddProductCategory("newval", GetConnectionString());
        Console.WriteLine(ret.ToString());
        Console.ReadLine();
    }
    // <Snippet1>
    public static int AddProductCategory(string newName, string connString)
    {
        var newProdID = 0;
        const string sql =
            "INSERT INTO Production.ProductCategory (Name) VALUES (@Name); "
            + "SELECT CAST(scope_identity() AS int)";
        using (SqlConnection conn = new(connString))
        {
            SqlCommand cmd = new(sql, conn);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            cmd.Parameters["@name"].Value = newName;
            try
            {
                conn.Open();
                newProdID = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        return (int)newProdID;
    }
    // </Snippet1>
    static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file.
        return "Data Source=(local);Initial Catalog=AdventureWorks;"
            + "Integrated Security=true";
    }
}
