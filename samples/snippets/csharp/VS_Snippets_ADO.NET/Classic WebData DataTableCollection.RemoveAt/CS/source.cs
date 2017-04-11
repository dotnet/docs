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
        public static void DataTableCollectionRemoveAt()
        {
            // Create a DataSet with two tables and then
            // remove the tables from the collection using RemoveAt.
            DataSet dataSet = new DataSet();

            // Create Customer table.
            DataTable customerTable = new DataTable("Customers");
            customerTable.Columns.Add("customerId",
                typeof(int)).AutoIncrement = true;
            customerTable.Columns.Add("name", typeof(string));
            customerTable.PrimaryKey = new DataColumn[] { customerTable.Columns["customerId"] };

            // Create Orders table.
            DataTable ordersTable = new DataTable("Orders");
            ordersTable.Columns.Add("orderId",
                typeof(int)).AutoIncrement = true;
            ordersTable.Columns.Add("customerId", typeof(int));
            ordersTable.Columns.Add("amount", typeof(double));
            ordersTable.PrimaryKey = new DataColumn[] { ordersTable.Columns["orderId"] };

            dataSet.Tables.AddRange(new DataTable[] { customerTable, ordersTable });

            // Remove all tables.
            // First check to see if the table can be removed,
            // then remove it.
            //
            // You cannot use a foreach when removing items
            // from a collection.
            while (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                if (dataSet.Tables.CanRemove(table))
                    dataSet.Tables.RemoveAt(0);
                Console.WriteLine("dataSet has {0} tables",
                    dataSet.Tables.Count);
            }
        }
        // </Snippet1>
    }
