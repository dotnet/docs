using System;
using System.Data;
using System.Data.OleDb;

public class Sample
{
    static void Main()
    {
        DataTableColumnChanged();
    }
    // <Snippet1>
    private static void DataTableColumnChanged()
    {
        DataTable custTable = new DataTable("Customers");
        // add columns
        custTable.Columns.Add("id", typeof(int));
        custTable.Columns.Add("name", typeof(string));
        custTable.Columns.Add("address", typeof(string));

        // set PrimaryKey
        custTable.Columns["id"].Unique = true;
        custTable.PrimaryKey = new DataColumn[] { custTable.Columns["id"] };

        // add a ColumnChanged event handler for the table.
        custTable.ColumnChanged += new 
            DataColumnChangeEventHandler(Column_Changed );


        // add ten rows
        for(int id=1; id<=10; id++)
        {
            custTable.Rows.Add(
                new object[] { id, string.Format("customer{0}", id), 
                string.Format("address{0}", id) });
        }
	
        custTable.AcceptChanges();

        // change the name column in all the rows
        foreach(DataRow row in custTable.Rows )
        {
            row["name"] = string.Format("vip{0}", row["id"]);
        }

    }

    private static void Column_Changed(object sender, DataColumnChangeEventArgs e )
    {
        Console.WriteLine("Column_Changed Event: name={0}; Column={1}; original name={2}", 
            e.Row["name"], e.Column.ColumnName, e.Row["name", DataRowVersion.Original]);
    }
    // </Snippet1>
}