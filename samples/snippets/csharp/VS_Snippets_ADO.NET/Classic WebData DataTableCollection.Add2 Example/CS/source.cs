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
    private void AddTables()
    {
        // Presuming a DataGrid is displaying more than one table, 
        // get its DataSet.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;

        for (int i = 0; i < 3; i++)
            thisDataSet.Tables.Add();
        Console.WriteLine(thisDataSet.Tables.Count.ToString() 
            + " tables");
        foreach (DataTable table in thisDataSet.Tables)
            Console.WriteLine(table.TableName);
    }
    // </Snippet1>

}
