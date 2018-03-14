using System;
using System.Data;
using System.Data.OleDb;

public class Sample
{
    // <Snippet1>
    private void UpdateDataTable(DataTable table, 
        OleDbDataAdapter myDataAdapter)
    {
        DataTable xDataTable = table.GetChanges();

        // Check the DataTable for errors.
        if (xDataTable.HasErrors)
        {
            // Insert code to resolve errors.
        }

        // After fixing errors, update the database with the DataAdapter 
        myDataAdapter.Update(xDataTable);
    }
    // </Snippet1>
}