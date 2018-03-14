using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void GetIndex(DataTable table)
    {
        DataColumnCollection columns = table.Columns;
        if(columns.Contains("City")) 
        {
            Console.WriteLine(columns.IndexOf("City"));
        }
    }
    // </Snippet1>

}
