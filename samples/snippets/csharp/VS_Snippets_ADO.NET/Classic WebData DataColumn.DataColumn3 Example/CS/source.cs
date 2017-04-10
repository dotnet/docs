using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void AddDataColumn(DataTable table)
    {
        System.Type decimalType;
        decimalType = System.Type.GetType("System.Decimal");

        // Create the column. The name is 'Tax,' with data type Decimal,and 
        // an expression ('UnitPrice * .0862) to calculate the tax.
        DataColumn column = new DataColumn("Tax", 
            decimalType, "UnitPrice * .0862");

        // Set various properties.
        column.AutoIncrement = false;
        column.ReadOnly = true;

        // Add to Columns collection.;
        table.Columns.Add(column);
    }
    // </Snippet1>

}
