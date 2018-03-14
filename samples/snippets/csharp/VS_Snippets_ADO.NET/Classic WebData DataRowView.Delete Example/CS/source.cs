using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void DeleteRow()
    {
        DataRowView row;
        DataView view = (DataView) dataGrid1.DataSource;
        row = view[dataGrid1.CurrentCell.RowNumber];
        row.Delete();
    }
    // </Snippet1>

}
