using System;
using System.Data;


class Program
{
    static void Main()
    {
        DemonstrateMergeTable();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    // <Snippet1>
    private static void DemonstrateMergeTable()
    {
        DataTable table1 = new DataTable("Items");

        // Add columns
        DataColumn column1 = new DataColumn("id", typeof(System.Int32));
        DataColumn column2 = new DataColumn("item", typeof(System.Int32));
        table1.Columns.Add(column1);
        table1.Columns.Add(column2);

        // Set the primary key column.
        table1.PrimaryKey = new DataColumn[] { column1 };

        // Add RowChanged event handler for the table.
        table1.RowChanged += 
            new System.Data.DataRowChangeEventHandler(Row_Changed);

        // Add some rows.
        DataRow row;
        for (int i = 0; i <= 3; i++)
        {
            row = table1.NewRow();
            row["id"] = i;
            row["item"] = i;
            table1.Rows.Add(row);
        }

        // Accept changes.
        table1.AcceptChanges();
        PrintValues(table1, "Original values");

        // Create a second DataTable identical to the first.
        DataTable table2 = table1.Clone();

        // Add three rows. Note that the id column can't be the 
        // same as existing rows in the original table.
        row = table2.NewRow();
        row["id"] = 14;
        row["item"] = 774;
        table2.Rows.Add(row);

        row = table2.NewRow();
        row["id"] = 12;
        row["item"] = 555;
        table2.Rows.Add(row);

        row = table2.NewRow();
        row["id"] = 13;
        row["item"] = 665;
        table2.Rows.Add(row);

        // Merge table2 into the table1.
        Console.WriteLine("Merging");
        table1.Merge(table2);
        PrintValues(table1, "Merged With table1");

    }

    private static void Row_Changed(object sender, 
        DataRowChangeEventArgs e)
    {
        Console.WriteLine("Row changed {0}\t{1}", 
            e.Action, e.Row.ItemArray[0]);
    }

    private static void PrintValues(DataTable table, string label)
    {
        // Display the values in the supplied DataTable:
        Console.WriteLine(label);
        foreach (DataRow row in table.Rows)
        {
            foreach (DataColumn col in table.Columns)
            {
                Console.Write("\t " + row[col].ToString());
            }
            Console.WriteLine();
        }
    }
    // </Snippet1>
}

