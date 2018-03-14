using System;
using System.Data;
using System.Data.SqlClient;


class Program
{
    static void Main()
    {
        string connectionString = GetConnectionString();
        ConnectToData(connectionString);
        Console.ReadLine();
    }
    private static void ConnectToData(string connectionString)
    {
        // <Snippet1>
        using (SqlConnection connection =
                   new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = 
                new SqlDataAdapter(
                "SELECT CustomerID, CompanyName FROM dbo.Customers", 
                connection);

            connection.Open();

            DataSet customers = new DataSet();
            adapter.FillSchema(customers, SchemaType.Source, "Customers");
            adapter.Fill(customers, "Customers");

            DataSet orders = new DataSet();
            orders.ReadXml("Orders.xml", XmlReadMode.ReadSchema);
            orders.AcceptChanges();

            customers.Merge(orders, true, MissingSchemaAction.AddWithKey);
            // </Snippet1>
        }
    }

    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file.
        return "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=SSPI";
    }
}
