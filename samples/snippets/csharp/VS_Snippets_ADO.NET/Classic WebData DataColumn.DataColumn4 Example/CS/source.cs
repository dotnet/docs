using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void CreateComputedColumn(DataTable table)
    {
        System.Type myDataType = 
            System.Type.GetType("System.Decimal");

        // The expression multiplies the "Price" column value 
        // by the "Quantity" to create the "Total" column.
        string expression = "Price * Quantity";

        // Create the column, setting the type to Attribute.
        DataColumn column = new DataColumn("Total", myDataType, 
            expression, MappingType.Attribute);

        // Set various properties.
        column.AutoIncrement = false;
        column.ReadOnly = true;

        // Add the column to a DataTable object's to DataColumnCollection.
        DataSet1.Tables["OrderDetails"].Columns.Add(column);
    }
    // </Snippet1>

}
