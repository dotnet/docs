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

        foreach (DataRow custRow in customerOrders.Tables["Customers"].Rows)
        {
            Console.WriteLine(custRow["CustomerID"].ToString());

            foreach (DataRow orderRow in custRow.GetChildRows(customerOrdersRelation))
            {
                Console.WriteLine(orderRow["OrderID"].ToString());
            }
        }
        // </Snippet1>
    }
}
