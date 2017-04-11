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
        // Set the name of the table to test for and remove.
        string name = "Suppliers";

        // Presuming a DataGrid is displaying more than one table, get its DataSet.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;
        DataTableCollection tablesCol = thisDataSet.Tables;
        if (tablesCol.Contains(name) && tablesCol.CanRemove(tablesCol[name])) 
            tablesCol.Remove(name);
    }
    // </Snippet1>

}