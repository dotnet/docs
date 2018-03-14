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
    private void ClearTable(DataTable table)
    {
        try
        {
            table.Clear();
        }
        catch (DataException e)
        {
            // Process exception and return.
            Console.WriteLine("Exception of type {0} occurred.", 
                e.GetType());
        }
    
    }
    // </Snippet1>

}
