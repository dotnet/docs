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
    private void GetTableByName()
    {
        // Presuming a DataGrid is displaying more than one table, get its DataSet.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;

        // Get the DataTableCollection.
        DataTableCollection tablesCollection = thisDataSet.Tables;

        // Get a specific table by name.
        DataTable table = tablesCollection["Suppliers"];
        Console.WriteLine(table.TableName);
    }
    // </Snippet1>

}
