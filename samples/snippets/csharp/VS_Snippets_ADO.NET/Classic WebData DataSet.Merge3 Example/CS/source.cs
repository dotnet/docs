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
    private void DemonstrateMergeTable()
    {
        // Create a DataSet with one table, two columns, and ten rows.
        DataSet dataSet = new DataSet("dataSet");
        DataTable table = new DataTable("Items");

        // Add table to the DataSet
        dataSet.Tables.Add(table);

        // Add columns
        DataColumn c1 = new DataColumn("id", 
            Type.GetType("System.Int32"),"");
        DataColumn c2 = new DataColumn("Item", 
            Type.GetType("System.Int32"),"");
        table.Columns.Add(c1);
        table.Columns.Add(c2);

        // DataColumn array to set primary key.
        DataColumn[] keyCol= new DataColumn[1];

        // Set primary key column.
        keyCol[0]= c1;
        table.PrimaryKey=keyCol;

        // Add a RowChanged event handler for the table.
        table.RowChanged += new 
            DataRowChangeEventHandler(Row_Changed);

        // Add ten rows.
        for(int i = 0; i <10;i++)
        {
            DataRow row=table.NewRow();
            row["id"] = i;
            row["Item"]= i;
            table.Rows.Add(row);
        }
        // Accept changes.
        dataSet.AcceptChanges();

        PrintValues(dataSet, "Original values");

        // Create a second DataTable identical to the first.
        DataTable t2 = table.Clone();

        // Add three rows. Note that the id column can'te be the
        // same as existing rows in the DataSet table.
        DataRow newRow;
        newRow = t2.NewRow();
        newRow["id"] = 14;
        newRow["item"] = 774;

        //Note the alternative method for adding rows.
        t2.Rows.Add(new Object[] { 12, 555 });
        t2.Rows.Add(new Object[] { 13, 665 });

        // Merge the table into the DataSet
        Console.WriteLine("Merging");
        dataSet.Merge(t2);
        PrintValues(dataSet, "Merged With table.");

    }
 
    private void Row_Changed(object sender, 
        DataRowChangeEventArgs e)
    {
        Console.WriteLine("Row Changed " + e.Action.ToString() 
            + "\table" + e.Row.ItemArray[0]);
    }
 
    private void PrintValues(DataSet dataSet, string label)
    {
        Console.WriteLine("\n" + label);
        foreach(DataTable table in dataSet.Tables)
        {
            Console.WriteLine("TableName: " + table.TableName);
            foreach(DataRow row in table.Rows)
            {
                foreach(DataColumn column in table.Columns)
                {
                    Console.Write("\table " + row[column] );
                }
                Console.WriteLine();
            }
        }
    }
    // </Snippet1>

}
