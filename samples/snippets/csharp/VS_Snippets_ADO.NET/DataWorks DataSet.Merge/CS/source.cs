using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
    static void Main()
    {
        var connectionString = GetConnectionString();
        ConnectToData(connectionString);
        Console.ReadLine();
    }
    static void ConnectToData(string connectionString)
    {
        // <Snippet1>
        using (SqlConnection connection =
                   new(connectionString))
        {
            SqlDataAdapter adapter =
                new(
                "SELECT CustomerID, CompanyName FROM dbo.Customers",
                connection);

            connection.Open();

            DataSet customers = new();
            adapter.FillSchema(customers, SchemaType.Source, "Customers");
            adapter.Fill(customers, "Customers");

            DataSet orders = new();
            orders.ReadXml("Orders.xml", XmlReadMode.ReadSchema);
            orders.AcceptChanges();

            customers.Merge(orders, true, MissingSchemaAction.AddWithKey);
            // </Snippet1>
        }
    }

    static string GetConnectionString() =>
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file.
        "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=SSPI";
}
