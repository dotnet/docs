using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void SetDataRowView()
    {
        DataView view = (DataView) dataGrid1.DataSource;

        // Set the filter to display only those rows that were modified.
        view.RowStateFilter=DataViewRowState.ModifiedCurrent;

        // Change the value of the CompanyName column for each modified row.
        foreach(DataRowView rowView in view)
        {
            rowView["CompanyName"] += " new value";
        }
    }
    // </Snippet1>

}
