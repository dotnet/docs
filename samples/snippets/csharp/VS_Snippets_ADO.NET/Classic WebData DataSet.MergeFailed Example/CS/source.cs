using System;
using System.Data;

public class Sample
{
    public static void Main()
    {
        DemonstrateMergeFailedEvent();
    }

    // <Snippet1>

    private static void DemonstrateMergeFailedEvent()
    {
        // Create a DataSet with one table containing two columns.
        DataSet dataSet = new DataSet("dataSet");
        DataTable table = new DataTable("Items");
	
        // Add table to the DataSet.
        dataSet.Tables.Add(table);

        // Add two columns to the DataTable.
        table.Columns.Add("id", typeof(int));
        table.Columns.Add("item", typeof(int));

        // Set the primary key to the first column.
        table.PrimaryKey = new DataColumn[] { table.Columns["id"] };

        // Add MergeFailed event handler for the table.
        dataSet.MergeFailed += new MergeFailedEventHandler(Merge_Failed);

        // Create a second DataTable identical to the first, 
        DataTable t2 = table.Clone();

        // Set the primary key of the new table to the second column.
        // This will cause the MergeFailed event to be raised when the
        // table is merged into the DataSet.
        t2.PrimaryKey = new DataColumn[] { t2.Columns["item"] };
	
        // Merge the table into the DataSet.
        Console.WriteLine("Merging...");
        dataSet.Merge(t2, false, MissingSchemaAction.Add);
    }

    private static void Merge_Failed(object sender, MergeFailedEventArgs e)
    {
        Console.WriteLine("Merge_Failed Event: '{0}'", e.Conflict);
    }

    // </Snippet1>
}

