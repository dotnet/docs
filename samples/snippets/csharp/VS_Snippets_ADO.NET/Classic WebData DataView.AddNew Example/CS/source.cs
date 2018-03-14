using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;


public class Form1: Form
{
    protected DataTable DataTable1;
    protected DataGrid DataGrid1;

    // <Snippet1>
    private void AddNewDataRowView(DataView view)
    {
        DataRowView rowView = view.AddNew();

        // Change values in the DataRow.
        rowView["ColumnName"] = "New value";
        rowView.EndEdit();
    }
    // </Snippet1>

}
