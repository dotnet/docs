using System.Linq;
using System;
using System.Collections.Generic;

namespace Projection
{
    public class SelectManySample2
    {
        //This sample uses a compound from clause and query syntax to select all orders where the order total is less than 100.00.
        //
        //Output:
        // CustomerId=ANATR OrderId = 10308 Total=$88.80
        // CustomerId=BERGS OrderId = 10778 Total=$96.50
        // CustomerId=BONAP OrderId = 10331 Total=$88.50
        // CustomerId=CACTU OrderId = 10782 Total=$12.50
        // CustomerId=DRACD OrderId = 10391 Total=$86.40
        // CustomerId=DRACD OrderId = 11067 Total=$86.85
        // CustomerId=DUMON OrderId = 10683 Total=$63.00
        // CustomerId=FOLKO OrderId = 10955 Total=$74.40
        // CustomerId=FRANS OrderId = 10422 Total=$49.80
        // CustomerId=FRANS OrderId = 10710 Total=$93.50
        // CustomerId=FRANS OrderId = 10753 Total=$88.00
        // CustomerId=FRANS OrderId = 10807 Total=$18.40
        // CustomerId=FURIB OrderId = 10963 Total=$57.80
        // CustomerId=GALED OrderId = 10887 Total=$70.00
        // CustomerId=GODOS OrderId = 11037 Total=$60.00
        // CustomerId=GREAL OrderId = 10589 Total=$72.00
        // CustomerId=ISLAT OrderId = 10674 Total=$45.00
        // CustomerId=LAMAI OrderId = 10371 Total=$72.96
        // CustomerId=LAMAI OrderId = 10631 Total=$55.80
        // CustomerId=LAMAI OrderId = 11051 Total=$36.00
        // CustomerId=LAUGB OrderId = 10620 Total=$57.50
        // CustomerId=LONEP OrderId = 10867 Total=$98.40
        // CustomerId=LONEP OrderId = 10883 Total=$36.00
        // CustomerId=MAGAA OrderId = 10754 Total=$55.20
        // CustomerId=NORTS OrderId = 11057 Total=$45.00
        // CustomerId=OCEAN OrderId = 10898 Total=$30.00
        // CustomerId=RANCH OrderId = 11019 Total=$76.00
        // CustomerId=REGGC OrderId = 10288 Total=$80.10
        // CustomerId=REGGC OrderId = 10586 Total=$23.80
        // CustomerId=ROMEY OrderId = 10281 Total=$86.50
        // CustomerId=SAVEA OrderId = 10815 Total=$40.00
        // CustomerId=SPECD OrderId = 10738 Total=$52.35
        // CustomerId=SPLIR OrderId = 10271 Total=$48.00
        // CustomerId=SUPRD OrderId = 10767 Total=$28.00
        // CustomerId=THEBI OrderId = 10992 Total=$69.60
        // CustomerId=VAFFE OrderId = 10602 Total=$48.75
        // CustomerId=WELLI OrderId = 10900 Total=$33.75
        public static void QuerySyntaxExample()
        {
            List<Customer> customers = Data.Customers;

            var orders =
                from c in customers
                from o in c.Orders
                where o.Total < 100.00M
                select new { c.CustomerId, o.OrderId, o.Total };
            foreach (var order in orders)
            {
                Console.WriteLine($"CustomerId={order.CustomerId} OrderId={order.OrderId} Total={order.Total:C}");
            }
        }

        //This sample uses a compound from clause and method syntax to select all orders where the order total is less than 100.00.
        //
        //Output:
        // CustomerId=ANATR OrderId = 10308 Total=$88.80
        // CustomerId=BERGS OrderId = 10778 Total=$96.50
        // CustomerId=BONAP OrderId = 10331 Total=$88.50
        // CustomerId=CACTU OrderId = 10782 Total=$12.50
        // CustomerId=DRACD OrderId = 10391 Total=$86.40
        // CustomerId=DRACD OrderId = 11067 Total=$86.85
        // CustomerId=DUMON OrderId = 10683 Total=$63.00
        // CustomerId=FOLKO OrderId = 10955 Total=$74.40
        // CustomerId=FRANS OrderId = 10422 Total=$49.80
        // CustomerId=FRANS OrderId = 10710 Total=$93.50
        // CustomerId=FRANS OrderId = 10753 Total=$88.00
        // CustomerId=FRANS OrderId = 10807 Total=$18.40
        // CustomerId=FURIB OrderId = 10963 Total=$57.80
        // CustomerId=GALED OrderId = 10887 Total=$70.00
        // CustomerId=GODOS OrderId = 11037 Total=$60.00
        // CustomerId=GREAL OrderId = 10589 Total=$72.00
        // CustomerId=ISLAT OrderId = 10674 Total=$45.00
        // CustomerId=LAMAI OrderId = 10371 Total=$72.96
        // CustomerId=LAMAI OrderId = 10631 Total=$55.80
        // CustomerId=LAMAI OrderId = 11051 Total=$36.00
        // CustomerId=LAUGB OrderId = 10620 Total=$57.50
        // CustomerId=LONEP OrderId = 10867 Total=$98.40
        // CustomerId=LONEP OrderId = 10883 Total=$36.00
        // CustomerId=MAGAA OrderId = 10754 Total=$55.20
        // CustomerId=NORTS OrderId = 11057 Total=$45.00
        // CustomerId=OCEAN OrderId = 10898 Total=$30.00
        // CustomerId=RANCH OrderId = 11019 Total=$76.00
        // CustomerId=REGGC OrderId = 10288 Total=$80.10
        // CustomerId=REGGC OrderId = 10586 Total=$23.80
        // CustomerId=ROMEY OrderId = 10281 Total=$86.50
        // CustomerId=SAVEA OrderId = 10815 Total=$40.00
        // CustomerId=SPECD OrderId = 10738 Total=$52.35
        // CustomerId=SPLIR OrderId = 10271 Total=$48.00
        // CustomerId=SUPRD OrderId = 10767 Total=$28.00
        // CustomerId=THEBI OrderId = 10992 Total=$69.60
        // CustomerId=VAFFE OrderId = 10602 Total=$48.75
        // CustomerId=WELLI OrderId = 10900 Total=$33.75
        public static void MethodSyntaxExample()
        {
            List<Customer> customers = Data.Customers;

            var orders =
                customers.SelectMany(c => c.Orders, (c, o) => new {c, o})
                    .Where(t => t.o.Total < 100.00M)
                    .Select(t => new {t.c.CustomerId, t.o.OrderId, t.o.Total});
            foreach (var order in orders)
            {
                Console.WriteLine($"CustomerId={order.CustomerId} OrderId={order.OrderId} Total={order.Total:C}");
            }
        }
    }
}