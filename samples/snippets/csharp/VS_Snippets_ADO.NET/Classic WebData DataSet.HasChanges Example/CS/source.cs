using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;
    protected OleDbDataAdapter myOleDbDataAdapter;

    // <Snippet1>
    private void UpdateDataSet(DataSet dataSet)
    {
        // Check for changes with the HasChanges method first.
        if(!dataSet.HasChanges()) return;

        // Create temporary DataSet variable.
        DataSet tempDataSet;

        // GetChanges for modified rows only.
        tempDataSet = dataSet.GetChanges(DataRowState.Modified);

        // Check the DataSet for errors.
        if(tempDataSet.HasErrors)
        {
            // Insert code to resolve errors.
        }
        // After fixing errors, update the data source with 
        // the DataAdapter used to create the DataSet.
        myOleDbDataAdapter.Update(tempDataSet);
    }
    // </Snippet1>

}
