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
    private void DemonstrateMergeMissingSchema()
    {
        // Create a DataSet with one table, two columns, 
        // and three rows.
        DataSet dataSet = new DataSet("dataSet");
        DataTable table = new DataTable("Items");
        DataColumn idColumn = new DataColumn("id", 
            Type.GetType("System.Int32"));
        idColumn.AutoIncrement=true;
        DataColumn itemColumn = new DataColumn("Item", 
            Type.GetType("System.Int32"));
        // DataColumn array to set primary key.

        DataColumn[] keyColumn= new DataColumn[1];
        DataRow row;
        // Create variable for temporary DataSet. 
        DataSet changeDataSet;

        // Add RowChanged event handler for the table.
        table.RowChanged+= new DataRowChangeEventHandler(
            Row_Changed);
        dataSet.Tables.Add(table);
        table.Columns.Add(idColumn);
        table.Columns.Add(itemColumn);

        // Set primary key column.
        keyColumn[0]= idColumn;
        table.PrimaryKey=keyColumn;

        // Add ten rows.
        for(int i = 0; i <10;i++)
        {
            row=table.NewRow();
            row["Item"]= i;
            table.Rows.Add(row);
        }

        // Accept changes.
        dataSet.AcceptChanges();
        PrintValues(dataSet, "Original values");

        // Change row values.
        table.Rows[0]["Item"]= 50;
        table.Rows[1]["Item"]= 111;

        // Add one row.
        row=table.NewRow();
        row["Item"]=74;
        table.Rows.Add(row);

        // Insert code for error checking. Set one row in error.
        table.Rows[1].RowError= "over 100";
        PrintValues(dataSet, "Modified and New Values");
        // If the table has changes or errors, create a subset DataSet.
        if(dataSet.HasChanges(DataRowState.Modified | 
            DataRowState.Added)& dataSet.HasErrors)
        {
            // Use GetChanges to extract subset.
            changeDataSet = dataSet.GetChanges(
                DataRowState.Modified|DataRowState.Added);
            PrintValues(changeDataSet, "Subset values");

            // Insert code to reconcile errors. Reject the changes.
            foreach(DataTable changeTable in changeDataSet.Tables)
            {
                if (changeTable.HasErrors)
                {
                    foreach(DataRow changeRow in changeTable.Rows)
                    {
                        //Console.WriteLine(changeRow["Item"]);
                        if((int)changeRow["Item", 
                            DataRowVersion.Current ]> 100)
                        {
                            changeRow.RejectChanges();
                            changeRow.ClearErrors();
                        }
                    }
                }
            }
            // Add a column to the changeDataSet to change the schema.
            changeDataSet.Tables["Items"].Columns.Add(
                new DataColumn("newColumn"));
            PrintValues(changeDataSet, "Reconciled subset values");

            // Add values to the rows for each column.
            foreach(DataRow rowItem in changeDataSet.Tables["Items"].Rows)
            {
                rowItem["newColumn"] = "my new schema value";
            }
            // Merge changes back to first DataSet.
            dataSet.Merge(changeDataSet, false,
                System.Data.MissingSchemaAction.Add);
        }
        PrintValues(dataSet, "Merged Values");
    }
 
    private void Row_Changed(object sender, DataRowChangeEventArgs e)
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
