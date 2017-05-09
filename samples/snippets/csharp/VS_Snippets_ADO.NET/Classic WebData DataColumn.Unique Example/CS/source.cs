using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void AddColumn(DataTable table)
    {
        // Add a DataColumn to the collection and set its properties.
        // The constructor sets the ColumnName of the column.
        DataColumn column = new DataColumn("Total");
        column.DataType = System.Type.GetType("System.Decimal");
        column.ReadOnly = true;
        column.Expression = "UnitPrice * Quantity";
        column.Unique = false;
    }
    // </Snippet1>

}
