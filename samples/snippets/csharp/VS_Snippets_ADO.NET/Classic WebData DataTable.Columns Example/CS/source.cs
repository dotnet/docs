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
    private void PrintValues(DataTable table)
    {
        foreach(DataRow row in table.Rows)
        {
            foreach(DataColumn column in table.Columns)
            {
                Console.WriteLine(row[column]);
            }
        }
    }
    // </Snippet1>

}
