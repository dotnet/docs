using System;
using System.Data;

static class DataTableReaderConstructor
{
    [STAThread]
    static void Main()
    {
        TestConstructor();
    }
    // <Snippet1>
    static void TestConstructor()
    {
        // Create two data adapters, one for each of the two
        // DataTables to be filled.
        DataTable customerDataTable = GetCustomers();
        DataTable productDataTable = GetProducts();

        // Create the new DataTableReader.
        using (DataTableReader reader = new(
                   new DataTable[] { customerDataTable, productDataTable }))
        {
            // Print the contents of each of the result sets.
            do
            {
                PrintColumns(reader);
            } while (reader.NextResult());
        }

        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
    }

    static DataTable GetCustomers()
    {
        // Create sample Customers table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new();

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 1, "Mary" });
        table.Rows.Add(new object[] { 2, "Andy" });
        table.Rows.Add(new object[] { 3, "Peter" });
        table.Rows.Add(new object[] { 4, "Russ" });
        return table;
    }

    static DataTable GetProducts()
    {
        // Create sample Products table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new();

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 1, "Wireless Network Card" });
        table.Rows.Add(new object[] { 2, "Hard Drive" });
        table.Rows.Add(new object[] { 3, "Monitor" });
        table.Rows.Add(new object[] { 4, "CPU" });
        return table;
    }

    static void PrintColumns(DataTableReader reader)
    {
        // Loop through all the rows in the DataTableReader
        while (reader.Read())
        {
            for (var i = 0; i < reader.FieldCount; i++)
            {
                Console.Write(reader[i] + " ");
            }
            Console.WriteLine();
        }
    }
    // </Snippet1>
}
