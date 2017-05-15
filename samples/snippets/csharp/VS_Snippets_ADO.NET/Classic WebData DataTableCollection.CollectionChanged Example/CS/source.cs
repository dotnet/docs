using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;

class Program
{
    static void Main()
    {
    }
    // <Snippet1>
    public static void TableCollectionCollectionChanged()
    {
        // create a DataSet with two tables
        DataSet dataSet = new DataSet();

        dataSet.Tables.CollectionChanged +=
            new System.ComponentModel.CollectionChangeEventHandler(
            Collection_Changed);

        // create Customer table
        DataTable custTable = new DataTable("Customers");
        custTable.Columns.Add("customerId",
            typeof(int)).AutoIncrement = true;
        custTable.Columns.Add("name",
            typeof(string));
        custTable.PrimaryKey = new DataColumn[] { custTable.Columns["customerId"] };

        // create Orders table
        DataTable orderTable = new DataTable("Orders");
        orderTable.Columns.Add("orderId",
            typeof(int)).AutoIncrement = true;
        orderTable.Columns.Add("customerId", typeof(int));
        orderTable.Columns.Add("amount", typeof(double));
        orderTable.PrimaryKey = new DataColumn[] { orderTable.Columns["orderId"] };

        dataSet.Tables.AddRange(new DataTable[] { custTable, orderTable });

        // remove all tables
        // check if table can be removed and then
        // remove it, cannot use a foreach when
        // removing items from a collection
        // equivalent to dataSet.Tables.Clear()
        while (dataSet.Tables.Count > 0)
        {
            DataTable table = dataSet.Tables[0];
            if (dataSet.Tables.CanRemove(table))
            {
                dataSet.Tables.RemoveAt(0);
            }
        }

        Console.WriteLine("dataSet has {0} tables",
            dataSet.Tables.Count);
    }

    private static void Collection_Changed(object sender,
        System.ComponentModel.CollectionChangeEventArgs e)
    {
        Console.WriteLine("Collection_Changed Event: '{0}'\table element={1}",
            e.Action.ToString(), e.Element.ToString());
    }
    // </Snippet1>
}
