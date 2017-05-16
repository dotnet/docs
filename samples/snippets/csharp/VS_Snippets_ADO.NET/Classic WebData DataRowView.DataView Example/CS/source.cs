using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private DataView ReturnDataView(DataRowView rowView)
    {
        return rowView.DataView;
    }
    // </Snippet1>

}
