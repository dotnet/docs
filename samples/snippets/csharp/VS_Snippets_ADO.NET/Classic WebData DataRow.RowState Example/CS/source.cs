using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void DemonstrateRowState()
    {
        // Run a function to create a DataTable with one column.
        DataTable table = MakeTable();
        DataRow row;
 
        // Create a new DataRow.
        row = table.NewRow();
        // Detached row.
        Console.WriteLine("New Row " + row.RowState);
 
        table.Rows.Add(row);
        // New row.
        Console.WriteLine("AddRow " + row.RowState);
 
        table.AcceptChanges();
        // Unchanged row.
        Console.WriteLine("AcceptChanges " + row.RowState);
 
        row["FirstName"] = "Scott";
        // Modified row.
        Console.WriteLine("Modified " + row.RowState);
 
        row.Delete();
        // Deleted row.
        Console.WriteLine("Deleted " + row.RowState);
    }
 
    private DataTable MakeTable()
    {
        // Make a simple table with one column.
        DataTable table = new DataTable("table");
        DataColumn dcFirstName = new DataColumn(
            "FirstName", Type.GetType("System.String"));
        table.Columns.Add(dcFirstName);
        return table;
    }
    // </Snippet1>

}
