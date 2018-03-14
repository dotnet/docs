


using System;
using System.Collections.Generic;
using System.Text;
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
        // Demonstrate merging, within and without
        // preserving changes.

        // In this example, take these actions:
        // 1. Create a DataTable (table1) and fill the table with data.
        // 2. Create a copy of table1, and modify its data (modifiedTable).
        // 3. Modify data in table1.
        // 4. Make a copy of table1 (table1Copy).
        // 5. Merge the data from modifiedTable into table1 and table1Copy, 
        //    showing the difference between setting the preserveChanges 
        //    parameter to true and false.

        // Create a new DataTable.
        DataTable table1 = new DataTable("Items");

        // Add two columns to the table:
        DataColumn column = new DataColumn("id", typeof(System.Int32));
        column.AutoIncrement = true;
        table1.Columns.Add(column);

        column = new DataColumn("item", typeof(System.String));
        table1.Columns.Add(column);

        // Set primary key column.
        table1.PrimaryKey = new DataColumn[] { table1.Columns[0] };

        // Add some rows.
        DataRow row;
        for (int i = 0; i <= 3; i++)
        {
            row = table1.NewRow();
            row["item"] = "Item " + i;
            table1.Rows.Add(row);
        }

        // Accept changes.
        table1.AcceptChanges();
        PrintValues(table1, "Original values");

        // Using the same schema as the original table, 
        // modify the data for later merge.
        DataTable modifiedTable = table1.Copy();
        foreach (DataRow rowModified in modifiedTable.Rows)
        {
            rowModified["item"] = rowModified["item"].ToString() 
                + " modified";
        }
        modifiedTable.AcceptChanges();

        // Change row values, and add a new row:
        table1.Rows[0]["item"] = "new Item 0";
        table1.Rows[1]["item"] = "new Item 1";

        row = table1.NewRow();
        row["id"] = 4;
        row["item"] = "Item 4";
        table1.Rows.Add(row);

        // Get a copy of the modified data:
        DataTable table1Copy = table1.Copy();
        PrintValues(table1, "Modified and new Values");
        PrintValues(modifiedTable, "Data to be merged into table1");

        // Merge new data into the modified data.
        table1.Merge(modifiedTable, true);
        PrintValues(table1, "Merged data (preserve changes)");

        table1Copy.Merge(modifiedTable, false);
        PrintValues(modifiedTable, "Merged data (don't preserve changes)");
    }


    private static void PrintValues(DataTable table, string label)
    {
        // Display the values in the supplied DataTable:
        Console.WriteLine(label);
        foreach (DataRow row in table.Rows)
        {
            foreach (DataColumn column in table.Columns)
            {
                Console.Write("\t{0}", row[column, DataRowVersion.Current]);
            }
            Console.WriteLine();
        }
    }
    // </Snippet1>
}
