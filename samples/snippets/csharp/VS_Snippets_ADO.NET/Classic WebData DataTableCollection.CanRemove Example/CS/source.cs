using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;


public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid DataGrid1;

    // <Snippet1>
    private void RemoveTables()
    {
        DataTable table;

        // presuming a DataGrid is displaying more than one table, get its DataSet.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;
        while (thisDataSet.Tables.Count > 0)
        {
            table = thisDataSet.Tables[0];
            if (thisDataSet.Tables.CanRemove(table))
                thisDataSet.Tables.Remove(table);
        }
    }
    // </Snippet1>

}
