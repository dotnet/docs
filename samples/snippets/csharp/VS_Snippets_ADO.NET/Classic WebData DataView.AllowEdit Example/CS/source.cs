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
    private void EditRow(DataView view)
    {
        view.AllowEdit = true;
        view[0].BeginEdit();
        view[0]["FirstName"] = "Mary";
        view[0]["LastName"] = "Jones";
        view[0].EndEdit();
    }
    // </Snippet1>

}