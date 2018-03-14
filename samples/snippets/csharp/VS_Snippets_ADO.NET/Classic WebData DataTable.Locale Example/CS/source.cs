using System;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void ChangeCultureInfo(DataTable table)
    {
        // Print the LCID  of the present CultureInfo.
        Console.WriteLine(table.Locale.LCID);

        // Create a new CultureInfo for the United Kingdom.
        CultureInfo myCultureInfo = new CultureInfo("en-gb");
        table.Locale = myCultureInfo;

        // Print the new LCID.
        Console.WriteLine(table.Locale.LCID); 
    }
    // </Snippet1>

}
