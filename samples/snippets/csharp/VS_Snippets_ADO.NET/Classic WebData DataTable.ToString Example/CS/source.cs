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
    private void PrintToString(DataSet dataSet)
    {
        foreach(DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.ToString());
        }
    }
    // </Snippet1>

}
