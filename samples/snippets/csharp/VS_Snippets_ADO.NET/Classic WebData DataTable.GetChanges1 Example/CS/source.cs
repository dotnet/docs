using System;
using System.Data;
using System.Data.OleDb;

public class Sample
{
    // <Snippet1>
    private void ProcessDeletes(DataTable table, 
        OleDbDataAdapter adapter)
    {
        DataTable changeTable = table.GetChanges(DataRowState.Deleted);

        // Check the DataTable for errors.
        if (changeTable.HasErrors)
        {
            // Insert code to resolve errors.
        }

        // After fixing errors, update the database with the DataAdapter 
        adapter.Update(changeTable);
    }
    // </Snippet1>
}