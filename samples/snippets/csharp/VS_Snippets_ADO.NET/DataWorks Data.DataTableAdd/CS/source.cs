using System;
using System.Data;
namespace DataTableAddCS
{
    class Program
    {
        static void Main()
        {
            // <Snippet1>
            DataSet customerOrders = new DataSet("CustomerOrders");

            DataTable ordersTable = customerOrders.Tables.Add("Orders");

            DataColumn pkOrderID = 
                ordersTable.Columns.Add("OrderID", typeof(Int32));
            ordersTable.Columns.Add("OrderQuantity", typeof(Int32));
            ordersTable.Columns.Add("CompanyName", typeof(string));

            ordersTable.PrimaryKey = new DataColumn[] { pkOrderID };
            // </Snippet1>
        }
    }
}
