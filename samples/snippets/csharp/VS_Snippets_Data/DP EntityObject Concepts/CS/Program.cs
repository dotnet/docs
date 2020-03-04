using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace Microsoft.Samples.Edm
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                QueryWithSpan();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static void QueryWithSpan()
        {
            using (SalesOrdersEntities context =
                new SalesOrdersEntities())
            {
                // Set the object span to return line items with an order.
                ObjectQuery<Order> query = context.Order.Include("LineItem");
 
                try
                {
                    // Execute the query and display information for each item 
                    // in the orders that belong to the first contact.
                    foreach (Order order in query.Top("5").Execute(MergeOption.AppendOnly))
                    {
                        Console.WriteLine(String.Format("PO Number: {0}",
                            order.ExtendedInfo.PurchaseOrder));
                        Console.WriteLine(String.Format("Order Date: {0}",
                            order.OrderDate.ToString()));
                        Console.WriteLine("Order items:");
                        foreach (LineItem item in order.LineItem)
                        {
                            Console.WriteLine(String.Format("Product: {0} "
                                + "Quantity: {1}", item.Product.ToString(),
                                item.Quantity.ToString()));
                        }
                        order.ExtendedInfo.PurchaseOrder += "_new";
                    }
                    context.SaveChanges();
                }
                catch (EntitySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (EntityCommandExecutionException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}