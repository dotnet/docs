using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void TestAndRemove(DataColumn colToRemove)
    {
        DataColumnCollection columns; 
        // Get the DataColumnCollection from a DataTable in a DataSet.
        columns = DataSet1.Tables["Orders"].Columns;
 
        if(columns.Contains(colToRemove.ColumnName))
        {
            columns.Remove(colToRemove);
        }
    }
    // </Snippet1>

}
