using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void CalcColumns()
    {
        DataTable table = new DataTable ();
 
        // Create the first column.
        DataColumn priceColumn = new DataColumn();
        priceColumn.DataType = System.Type.GetType("System.Decimal");
        priceColumn.ColumnName = "price";
        priceColumn.DefaultValue = 50;
         
        // Create the second, calculated, column.
        DataColumn taxColumn = new DataColumn();
        taxColumn.DataType = System.Type.GetType("System.Decimal");
        taxColumn.ColumnName = "tax";
        taxColumn.Expression = "price * 0.0862";
         
        // Create third column.
        DataColumn totalColumn = new DataColumn();
        totalColumn.DataType = System.Type.GetType("System.Decimal");
        totalColumn.ColumnName = "total";
        totalColumn.Expression = "price + tax";
    
        // Add columns to DataTable.
        table.Columns.Add(priceColumn);
        table.Columns.Add(taxColumn);
        table.Columns.Add(totalColumn);

        DataRow row = table.NewRow();
        table.Rows.Add(row);
        DataView view = new DataView(table);
        dataGrid1.DataSource = view;
    }
    // </Snippet1>

}
