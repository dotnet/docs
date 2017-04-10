using System;
using System.Data;

namespace WebData_Examples
{

    /// <summary>
    /// Summary description for DataTableCollectionRemove.
    /// </summary>
    public class DataTableCollectionRemove
    {

        static void Main()
        {
            DataTableCollectionCanRemove();
        }

        public DataTableCollectionRemove()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        // <Snippet1>
        public static void DataTableCollectionCanRemove()
        {
            // create a DataSet with two tables
            DataSet dataSet = new DataSet();

            // create Customer table
            DataTable customersTable = new DataTable("Customers");
            customersTable.Columns.Add("customerId", 
                typeof(int) ).AutoIncrement = true;
            customersTable.Columns.Add("name",       
                typeof(string));
            customersTable.PrimaryKey = new DataColumn[] 
                { customersTable.Columns["customerId"] };

            // create Orders table
            DataTable ordersTable = new DataTable("Orders");
            ordersTable.Columns.Add("orderId",    
                typeof(int) ).AutoIncrement = true;
            ordersTable.Columns.Add("customerId", 
                typeof(int) );
            ordersTable.Columns.Add("amount",     
                typeof(double));
            ordersTable.PrimaryKey = new DataColumn[] 
                { ordersTable.Columns["orderId"] };

            dataSet.Tables.AddRange(new DataTable[] 
                {customersTable, ordersTable });

            // remove all tables
            // check if table can be removed and then
            // remove it, cannot use a foreach when
            // removing items from a collection
            while(dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                if(dataSet.Tables.CanRemove(table))
                {
                    dataSet.Tables.Remove(table);
                }
            }

            Console.WriteLine("dataSet has {0} tables",     
                dataSet.Tables.Count);
        }
        // </Snippet1>

    }
}
