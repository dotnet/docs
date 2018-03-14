using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void PrintDataTableColumnInfo(DataTable table)
    {
        // Use a DataTable object's DataColumnCollection.
        DataColumnCollection columns = table.Columns;

        // Print the ColumnName and DataType for each column.
        foreach(DataColumn column in columns)
        {
            Console.WriteLine(column.ColumnName);
            Console.WriteLine(column.DataType);
        }
    }
    // </Snippet1>

}
