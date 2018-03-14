using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void PrintRows(DataTable table)
    {
        // Print the CompanyName column for every row using the index.
        for(int i = 0; i < table.Rows.Count; i++)
        {
            Console.WriteLine(table.Rows[i]["CompanyName"]);
        }
    }
    // </Snippet1>

}
