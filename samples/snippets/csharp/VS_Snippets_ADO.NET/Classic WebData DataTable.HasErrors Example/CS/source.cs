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
    private void CheckForErrors(DataSet dataSet) 
    {
        // Invoke GetChanges on the DataSet to create a reduced set.
        DataSet thisDataSet = dataSet.GetChanges();

        // Check each table's HasErrors property.
        foreach(DataTable table in thisDataSet.Tables) 
        {
            // If HasErrors is true, reconcile errors.
            if(table.HasErrors) 
            {
                // Insert code to reconcile errors.
            }
        }
    }
    // </Snippet1>

}
