using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;


public class Form1: Form
{
    protected ComboBox Combo1;
    protected DataGrid DataGrid1;
    protected DataSet DataSet1;

    // <Snippet1>
    private void MakeDataView()
    {
        DataView view = new DataView(DataSet1.Tables["Suppliers"]);

        // Bind a ComboBox control to the DataView.
        Combo1.DataSource = view;
        Combo1.DisplayMember = "Suppliers.CompanyName";
    }
    // </Snippet1>

}
