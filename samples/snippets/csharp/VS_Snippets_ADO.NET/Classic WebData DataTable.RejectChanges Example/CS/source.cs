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
    private void ShowRejectChanges(DataTable table)
    {
        // Print the values of row 1, in the column named "CompanyName."
        Console.WriteLine(table.Rows[1]["CompanyName"]);

        // Make Changes to the column named "CompanyName."
        table.Rows[1]["CompanyName"] = "Taro";

        // Reject the changes.
        table.RejectChanges();

        // Print the original values:
        Console.WriteLine(table.Rows[1]["CompanyName"]);
    }
    // </Snippet1>

}
