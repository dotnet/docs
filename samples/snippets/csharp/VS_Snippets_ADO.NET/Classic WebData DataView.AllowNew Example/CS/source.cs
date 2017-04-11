using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;


public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid DataGrid1;

    // <Snippet1>
    private void AddNew()
    {
        DataTable table = new DataTable();

        // Not shown: code to populate DataTable.

        DataView view = new DataView(table);
        view.AllowNew = true;
        DataRowView rowView = view.AddNew();
        rowView["ProductName"] = "New Product Name";
    }
    // </Snippet1>

}
