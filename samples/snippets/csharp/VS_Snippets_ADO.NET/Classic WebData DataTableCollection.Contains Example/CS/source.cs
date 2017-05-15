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
    private void TestForTableName()
    {
        // Get the DataSet of a DataGrid.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;

        // Get the DataTableCollection through the Tables property.
        DataTableCollection tablesCol = thisDataSet.Tables;

        // Check if the named table exists.
        if (tablesCol.Contains("Suppliers")) 
            Console.WriteLine("Table named Suppliers exists");
    }
    // </Snippet1>

}
