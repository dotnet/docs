using System;
using System.Data;
using System.Data.Common;

static class Program
{
    static void Main()
    {
        CreateDataAdapter("System.Data.OleDb", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\Data\\Northwind.mdb;");

        Console.ReadLine();
    }

    // <Snippet1>
    static void CreateDataAdapter(string providerName, string connectionString)
    {
        try
        {
            // Create the DbProviderFactory and DbConnection.
            DbProviderFactory factory =
                DbProviderFactories.GetFactory(providerName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            using (connection)
            {
                // Define the query.
                const string queryString =
                    "SELECT CategoryName FROM Categories";

                // Create the DbCommand.
                DbCommand command = factory.CreateCommand();
                command.CommandText = queryString;
                command.Connection = connection;

                // Create the DbDataAdapter.
                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;

                // Fill the DataTable.
                DataTable table = new();
                adapter.Fill(table);

                //  Display each row and column value.
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.WriteLine(row[column]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    //</Snippet1>
}
