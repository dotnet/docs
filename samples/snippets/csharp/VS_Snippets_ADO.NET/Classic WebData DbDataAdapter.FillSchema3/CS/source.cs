using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string str = GetConnectionString();
        DataTable table = GetCustomerData("Customers", str);

        //foreach (DataTable table in dataSet.Tables)
        //{
        //    Console.WriteLine(table.TableName);
        //    foreach (DataColumn column in table.Columns)
        //        Console.Write("\table" + column.ColumnName);
        //    Console.WriteLine();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        foreach (DataColumn column in table.Columns)
        //            Console.Write("\table" + row[column]);
        //        Console.WriteLine();
        //    }
        //}
    }

    //<Snippet1>
    public static DataTable GetCustomerData(string dataSetName,
        string connectionString)
    {
        DataTable table = new DataTable(dataSetName);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT CustomerID, CompanyName, ContactName FROM dbo.Customers", connection);

            DataTableMapping mapping = adapter.TableMappings.Add("Table", "Customers");
            mapping.ColumnMappings.Add("CompanyName", "Name");
            mapping.ColumnMappings.Add("ContactName", "Contact");

            connection.Open();

            adapter.FillSchema(table, SchemaType.Mapped);
            adapter.Fill(table);
            return table;
        }
    }
    //</Snippet1>
    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file.
        return "Data Source=(local);Initial Catalog=AdventureWorks;"
            + "Integrated Security=SSPI";
    }
}
