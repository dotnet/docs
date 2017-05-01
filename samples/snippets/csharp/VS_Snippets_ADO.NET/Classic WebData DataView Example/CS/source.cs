// <Snippet1>
using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;



    private void DemonstrateDataView()
    {
        // Create one DataTable with one column.
        DataTable table = new DataTable("table");
        DataColumn colItem = new DataColumn("item",
            Type.GetType("System.String"));
        table.Columns.Add(colItem);

        // Add five items.
        DataRow NewRow;
        for(int i = 0; i <5; i++)
        {
            NewRow = table.NewRow();
            NewRow["item"] = "Item " + i;
            table.Rows.Add(NewRow);
        }
        // Change the values in the table.
        table.AcceptChanges();
        table.Rows[0]["item"]="cat";
        table.Rows[1]["item"] = "dog";
 
        // Create two DataView objects with the same table.
        DataView firstView = new DataView(table);
        DataView secondView = new DataView(table);
 
        // Print current table values.
        PrintTableOrView(table,"Current Values in Table");
    
        // Set first DataView to show only modified 
        // versions of original rows.
        firstView.RowStateFilter=DataViewRowState.ModifiedOriginal;

        // Print values.   
        PrintTableOrView(firstView,"First DataView: ModifiedOriginal");

        // Add one New row to the second view.
        DataRowView rowView;
        rowView=secondView.AddNew();
        rowView["item"] = "fish";

        // Set second DataView to show modified versions of 
        // current rows, or New rows.
        secondView.RowStateFilter=DataViewRowState.ModifiedCurrent 
            | DataViewRowState.Added;
        // Print modified and Added rows.
        PrintTableOrView(secondView, 
            "Second DataView: ModifiedCurrent | Added");
    }
 
    private void PrintTableOrView(DataTable table, string label)
    {
        // This function prints values in the table or DataView.
        Console.WriteLine("\n" + label);
        for(int i = 0; i<table.Rows.Count;i++)
        {
            Console.WriteLine("\table" + table.Rows[i]["item"]);
        }
        Console.WriteLine();
    }
 
    private void PrintTableOrView(DataView view, string label)
    {
 
        // This overload prints values in the table or DataView.
        Console.WriteLine("\n" + label);
        for(int i = 0; i<view.Count;i++)
        {
            Console.WriteLine("\table" + view[i]["item"]);
        }
        Console.WriteLine();
    }
}
// </Snippet1>