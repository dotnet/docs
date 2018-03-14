using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomDataServiceClient.OrderItems;

namespace CustomDataServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {

            //OrderItemData context = new OrderItemData(new Uri("http://localhost:12345/OrderItems.svc/"));
            OrderItemData context = new OrderItemData(new Uri("http://localhost:54321/OrderItems.svc/"));

            Order selectedOrder = GetOrderWithItems(context);

            PrintItems(selectedOrder);
           
            Item selectedItem = selectedOrder.Items.FirstOrDefault();
            selectedItem.Quantity += 1;
            context.UpdateObject(selectedItem);

            PrintItems(selectedOrder);

            Item newItem = new Item() { Product = "Grandma's Boysenberry Spread", Quantity = 30 };
            //context.AddToItems(newItem);
            selectedOrder.Items.Add(newItem);
            context.AddRelatedObject(selectedOrder, "Items", newItem);

            selectedOrder = GetOrderWithItems(context);

            PrintItems(selectedOrder);

            context.DeleteObject(newItem);

            selectedOrder = GetOrderWithItems(context);

            PrintItems(selectedOrder);

        }
        static Order GetOrderWithItems(OrderItemData context)
        {  
            var selectedOrder = (from orders in context.Orders.Expand("Items")
                                 select orders).FirstOrDefault();
            return selectedOrder;
        }
        static void PrintItems(Order selectedOrder)
        {
            Console.WriteLine("Order: {0}", selectedOrder.Customer);
            foreach (Item i in selectedOrder.Items)
            {
                Console.WriteLine("Product: {0} ({1})", i.Product, i.Quantity);
            }
        }
    }
}
