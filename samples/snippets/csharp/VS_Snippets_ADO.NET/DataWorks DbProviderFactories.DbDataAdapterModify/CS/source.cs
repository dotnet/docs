using System;
using System.Data;
using System.Data.Common;

static class Program
{
    static void Main()
    {
        //CreateDataAdapter("System.Data.OleDb", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\Data\\Northwind.mdb;");
        CreateDataAdapter("System.Data.SqlClient", "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true;");

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
                    "SELECT CustomerID, CompanyName FROM Customers";

                // Create the select command.
                DbCommand command = factory.CreateCommand();
                command.CommandText = queryString;
                command.Connection = connection;

                // Create the DbDataAdapter.
                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;

                // Create the DbCommandBuilder.
                DbCommandBuilder builder = factory.CreateCommandBuilder();
                builder.DataAdapter = adapter;

                // Get the insert, update and delete commands.
                adapter.InsertCommand = builder.GetInsertCommand();
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.DeleteCommand = builder.GetDeleteCommand();

                // Display the CommandText for each command.
                Console.WriteLine("InsertCommand: {0}",
                    adapter.InsertCommand.CommandText);
                Console.WriteLine("UpdateCommand: {0}",
                    adapter.UpdateCommand.CommandText);
                Console.WriteLine("DeleteCommand: {0}",
                    adapter.DeleteCommand.CommandText);

                // Fill the DataTable.
                DataTable table = new();
                adapter.Fill(table);

                // Insert a new row.
                DataRow newRow = table.NewRow();
                newRow["CustomerID"] = "XYZZZ";
                newRow["CompanyName"] = "XYZ Company";
                table.Rows.Add(newRow);

                adapter.Update(table);

                // Display rows after insert.
                Console.WriteLine();
                Console.WriteLine("----List All Rows-----");
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine("{0} {1}", row[0], row[1]);
                }
                Console.WriteLine("----After Insert-----");

                // Edit an existing row.
                DataRow[] editRow = table.Select("CustomerID = 'XYZZZ'");
                editRow[0]["CompanyName"] = "XYZ Corporation";

                adapter.Update(table);

                // Display rows after update.
                Console.WriteLine();
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine("{0} {1}", row[0], row[1]);
                }
                Console.WriteLine("----After Update-----");

                // Delete a row.
                DataRow[] deleteRow = table.Select("CustomerID = 'XYZZZ'");
                foreach (DataRow row in deleteRow)
                {
                    row.Delete();
                }

                adapter.Update(table);

                // Display rows after delete.
                Console.WriteLine();
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine("{0} {1}", row[0], row[1]);
                }
                Console.WriteLine("----After Delete-----");
                Console.WriteLine("Customer XYZZZ was deleted.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    //</Snippet1>
}
