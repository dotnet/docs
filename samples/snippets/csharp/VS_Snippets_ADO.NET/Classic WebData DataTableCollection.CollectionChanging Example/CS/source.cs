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
    public static void TableCollectionCollectionChanging()
    {
        // Create a DataSet with two tables
        DataSet dataSet = new DataSet();

        // Assign the event-handler function for the 
        // CollectionChangeEvent.
        dataSet.Tables.CollectionChanging +=
            new System.ComponentModel.CollectionChangeEventHandler(
            Collection_Changing);

        // create Customer table
        DataTable customersTable = new DataTable("Customers");
        customersTable.Columns.Add("customerId",
            typeof(int)).AutoIncrement = true;
        customersTable.Columns.Add("name",
            typeof(string));
        customersTable.PrimaryKey = new DataColumn[] { customersTable.Columns["customerId"] };

        // create Orders table
        DataTable ordersTable = new DataTable("Orders");
        ordersTable.Columns.Add("orderId",
            typeof(int)).AutoIncrement = true;
        ordersTable.Columns.Add("customerId",
            typeof(int));
        ordersTable.Columns.Add("amount",
            typeof(double));
        ordersTable.PrimaryKey = new DataColumn[] { ordersTable.Columns["orderId"] };

        dataSet.Tables.AddRange(new DataTable[] { customersTable, ordersTable });

        // Check to see if each table can be removed and then
        // remove it.
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

    private static void Collection_Changing(object sender,
        System.ComponentModel.CollectionChangeEventArgs e)
    {
        // Implementing this event allows you to abort a change
        // to the collection by raising an exception which you can
        // catch.

        Console.WriteLine("Collection_Changing Event: '{0}'\table element={1}",
            e.Action.ToString(), e.Element.ToString());
    }
    // </Snippet1>
}
