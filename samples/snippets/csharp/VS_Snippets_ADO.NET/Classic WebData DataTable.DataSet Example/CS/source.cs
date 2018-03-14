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
    private DataSet GetDataSetFromTable()
    {
        DataTable table;
 
        // Check to see if the DataGrid's DataSource
        // is a DataTable.
        if( dataGrid1.DataSource is DataTable)
        {
            table = (DataTable) dataGrid1.DataSource;
            // Return the DataTable's DataSet
            return table.DataSet;
        }
        else
        {
            return null;
        }
    }
    // </Snippet1>

}
