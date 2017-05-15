using System;
using System.Data;

class Class1
{
    [STAThread]
    static void Main()
    {
        TestHasRows();
    }
    // <Snippet1>
    private static void TestHasRows()
    {
        DataTable customerTable = GetCustomers();
        DataTable productTable = GetProducts();

        using (DataTableReader reader = new DataTableReader(
                   new DataTable[] { customerTable, productTable }))
        {
            do
            {
                if (reader.HasRows)
                {
                    PrintData(reader);
                }
            } while (reader.NextResult());
        }

        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
    }

    private static void PrintData(DataTableReader reader)
    {
        // Loop through all the rows in the DataTableReader
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write(reader[i] + " ");
            }
            Console.WriteLine();
        }
    }

    private static DataTable GetCustomers()
    {
        // Create sample Customers table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new DataTable();
        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string ));
        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 1, "Mary" });
        return table;
    }

    private static DataTable GetProducts()
    {
        // Create sample Products table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new DataTable();

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string ));
      
        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };
        return table;
    }
    // </Snippet1>
}

