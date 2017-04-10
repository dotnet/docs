using System;
using System.Data;

class Program
{
    // <Snippet1>
    static void Main()
    {
        // This example examines a number of scenarios involving the 
        // DataTable.Load method.
        Console.WriteLine("Load a DataTable and infer its schema:");

        // The table has no schema. The Load method will infer the 
        // schema from the IDataReader:
        DataTable table = new DataTable();

        // Retrieve a data reader, based on the Customers data. In
        // an application, this data might be coming from a middle-tier
        // business object:
        DataTableReader reader = new DataTableReader(GetCustomers());

        table.Load(reader);
        PrintColumns(table);

        Console.WriteLine(" ============================= ");
        Console.WriteLine(
            "Load a DataTable from an incompatible IDataReader:");

        // Create a table with a single integer column. Attempt
        // to load data from a reader with a schema that is 
        // incompatible. Note the exception, determined
        // by the particular incompatibility:
        table = GetIntegerTable();
        reader = new DataTableReader(GetStringTable());
        try 
        {
            table.Load(reader);
        } 
        catch (Exception ex) 
        { 
            Console.WriteLine(ex.GetType().Name + ":" + ex.Message);
        }

        Console.WriteLine(" ============================= ");
        Console.WriteLine(
            "Load a DataTable with an IDataReader that has extra columns:");

        // Note that loading a reader with extra columns adds
        // the columns to the existing table, if possible:
        table = GetIntegerTable();
        reader = new DataTableReader(GetCustomers());
        table.Load(reader);
        PrintColumns(table);

        Console.WriteLine(" ============================= ");
        Console.WriteLine(
            "Load a DataTable with an IDataReader that has missing columns:");

        // Note that loading a reader with missing columns causes 
        // the columns to be filled with null data, if possible:
        table = GetCustomers();
        reader = new DataTableReader(GetIntegerTable());
        table.Load(reader);
        PrintColumns(table);

        // Demonstrate the various possibilites when loading data 
        // into a DataTable that already contains data.
        Console.WriteLine(" ============================= ");
        Console.WriteLine("Demonstrate data considerations:");
        Console.WriteLine("Current value, Original value, (RowState)");
        Console.WriteLine(" ============================= ");
        Console.WriteLine("Original table:");

        table = SetupModifiedRows();
        DisplayRowState(table);

        Console.WriteLine(" ============================= ");
        Console.WriteLine("Data in IDataReader to be loaded:");
        DisplayRowState(GetChangedCustomers());

        // Load data into a DataTable, retrieve a DataTableReader 
        // containing different data, and call the Load method. 
        Console.WriteLine(" ============================= ");
        Console.WriteLine("table.Load(reader)");
        Console.WriteLine(" ============================= ");

        table = SetupModifiedRows();
        reader = new DataTableReader(GetChangedCustomers());
        table.Load(reader);
        DisplayRowState(table);

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private static void DisplayRowState(DataTable table)
    {
        for (int i = 0; i <= table.Rows.Count - 1; i++)
        {
            object current = "--";
            object original = "--";
            DataRowState rowState = table.Rows[i].RowState;

            // Attempt to retrieve the current value, which doesn't exist
            // for deleted rows:
            if (rowState != DataRowState.Deleted)
            {
                current = table.Rows[i]["Name", DataRowVersion.Current];
            }

            // Attempt to retrieve the original value, which doesn't exist
            // for added rows:
            if (rowState != DataRowState.Added)
            {
                original = table.Rows[i]["Name", DataRowVersion.Original];
            }
            Console.WriteLine("{0}: {1}, {2} ({3})", i, 
                current, original, rowState);
        }
    }

    private static DataTable GetChangedCustomers()
    {
        // Create sample Customers table.
        DataTable table = new DataTable();

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", 
            typeof(int));
        table.Columns.Add("Name", typeof(string));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 1, "XXX" });
        table.Rows.Add(new object[] { 2, "XXX" });
        table.Rows.Add(new object[] { 3, "XXX" });
        table.Rows.Add(new object[] { 4, "XXX" });
        table.Rows.Add(new object[] { 5, "XXX" });
        table.Rows.Add(new object[] { 6, "XXX" });
        table.AcceptChanges();
        return table;
    }

    private static DataTable GetCustomers()
    {
        // Create sample Customers table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new DataTable();

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", 
            typeof(int));
        table.Columns.Add("Name", typeof(string));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 1, "Mary" });
        table.Rows.Add(new object[] { 2, "Andy" });
        table.Rows.Add(new object[] { 3, "Peter" });
        table.Rows.Add(new object[] { 4, "Russ" });
        table.AcceptChanges();
        return table;
    }

    private static DataTable GetIntegerTable()
    {
        // Create sample Customers table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new DataTable();

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", 
            typeof(int));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { 5 });
        table.Rows.Add(new object[] { 6 });
        table.Rows.Add(new object[] { 7 });
        table.Rows.Add(new object[] { 8 });
        table.AcceptChanges();
        return table;
    }

    private static DataTable GetStringTable()
    {
        // Create sample Customers table, in order
        // to demonstrate the behavior of the DataTableReader.
        DataTable table = new DataTable();

        // Create two columns, ID and Name.
        DataColumn idColumn = table.Columns.Add("ID", 
            typeof(string));

        // Set the ID column as the primary key column.
        table.PrimaryKey = new DataColumn[] { idColumn };

        table.Rows.Add(new object[] { "Mary" });
        table.Rows.Add(new object[] { "Andy" });
        table.Rows.Add(new object[] { "Peter" });
        table.Rows.Add(new object[] { "Russ" });
        table.AcceptChanges();
        return table;
    }

    private static void PrintColumns(DataTable table)
    {
        // Loop through all the rows in the DataTableReader
        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                Console.Write(row[i] + " ");
            }
            Console.WriteLine();
        }
    }

    private static DataTable SetupModifiedRows()
    {
        // Fill a DataTable with customer info, and 
        // then modify, delete, and add rows.

        DataTable table = GetCustomers();
        // Row 0 is unmodified.
        // Row 1 is modified.
        // Row 2 is deleted.
        // Row 5 is added.
        table.Rows[1]["Name"] = "Sydney";
        table.Rows[2].Delete();
        DataRow row = table.NewRow();
        row["ID"] = 5;
        row["Name"] = "Melony";
        table.Rows.Add(row);

        // Note that the code doesn't call
        // table.AcceptChanges()
        return table;
    }
    // </Snippet1>
}

