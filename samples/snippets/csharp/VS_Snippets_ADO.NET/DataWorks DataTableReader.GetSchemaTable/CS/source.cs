using System;
using System.Data;
using System.Data.SqlClient;

class Class1
{
    [STAThread]
    static void Main(string[] args)
    {
        TestGetSchemaTable();
    }
    // <Snippet1>
    private static void TestGetSchemaTable()
    {
        // Set up the data adapter, using information from 
        // the AdventureWorks sample database.
        // Modify the SQL expression to retrieve 
        // data from a different table.
        SqlDataAdapter adapter = 
            SetupDataAdapter("SELECT * FROM Sales.Customer");

        // Fill the DataTable, retrieving all the schema information.
        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        DataTable table = new DataTable();
        adapter.Fill(table);
         
        // Create the DataTableReader, and close it when done.
        using (DataTableReader reader = new DataTableReader(table))
        {
            // Modify the column number to display information
            // about a column other than column 0.
            DisplaySchemaTableInfo(reader, 0);
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
    }

    private static void DisplaySchemaTableInfo(
            DataTableReader reader, int ordinal)
    {
        // Given a DataTableReader, display schema
        // information about a particular column.
        try
        {
            DataTable schemaTable = reader.GetSchemaTable();
            DataRow row = schemaTable.Rows[ordinal];
            foreach (DataColumn col in schemaTable.Columns)
            {
                Console.WriteLine("{0}: {1}", 
                    col.ColumnName, row[col.Ordinal]);
            }
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("{0} is an invalid column number.", 
                ordinal);
        }
    }

    private static SqlDataAdapter SetupDataAdapter(String sqlString)
    {
        // Assuming all the default settings, create a 
        // SqlDataAdapter working with the AdventureWorks
        // sample database that's available with 
        // SQL Server.
        String connectionString = 
            "Data source=(local);initial catalog=AdventureWorks;" +
            "Integrated Security=True";
        return new SqlDataAdapter(sqlString, connectionString);
    }
    // </Snippet1>
}

