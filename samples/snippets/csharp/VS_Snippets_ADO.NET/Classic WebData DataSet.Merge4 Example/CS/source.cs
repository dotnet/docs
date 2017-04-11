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
    private void DemonstrateMergeTableAddSchema()
    {
        // Create a DataSet with one table, two columns, and ten rows.
        DataSet dataSet = new DataSet("dataSet");
        DataTable table = new DataTable("Items");

        // Add table to the DataSet
        dataSet.Tables.Add(table);

        // Create and add two columns to the DataTable
        DataColumn idColumn = new DataColumn("id", 
            Type.GetType("System.Int32"),"");
        idColumn.AutoIncrement=true;
        DataColumn itemColumn = new DataColumn("Item", 
            Type.GetType("System.Int32"),"");
        table.Columns.Add(idColumn);
        table.Columns.Add(itemColumn);

        // Set the primary key to the first column.
        table.PrimaryKey = new DataColumn[1]{ idColumn };

        // Add RowChanged event handler for the table.
        table.RowChanged+= new DataRowChangeEventHandler(Row_Changed);

        // Add ten rows.
        for(int i = 0; i <10;i++)
        {
            DataRow row=table.NewRow();
            row["Item"]= i;
            table.Rows.Add(row);
        }

        // Accept changes.
        dataSet.AcceptChanges();
        PrintValues(dataSet, "Original values");

        // Create a second DataTable identical to the first, with
        // one extra column using the Clone method.
        DataTable cloneTable = table.Clone();
        cloneTable.Columns.Add("extra", typeof(string));

        // Add two rows. Note that the id column can'table be the 
        // same as existing rows in the DataSet table.
        DataRow newRow;
        newRow=cloneTable.NewRow();
        newRow["id"]= 12;
        newRow["Item"]=555;
        newRow["extra"]= "extra Column 1";
        cloneTable.Rows.Add(newRow);
 
        newRow=cloneTable.NewRow();
        newRow["id"]= 13;
        newRow["Item"]=665;
        newRow["extra"]= "extra Column 2";
        cloneTable.Rows.Add(newRow);

        // Merge the table into the DataSet.
        Console.WriteLine("Merging");
        dataSet.Merge(cloneTable,false,MissingSchemaAction.Add);
        PrintValues(dataSet, "Merged With Table, Schema Added");
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
