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
    private void BindDataGrid()
    {
        DataTable table = new DataTable();
    
        // Insert code to populate a DataTable with data.

        // Bind grid to DataTable.
        dataGrid1.DataSource = table;
    }
 
    private void ChangeRowFilter()
    {
        DataTable gridTable = (DataTable) dataGrid1.DataSource;

        // Set the RowFilter to display a company names that 
        // begin with A through I..
        gridTable.DefaultView.RowFilter = "CompanyName < 'I'";
    }
    // </Snippet1>

}
