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

    protected OleDbDataAdapter adapter;


    // <Snippet1>
    private void UpdateDataSet(DataSet dataSet)
    {
        // Check for changes with the HasChanges method first.
        if(!dataSet.HasChanges(DataRowState.Modified)) return;

        // Create temporary DataSet variable and
        // GetChanges for modified rows only.
        DataSet tempDataSet = 
            dataSet.GetChanges(DataRowState.Modified);

        // Check the DataSet for errors.
        if(tempDataSet.HasErrors)
        {
            // Insert code to resolve errors.
        }
        // After fixing errors, update the data source with  
        // the DataAdapter used to create the DataSet.
        adapter.Update(tempDataSet);
    }
    // </Snippet1>

}
