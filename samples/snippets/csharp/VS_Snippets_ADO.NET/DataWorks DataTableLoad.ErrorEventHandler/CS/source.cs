using System;
using System.Data;


class Program
{
// <Snippet1>
    static void Main()
    {
        // Attempt to load data from a data reader in which
        // the schema is incompatible with the current schema.
        // If you use exception handling, you won't get the chance
        // to examine each row, and each individual table,
        // as the Load method progresses.
        // By taking advantage of the FillErrorEventHandler delegate,
        // you can interact with the Load process as an error occurs,
        // attempting to fix the problem, or simply continuing or quitting
        // the Load process:
        DataTable table = GetIntegerTable();
        DataTableReader reader = new DataTableReader(GetStringTable());
        table.Load(reader, LoadOption.OverwriteChanges, FillErrorHandler);

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private static DataTable GetIntegerTable()
    {
        // Create sample Customers table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new DataTable();

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", typeof(int));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 4 });
        table.Rows.Add(new object[] { 5 });
        table.AcceptChanges();
        return table;
    }

    private static DataTable GetStringTable()
    {
        // Create sample Customers table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new DataTable();

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", typeof(string));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { "Mary" });
        table.Rows.Add(new object[] { "Andy" });
        table.Rows.Add(new object[] { "Peter" });
        table.AcceptChanges();
        return table;
    }

    static void FillErrorHandler(object sender, FillErrorEventArgs e)
    {
        // You can use the e.Errors value to determine exactly what
        // went wrong.
        if (e.Errors.GetType() == typeof(System.FormatException))
        {
            Console.WriteLine("Error when attempting to update the value: {0}", 
                e.Values[0]);
        }

        // Setting e.Continue to True tells the Load
        // method to continue trying. Setting it to False
        // indicates that an error has occurred, and the 
        // Load method raises the exception that got 
        // you here.
        e.Continue = true;
    }
    // </Snippet1>
}

