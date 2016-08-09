using System;
using System.Collections.Generic;
using System.Linq;

namespace Grouping
{
    public class GroupByNested1
    {
        //This sample uses group by to partition a list of each customer's orders, 
        // first by year, and then by month.
        public static void QuerySyntaxExample()
        {
            List<Customer> customers = Data.Customers;

            var customerOrderGroups = from c in customers
                                      select new
                                        {
                                            c.CustomerName,
                                            YearGroups =
                                                from o in c.Orders
                                                group o by o.OrderDate.Year into yg
                                                select new
                                                {
                                                    Year = yg.Key,
                                                    MonthGroups =
                                                        from o in yg
                                                        group o by o.OrderDate.Month into mg
                                                        select new
                                                        {
                                                            Month = mg.Key,
                                                            Orders = mg
                                                        }
                                                }
                                        };

            foreach (var c in customerOrderGroups)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine($"CustomerName={c.CustomerName}");
                foreach (var yg in c.YearGroups)
                {
                    Console.WriteLine($"Year={yg.Year}");
                    foreach (var mg in yg.MonthGroups)
                    {
                        Console.WriteLine($"Month={mg.Month}");
                        foreach (var o in mg.Orders)
                        {
                            Console.WriteLine($"OrderDate={o.OrderDate}, Total={o.Total}");
                        }                        
                    }
                }
            }
        }
    }
}
