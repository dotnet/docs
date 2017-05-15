using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void PrintColumnNames(DataSet dataSet)
    {
        // For each DataTable, print the ColumnName.
        foreach(DataTable table in dataSet.Tables)
        {
            foreach(DataColumn column in table.Columns)
            {
                Console.WriteLine(column.ColumnName);
            }
        }
    }
 
    private void AddColumn(DataTable table)
    {
        DataColumn column;
        column = new DataColumn();
        column.ColumnName = "SupplierID";
        column.DataType = System.Type.GetType("System.String");
        column.Unique = true;
        column.AutoIncrement = false;
        column.Caption = "SupplierID";
        column.ReadOnly = false;

        // Add the column to the table's columns collection.
        table.Columns.Add(column);
    }
    // </Snippet1>

}
