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
        DataTable itemsTable = new DataTable("Items");

        // Add columns
        DataColumn idColumn = new DataColumn("id", typeof(System.Int32));
        DataColumn itemColumn = new DataColumn("item", typeof(System.Int32));
        itemsTable.Columns.Add(idColumn);
        itemsTable.Columns.Add(itemColumn);

        // Set the primary key column.
        itemsTable.PrimaryKey = new DataColumn[] { idColumn };

        // Add RowChanged event handler for the table.
        itemsTable.RowChanged += 
            new System.Data.DataRowChangeEventHandler(Row_Changed);

        // Add ten rows.
        DataRow row;
        for (int i = 0; i <= 9; i++)
        {
            row = itemsTable.NewRow();
            row["id"] = i;
            row["item"] = i;
            itemsTable.Rows.Add(row);
        }

        // Accept changes.
        itemsTable.AcceptChanges();
        PrintValues(itemsTable, "Original values");

        // Create a second DataTable identical to the first.
        DataTable itemsClone = itemsTable.Clone();

        // Add column to the second column, so that the 
        // schemas no longer match.
        itemsClone.Columns.Add("newColumn", typeof(System.String));

        // Add three rows. Note that the id column can't be the 
        // same as existing rows in the original table.
        row = itemsClone.NewRow();
        row["id"] = 14;
        row["item"] = 774;
        row["newColumn"] = "new column 1";
        itemsClone.Rows.Add(row);

        row = itemsClone.NewRow();
        row["id"] = 12;
        row["item"] = 555;
        row["newColumn"] = "new column 2";
        itemsClone.Rows.Add(row);

        row = itemsClone.NewRow();
        row["id"] = 13;
        row["item"] = 665;
        row["newColumn"] = "new column 3";
        itemsClone.Rows.Add(row);

        // Merge itemsClone into the itemsTable.
        Console.WriteLine("Merging");
        itemsTable.Merge(itemsClone, false, MissingSchemaAction.Add);
        PrintValues(itemsTable, "Merged With itemsTable, schema added");
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

