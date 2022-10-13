using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindClient.Northwind;

namespace NorthwindClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //NorthwindDataContext context = new NorthwindDataContext(new Uri("http://localhost:12345/Northwind.svc"));
            NorthwindDataContext context = new NorthwindDataContext(new Uri("http://localhost:54321/Northwind.svc"));

            var order = (from o in context.Orders.Expand("Order_Details")
                                where o.OrderID == 10248
                                select o).FirstOrDefault();

            var item = order.Order_Details.FirstOrDefault();

            item.Quantity += 1;
            context.UpdateObject(item);
            context.SaveChanges();

            context.DeleteObject(item);
            context.SaveChanges();

            context.AddRelatedObject(order, "Order_Details", item);
            context.SaveChanges();
        }
    }
}
