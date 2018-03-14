using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet ds;


    // <Snippet1>
    private void RemoveColumnByName(string columnName)
    {
        // Get the DataColumnCollection from a DataTable in a DataSet.
        DataColumnCollection columns = 
            ds.Tables["Suppliers"].Columns;

        if(columns.Contains(columnName))
            if(columns.CanRemove(columns[columnName])) 
                columns.Remove(columnName);
    }
    // </Snippet1>

}
