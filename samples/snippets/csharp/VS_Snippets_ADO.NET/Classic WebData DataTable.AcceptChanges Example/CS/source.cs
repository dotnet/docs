using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void AcceptOrReject(DataTable table)
    {
        // If there are errors, try to reconcile.
        if(table.HasErrors)
        { 
            if(Reconcile(table))
            {
                // Fixed all errors.
                table.AcceptChanges();
            }
            else
            {
                // Couldn'table fix all errors.
                table.RejectChanges();
            }
        }
        else
            // If no errors, AcceptChanges.
            table.AcceptChanges();
    }
 
    private bool Reconcile(DataTable thisTable)
    {
        foreach(DataRow row in thisTable.Rows)
        {
            //Insert code to try to reconcile error.

            // If there are still errors return immediately
            // since the caller rejects all changes upon error.
            if(row.HasErrors)
                return false;
        }
        return true;
    }
    // </Snippet1>

}
