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
    private void SetMinimumCapacity(DataTable table)
    {
        // Change the MinimumCapacity.
        table.MinimumCapacity = 100;
    }
    // </Snippet1>

}
