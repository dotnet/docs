using System;
using System.Data;

namespace NavigationCS;

static class Program
{
    static void Main()
    {
        DataSet customerOrders = new();
        // <Snippet1>
        DataRelation customerOrdersRelation =
            customerOrders.Relations.Add("CustOrders",
            customerOrders.Tables["Customers"].Columns["CustomerID"],
            customerOrders.Tables["Orders"].Columns["CustomerID"]);

        DataRelation orderDetailRelation =
            customerOrders.Relations.Add("OrderDetail",
            customerOrders.Tables["Orders"].Columns["OrderID"],
            customerOrders.Tables["OrderDetails"].Columns["OrderID"], false);

        DataRelation orderProductRelation =
            customerOrders.Relations.Add("OrderProducts",
            customerOrders.Tables["Products"].Columns["ProductID"],
            customerOrders.Tables["OrderDetails"].Columns["ProductID"]);

        foreach (DataRow custRow in customerOrders.Tables["Customers"].Rows)
        {
            Console.WriteLine("Customer ID: " + custRow["CustomerID"]);

            foreach (DataRow orderRow in custRow.GetChildRows(customerOrdersRelation))
            {
                Console.WriteLine("  Order ID: " + orderRow["OrderID"]);
                Console.WriteLine("\tOrder Date: " + orderRow["OrderDate"]);

                foreach (DataRow detailRow in orderRow.GetChildRows(orderDetailRelation))
                {
                    Console.WriteLine("\t Product: " +
                        detailRow.GetParentRow(orderProductRelation)["ProductName"]);
                    Console.WriteLine("\t Quantity: " + detailRow["Quantity"]);
                }
            }
        }
        // </Snippet1>
    }
}
