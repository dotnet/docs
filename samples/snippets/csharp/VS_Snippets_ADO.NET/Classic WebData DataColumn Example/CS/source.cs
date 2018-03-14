using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void MakeTable()
    { 
        // Create a DataTable. 
        DataTable table = new DataTable("Product");

        // Create a DataColumn and set various properties. 
        DataColumn column = new DataColumn(); 
        column.DataType = System.Type.GetType("System.Decimal"); 
        column.AllowDBNull = false; 
        column.Caption = "Price"; 
        column.ColumnName = "Price"; 
        column.DefaultValue = 25; 

        // Add the column to the table. 
        table.Columns.Add(column); 

        // Add 10 rows and set values. 
        DataRow row; 
        for(int i = 0; i < 10; i++)
        { 
            row = table.NewRow(); 
            row["Price"] = i + 1; 

            // Be sure to add the new row to the 
            // DataRowCollection. 
            table.Rows.Add(row); 
        } 
    }
    // </Snippet1>

}
