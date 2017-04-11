using System;
using System.Data;
using System.Data.OleDb;

public class Sample
{
    static void Main()
    {
        DataTableRowChanged();
    }
    // <Snippet1>
    private static void DataTableRowChanged()
    {
        DataTable custTable = new DataTable("Customers");
        // add columns
        custTable.Columns.Add("id", typeof(int));
        custTable.Columns.Add("name", typeof(string));
        custTable.Columns.Add("address", typeof(string));

        // set PrimaryKey
        custTable.Columns[ "id" ].Unique = true;
        custTable.PrimaryKey = new DataColumn[] { custTable.Columns["id"] };

        // add a RowChanged event handler for the table.
        custTable.RowChanged += new DataRowChangeEventHandler(Row_Changed);


        // add ten rows
        for(int id=1; id<=10; id++)
        {
            custTable.Rows.Add(
                new object[] { id, string.Format("customer{0}", id), 
                string.Format("address{0}", id) });
        }
	
        custTable.AcceptChanges();

        // change the name column in all the rows
        foreach(DataRow row in custTable.Rows)
        {
            row["name"] = string.Format("vip{0}", row["id"]);
        }

    }

    private static void Row_Changed(object sender, DataRowChangeEventArgs e)
    {
        Console.WriteLine("Row_Changed Event: name={0}; action={1}", 
            e.Row["name"], e.Action);
    }
    // </Snippet1>
}