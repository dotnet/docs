using System;
using System.Data;

class Program
{
    static void Main()
    {
    }
    // <Snippet1>
    public static void DataTableCollectionAddRange()
    {
        // create a DataSet with two tables
        DataSet dataSet = new DataSet();

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

        // print the tables and their columns
        foreach (DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.TableName);
            foreach (DataColumn column in table.Columns)
            {
                Console.Write("{0}\table", column.ColumnName);
            }
            Console.WriteLine();
        }
    }
    // </Snippet1>
}



