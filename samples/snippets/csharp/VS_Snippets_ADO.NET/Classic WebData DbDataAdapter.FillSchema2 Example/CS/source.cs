using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string str = GetConnectionString();
        DataSet dataSet = GetCustomerData("CustomerData", str);

        foreach (DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.TableName);
            foreach (DataColumn column in table.Columns)
                Console.Write("\table" + column.ColumnName);
            Console.WriteLine();
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                    Console.Write("\table" + row[column]);
                Console.WriteLine();
            }
        }
    }

    //<Snippet1>
    public static DataSet GetCustomerData(string dataSetName,
        string connectionString)
    {
        DataSet dataSet = new DataSet(dataSetName);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT CustomerID, CompanyName, ContactName FROM dbo.Customers", connection);

            DataTableMapping mapping = adapter.TableMappings.Add("Table", "Customers");
            mapping.ColumnMappings.Add("CompanyName", "Name");
            mapping.ColumnMappings.Add("ContactName", "Contact");

            connection.Open();

            adapter.FillSchema(dataSet, SchemaType.Source, "Customers");
            adapter.Fill(dataSet);

            return dataSet;
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
