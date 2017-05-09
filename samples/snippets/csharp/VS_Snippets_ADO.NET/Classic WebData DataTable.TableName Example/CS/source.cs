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
    private void GetTableNames(DataSet dataSet)
    {
        // Print each table's TableName.
        foreach(DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.TableName);
        }
    }
    // </Snippet1>

}
