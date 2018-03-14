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
    private void GetPrimaryKeys(DataTable table)
    {
        // Create the array for the columns.
        DataColumn[] columns;
        columns = table.PrimaryKey;

        // Get the number of elements in the array.
        Console.WriteLine("Column Count: " + columns.Length);
        for(int i = 0; i < columns.Length; i++)
        {
            Console.WriteLine(columns[i].ColumnName + columns[i].DataType);
        }
    }
 
    private void SetPrimaryKeys()
    {
        // Create a new DataTable and set two DataColumn objects as primary keys.
        DataTable table = new DataTable();
        DataColumn[] keys = new DataColumn[2];
        DataColumn column;

        // Create column 1.
        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName= "FirstName";

        // Add the column to the DataTable.Columns collection.
        table.Columns.Add(column);

        // Add the column to the array.
        keys[0] = column;
 
        // Create column 2 and add it to the array.
        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "LastName";
        table.Columns.Add(column);

        // Add the column to the array.
        keys[1] = column;

        // Set the PrimaryKeys property to the array.
        table.PrimaryKey = keys;
    }
    // </Snippet1>

}
