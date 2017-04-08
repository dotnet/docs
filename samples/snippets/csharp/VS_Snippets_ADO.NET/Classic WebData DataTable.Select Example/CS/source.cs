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
    private void GetRows()
    {
        // Get the DataTable of a DataSet.
        DataTable table = DataSet1.Tables["Suppliers"];
        DataRow[] rows = table.Select();

        // Print the value one column of each DataRow.
        for(int i = 0; i < rows.Length ; i++)
        {
            Console.WriteLine(rows[i]["CompanyName"]);
        }
    }
    // </Snippet1>

}
