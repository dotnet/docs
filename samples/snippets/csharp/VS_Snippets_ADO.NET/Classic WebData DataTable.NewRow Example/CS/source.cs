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
    private void MakeDataTableAndDisplay()
    {
        // Create new DataTable and DataSource objects.
        DataTable table = new DataTable();

        // Declare DataColumn and DataRow variables.
        DataColumn column;
        DataRow row; 
        DataView view;

        // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Int32");
        column.ColumnName = "id";
        table.Columns.Add(column);
 
        // Create second column.
        column = new DataColumn();
        column.DataType = Type.GetType("System.String");
        column.ColumnName = "item";
        table.Columns.Add(column);
 
        // Create new DataRow objects and add to DataTable.    
        for(int i = 0; i < 10; i++)
        {
            row = table.NewRow();
            row["id"] = i;
            row["item"] = "item " + i.ToString();
            table.Rows.Add(row);
        }
 
        // Create a DataView using the DataTable.
        view = new DataView(table);

        // Set a DataGrid control's DataSource to the DataView.
        dataGrid1.DataSource = view;
    }
    // </Snippet1>

}
