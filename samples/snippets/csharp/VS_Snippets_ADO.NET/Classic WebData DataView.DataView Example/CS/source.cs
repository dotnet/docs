using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;


public class Form1: Form
{
    protected TextBox Text1;
    protected DataSet DataSet1;
    protected DataGrid DataGrid1;

    // <Snippet1>
    private void MakeDataView()
    {
        DataView view = new DataView();
    
        view.Table = DataSet1.Tables["Suppliers"];
        view.AllowDelete = true;
        view.AllowEdit = true;
        view.AllowNew = true;
        view.RowFilter = "City = 'Berlin'";
        view.RowStateFilter = DataViewRowState.ModifiedCurrent;
        view.Sort = "CompanyName DESC";
    
        // Simple-bind to a TextBox control
        Text1.DataBindings.Add("Text", view, "CompanyName");
    }
    // </Snippet1>

}
