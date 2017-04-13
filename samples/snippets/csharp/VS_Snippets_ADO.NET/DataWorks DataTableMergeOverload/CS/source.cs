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
        DataColumn idColumn = new DataColumn("id", typeof(System.Int32));
        DataColumn itemColumn = new DataColumn("item", typeof(System.Int32));
        table1.Columns.Add(idColumn);
        table1.Columns.Add(itemColumn);

        // Set the primary key column.
        table1.PrimaryKey = new DataColumn[] { idColumn };

        // Add RowChanged event handler for the table.
        table1.RowChanged += new 
            System.Data.DataRowChangeEventHandler(Row_Changed);

        // Add ten rows.
        DataRow row;
        for (int i = 0; i <= 9; i++)
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

        // Add column to the second column, so that the 
        // schemas no longer match.
        table2.Columns.Add("newColumn", typeof(System.String));

        // Add three rows. Note that the id column can't be the 
        // same as existing rows in the original table.
        row = table2.NewRow();
        row["id"] = 14;
        row["item"] = 774;
        row["newColumn"] = "new column 1";
        table2.Rows.Add(row);

        row = table2.NewRow();
        row["id"] = 12;
        row["item"] = 555;
        row["newColumn"] = "new column 2";
        table2.Rows.Add(row);

        row = table2.NewRow();
        row["id"] = 13;
        row["item"] = 665;
        row["newColumn"] = "new column 3";
        table2.Rows.Add(row);

        // Merge table2 into the table1.
        Console.WriteLine("Merging");
        table1.Merge(table2, false, MissingSchemaAction.Add);
        PrintValues(table1, "Merged With table1, schema added");

    }

    private static void Row_Changed(object sender, 
        DataRowChangeEventArgs e)
    {
        Console.WriteLine("Row changed {0}\t{1}", e.Action, 
            e.Row.ItemArray[0]);
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

