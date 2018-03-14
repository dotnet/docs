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
    private void CheckAllowDelete(DataRow rowToDelete)
    {
        DataView view = new DataView(DataSet1.Tables["Suppliers"]);
        if (view.AllowDelete)
            rowToDelete.Delete();
    }
    // </Snippet1>

}
