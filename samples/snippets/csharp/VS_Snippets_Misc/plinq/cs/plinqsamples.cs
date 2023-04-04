namespace PLINQ_Samples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    class City
    {
        public int Population = 0;
        public string Name = string.Empty;
    }

    class Person
    {
        public string Mayor = string.Empty;
        public string CityName = string.Empty;
    }

    partial class PLINQProgram
    {
        static int Compute(int i) { return 1; }

        static void Main_2(string[] args)
        {
            // SimpleQuery();
            // OrderedQuery3();
            //SequentialDemo(); ;
            Console.ReadLine();
        }

        static void DOP()
        {
            var source = Enumerable.Range(0, 100000);
            //<snippet5>
            var query = from item in source.AsParallel().WithDegreeOfParallelism(2)
                        where Compute(item) > 42
                        select item;
            //</snippet5>
        }

        static void Test()
        {
            var cities = new List<City>();
            var people = new List<Person>();

            // Order Preservation In PLINQ 1st snippet
            //<snippet8>
            var cityQuery =
                (from city in cities.AsParallel()
                 where city.Population > 10000
                 select city).Take(1000);
            //</snippet8>

            // Order Preservation In PLINQ 2nd snippet
            //<snippet9>
            var orderedCities =
                (from city in cities.AsParallel().AsOrdered()
                 where city.Population > 10000
                 select city).Take(1000);

            //</snippet9>

            //<snippet6>
            var orderedCities2 =
                (from city in cities.AsParallel().AsOrdered()
                 where city.Population > 10000
                 select city).Take(1000);

            var finalResult =
                from city in orderedCities2.AsUnordered()
                join p in people.AsParallel()
                on city.Name equals p.CityName into details
                from c in details
                select new
                {
                    city.Name,
                    Pop = city.Population,
                    c.Mayor
                };

            foreach (var city in finalResult) { /*...*/ }
            //</snippet6>
            //...

            ////…
            //You can write the same query in method based syntax as follows:
            //[example]
            //Another way to minimize the expense of order preservation is to impose a new ordering explicitly at a later stage in the query, after all filters have been applied, as shown in the following example:
            //<snippet7>
            var orderedCities3 =
                (from city in cities.AsParallel()
                 where city.Population > 10000
                 orderby city.Name
                 select city).Take(1000);
            //</snippet7>
        }

        static void SimpleQuery()
        {
            var source = Enumerable.Range(100, 20000);

            // Result sequence might be out of order.
            var parallelQuery =
                from num in source.AsParallel()
                where num % 10 == 0
                select num;

            // Process result sequence in parallel
            parallelQuery.ForAll(DoSomething);

            // Or use foreach to merge results first.
            foreach (var n in parallelQuery)
            {
                Console.WriteLine(n);
            }

            // You can also use ToArray, ToList, etc
            // as with LINQ to Objects.
            var parallelQuery2 =
                (from num in source.AsParallel()
                 where num % 10 == 0
                 select num).ToArray();

            // Method syntax is also supported
            var parallelQuery3 =
                source.AsParallel()
                .Where(n => n % 10 == 0)
                .Select(n => n);

            Console.ReadLine();
        }

        static void DoSomething(int i) { }

        static void OrderedQuery()
        {
            //<snippet12>
            var source = Enumerable.Range(9, 10000);

            // Source is ordered; let's preserve it.
            var parallelQuery =
                from num in source.AsParallel().AsOrdered()
                where num % 3 == 0
                select num;

            // Use foreach to preserve order at execution time.
            foreach (var item in parallelQuery)
            {
                Console.Write($"{item} ");
            }

            // Some operators expect an ordered source sequence.
            var lowValues = parallelQuery.Take(10);
            //</snippet12>
        }

        static void OrderedQuery2()
        {
            var source = Enumerable.Range(108, 100000);

            var parallelQuery =
                from num in source.AsParallel().AsOrdered()
                where num % 8 == 0
                select num;

            // use foreach to preserve ordering
            // during query execution.
            foreach (var item in parallelQuery)
            {
                Console.Write($"{item} ");
            }
        }

        static void OrderedQuery3()
        {
            //<Snippet13>
            var source = Enumerable.Range(8, 100000);

            // Let the query access the data source will full parallelism
            // and apply ordering to the filtered results.
            var orderedQuery =
                from num in source.AsParallel()
                where num % 8 == 0
                orderby num
                select num;

            // use foreach to preserve query ordering
            foreach (var item in orderedQuery)
            {
                Console.Write($"{item} ");
            }
            //</snippet13>
        }
    }

    //<snippet16>
    namespace PLINQCancellation_1
    {
        using System;
        using System.Linq;
        using System.Threading;
        using System.Threading.Tasks;
        using static System.Console;

        class Program
        {
            static void Main()
            {
                int[] source = Enumerable.Range(1, 10000000).ToArray();
                using CancellationTokenSource cts = new();

                // Start a new asynchronous task that will cancel the
                // operation from another thread. Typically you would call
                // Cancel() in response to a button click or some other
                // user interface event.
                Task.Factory.StartNew(() =>
                {
                    UserClicksTheCancelButton(cts);
                });

                int[] results = null;
                try
                {
                    results =
                        (from num in source.AsParallel().WithCancellation(cts.Token)
                         where num % 3 == 0
                         orderby num descending
                         select num).ToArray();
                }
                catch (OperationCanceledException e)
                {
                    WriteLine(e.Message);
                }
                catch (AggregateException ae)
                {
                    if (ae.InnerExceptions != null)
                    {
                        foreach (Exception e in ae.InnerExceptions)
                        {
                            WriteLine(e.Message);
                        }
                    }
                }

                foreach (var item in results ?? Array.Empty<int>())
                {
                    WriteLine(item);
                }
                WriteLine();
                ReadKey();
            }

            static void UserClicksTheCancelButton(CancellationTokenSource cts)
            {
                // Wait between 150 and 500 ms, then cancel.
                // Adjust these values if necessary to make
                // cancellation fire while query is still executing.
                Random rand = new();
                Thread.Sleep(rand.Next(150, 500));
                cts.Cancel();
            }
        }
    }
    //</snippet16>

    //<snippet17>
    namespace PLINQCancellation_2
    {
        using System;
        using System.Linq;
        using System.Threading;
        using System.Threading.Tasks;
        using static System.Console;

        class Program
        {
            static void Main(string[] args)
            {
                int[] source = Enumerable.Range(1, 10000000).ToArray();
                using CancellationTokenSource cts = new();

                // Start a new asynchronous task that will cancel the
                // operation from another thread. Typically you would call
                // Cancel() in response to a button click or some other
                // user interface event.
                Task.Factory.StartNew(() =>
                {
                    UserClicksTheCancelButton(cts);
                });

                double[] results = null;
                try
                {
                    results =
                        (from num in source.AsParallel().WithCancellation(cts.Token)
                         where num % 3 == 0
                         select Function(num, cts.Token)).ToArray();
                }
                catch (OperationCanceledException e)
                {
                    WriteLine(e.Message);
                }
                catch (AggregateException ae)
                {
                    if (ae.InnerExceptions != null)
                    {
                        foreach (Exception e in ae.InnerExceptions)
                            WriteLine(e.Message);
                    }
                }

                foreach (var item in results ?? Array.Empty<double>())
                {
                    WriteLine(item);
                }
                WriteLine();
                ReadKey();
            }

            // A toy method to simulate work.
            static double Function(int n, CancellationToken ct)
            {
                // If work is expected to take longer than 1 ms
                // then try to check cancellation status more
                // often within that work.
                for (int i = 0; i < 5; i++)
                {
                    // Work hard for approx 1 millisecond.
                    Thread.SpinWait(50000);

                    // Check for cancellation request.
                    ct.ThrowIfCancellationRequested();
                }
                // Anything will do for our purposes.
                return Math.Sqrt(n);
            }

            static void UserClicksTheCancelButton(CancellationTokenSource cts)
            {
                // Wait between 150 and 500 ms, then cancel.
                // Adjust these values if necessary to make
                // cancellation fire while query is still executing.
                Random rand = new();
                Thread.Sleep(rand.Next(150, 500));
                WriteLine("Press 'c' to cancel");
                if (ReadKey().KeyChar == 'c')
                {
                    cts.Cancel();
                }
            }
        }
    }
    //</snippet17>

    //<snippet18>
    namespace PLINQCancellation_3
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading;

        class Program
        {
            static void Main(string[] args)
            {
                int[] source = Enumerable.Range(1, 10000000).ToArray();
                using CancellationTokenSource cs = new();

                IEnumerable<int> results = null;
                try
                {
                    results =
                        from num in source.AsParallel().WithCancellation(cs.Token)
                        where num % 3 == 0
                        orderby num descending
                        select num;
                }
                catch (OperationCanceledException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (AggregateException ae)
                {
                    if (ae.InnerExceptions != null)
                    {
                        foreach (Exception e in ae.InnerExceptions)
                            Console.WriteLine(e.Message);
                    }
                }

                foreach (var item in results ?? Array.Empty<int>())
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
    //</snippet18>

    //<snippet23>
    namespace MergeOptions
    {
        using System;
        using System.Diagnostics;
        using System.Linq;
        using System.Threading;

        class Program
        {
            static void Main(string[] args)
            {

                var nums = Enumerable.Range(1, 10000);

                // Replace NotBuffered with AutoBuffered
                // or FullyBuffered to compare behavior.
                //<snippet26>
                var scanLines = from n in nums.AsParallel()
                                    .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                                where n % 2 == 0
                                select ExpensiveFunc(n);
                //</snippet26>

                Stopwatch sw = Stopwatch.StartNew();
                foreach (var line in scanLines)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("Elapsed time: {0} ms. Press any key to exit.",
                                sw.ElapsedMilliseconds);
                Console.ReadKey();
            }

            // A function that demonstrates what a fly
            // sees when it watches television :-)
            static string ExpensiveFunc(int i)
            {
                Thread.SpinWait(2000000);
                return string.Format("{0} *****************************************", i);
            }
        }
    }
    //</snippet23>

    //<snippet31>
    namespace PLINQAggregation
    {
        using System;
        using System.Linq;

        class aggregation
        {
            static void Main(string[] args)
            {

                // Create a data source for demonstration purposes.
                int[] source = new int[100000];
                Random rand = new Random();
                for (int x = 0; x < source.Length; x++)
                {
                    // Should result in a mean of approximately 15.0.
                    source[x] = rand.Next(10, 20);
                }

                // Standard deviation calculation requires that we first
                // calculate the mean average. Average is a predefined
                // aggregation operator, along with Max, Min and Count.
                double mean = source.AsParallel().Average();

                // We use the overload that is unique to ParallelEnumerable. The
                // third Func parameter combines the results from each thread.
                double standardDev = source.AsParallel().Aggregate(
                    // initialize subtotal. Use decimal point to tell
                    // the compiler this is a type double. Can also use: 0d.
                    0.0,

                     // do this on each thread
                     (subtotal, item) => subtotal + Math.Pow((item - mean), 2),

                     // aggregate results after all threads are done.
                     (total, thisThread) => total + thisThread,

                    // perform standard deviation calc on the aggregated result.
                    (finalSum) => Math.Sqrt((finalSum / (source.Length - 1)))
                );
                Console.WriteLine("Mean value is = {0}", mean);
                Console.WriteLine("Standard deviation is {0}", standardDev);
                Console.ReadLine();
            }
        }
    }
    //</snippet31>

    partial class PLINQProgram
    {

        //} end namespace
    }
    //<snippet50>
    // This class contains a subset of data from the Northwind database
    // in the form of string arrays. The methods such as GetCustomers, GetOrders, and so on
    // transform the strings into object arrays that you can query in an object-oriented way.
    // Many of the code examples in the PLINQ How-to topics are designed to be pasted into
    // the PLINQDataSample class and invoked from the Main method.
    partial class PLINQDataSample
    {

        public static void Main()
        {
            ////Call methods here.
            TestDataSource();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void TestDataSource()
        {
            Console.WriteLine("Customer count: {0}", GetCustomers().Count());
            Console.WriteLine("Product count: {0}", GetProducts().Count());
            Console.WriteLine("Order count: {0}", GetOrders().Count());
            Console.WriteLine("Order Details count: {0}", GetOrderDetails().Count());
        }

        #region DataClasses
        public class Order
        {
            private Lazy<OrderDetail[]> _orderDetails;
            public Order()
            {
                _orderDetails = new Lazy<OrderDetail[]>(() => GetOrderDetailsForOrder(OrderID));
            }
            public int OrderID { get; set; }
            public string CustomerID { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime ShippedDate { get; set; }
            public OrderDetail[] OrderDetails { get { return _orderDetails.Value; } }
        }

        public class Customer
        {
            private Lazy<Order[]> _orders;
            public Customer()
            {
                _orders = new Lazy<Order[]>(() => GetOrdersForCustomer(CustomerID));
            }
            public string CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public Order[] Orders
            {
                get
                {
                    return _orders.Value;
                }
            }
        }

        public class Product
        {
            public string ProductName { get; set; }
            public int ProductID { get; set; }
            public double UnitPrice { get; set; }
        }

        public class OrderDetail
        {
            public int OrderID { get; set; }
            public int ProductID { get; set; }
            public double UnitPrice { get; set; }
            public double Quantity { get; set; }
            public double Discount { get; set; }
        }
        #endregion

        public static IEnumerable<string> GetCustomersAsStrings()
        {
            return System.IO.File.ReadAllLines(@"..\..\plinqdata.csv")
                                            .SkipWhile((line) => line.StartsWith("CUSTOMERS") == false)
                                             .Skip(1)
                                            .TakeWhile((line) => line.StartsWith("END CUSTOMERS") == false);
        }

        public static IEnumerable<Customer> GetCustomers()
        {
            var customers = System.IO.File.ReadAllLines(@"..\..\plinqdata.csv")
                                             .SkipWhile((line) => line.StartsWith("CUSTOMERS") == false)
                                             .Skip(1)
                                             .TakeWhile((line) => line.StartsWith("END CUSTOMERS") == false);
            return (from line in customers
                    let fields = line.Split(',')
                    let custID = fields[0].Trim()
                    select new Customer()
                    {
                        CustomerID = custID,
                        CustomerName = fields[1].Trim(),
                        Address = fields[2].Trim(),
                        City = fields[3].Trim(),
                        PostalCode = fields[4].Trim()
                    });
        }

        public static Order[] GetOrdersForCustomer(string id)
        {
            // Assumes we copied the file correctly!
            var orders = System.IO.File.ReadAllLines(@"..\..\plinqdata.csv")
                                             .SkipWhile((line) => line.StartsWith("ORDERS") == false)
                                              .Skip(1)
                                            .TakeWhile((line) => line.StartsWith("END ORDERS") == false);
            var orderStrings = from line in orders
                               let fields = line.Split(',')
                               where fields[1].CompareTo(id) == 0
                               select new Order()
                               {
                                   OrderID = Convert.ToInt32(fields[0]),
                                   CustomerID = fields[1].Trim(),
                                   OrderDate = DateTime.Parse(fields[2]),
                                   ShippedDate = DateTime.Parse(fields[3])
                               };
            return orderStrings.ToArray();
        }

        //  "10248, VINET, 7/4/1996 12:00:00 AM, 7/16/1996 12:00:00 AM
        public static IEnumerable<Order> GetOrders()
        {
            // Assumes we copied the file correctly!
            var orders = System.IO.File.ReadAllLines(@"..\..\plinqdata.csv")
                                            .SkipWhile((line) => line.StartsWith("ORDERS") == false)
                                             .Skip(1)
                                            .TakeWhile((line) => line.StartsWith("END ORDERS") == false);
            return from line in orders
                   let fields = line.Split(',')

                   select new Order()
                   {
                       OrderID = Convert.ToInt32(fields[0]),
                       CustomerID = fields[1].Trim(),
                       OrderDate = DateTime.Parse(fields[2]),
                       ShippedDate = DateTime.Parse(fields[3])
                   };
        }

        public static IEnumerable<Product> GetProducts()
        {
            // Assumes we copied the file correctly!
            var products = System.IO.File.ReadAllLines(@"..\..\plinqdata.csv")
                                            .SkipWhile((line) => line.StartsWith("PRODUCTS") == false)
                                             .Skip(1)
                                            .TakeWhile((line) => line.StartsWith("END PRODUCTS") == false);
            return from line in products
                   let fields = line.Split(',')
                   select new Product()
                   {
                       ProductID = Convert.ToInt32(fields[0]),
                       ProductName = fields[1].Trim(),
                       UnitPrice = Convert.ToDouble(fields[2])
                   };
        }

        public static IEnumerable<OrderDetail> GetOrderDetails()
        {
            // Assumes we copied the file correctly!
            var orderDetails = System.IO.File.ReadAllLines(@"..\..\plinqdata.csv")
                                            .SkipWhile((line) => line.StartsWith("ORDER DETAILS") == false)
                                             .Skip(1)
                                            .TakeWhile((line) => line.StartsWith("END ORDER DETAILS") == false);

            return from line in orderDetails
                   let fields = line.Split(',')
                   select new OrderDetail()
                   {
                       OrderID = Convert.ToInt32(fields[0]),
                       ProductID = Convert.ToInt32(fields[1]),
                       UnitPrice = Convert.ToDouble(fields[2]),
                       Quantity = Convert.ToDouble(fields[3]),
                       Discount = Convert.ToDouble(fields[4])
                   };
        }

        public static OrderDetail[] GetOrderDetailsForOrder(int id)
        {
            // Assumes we copied the file correctly!
            var orderDetails = System.IO.File.ReadAllLines(@"..\..\plinqdata.csv")
                                            .SkipWhile((line) => line.StartsWith("ORDER DETAILS") == false)
                                             .Skip(1)
                                            .TakeWhile((line) => line.StartsWith("END ORDER DETAILS") == false);

            var orderDetailStrings = from line in orderDetails
                                     let fields = line.Split(',')
                                     let ordID = Convert.ToInt32(fields[0])
                                     where ordID == id
                                     select new OrderDetail()
                                     {
                                         OrderID = ordID,
                                         ProductID = Convert.ToInt32(fields[1]),
                                         UnitPrice = Convert.ToDouble(fields[2]),
                                         Quantity = Convert.ToDouble(fields[3]),
                                         Discount = Convert.ToDouble(fields[4])
                                     };

            return orderDetailStrings.ToArray();
        }
    }
    //</snippet50>

    partial class PLINQDataSample
    {

        //<snippet14>
        // Paste into PLINQDataSample class.
        static void SimpleOrdering()
        {

            var customers = GetCustomers();

            // Take the first 20, preserving the original order
            var firstTwentyCustomers = customers
                                        .AsParallel()
                                        .AsOrdered()
                                        .Take(20);

            foreach (var c in firstTwentyCustomers)
                Console.Write("{0} ", c.CustomerID);

            // All elements in reverse order.
            var reverseOrder = customers
                                .AsParallel()
                                .AsOrdered()
                                .Reverse();

            foreach (var v in reverseOrder)
                Console.Write("{0} ", v.CustomerID);

            // Get the element at a specified index.
            var cust = customers.AsParallel()
                                .AsOrdered()
                                .ElementAt(48);

            Console.WriteLine("Element #48 is: {0}", cust.CustomerID);
        }
        //</snippet14>

        //<snippet15>
        // Paste into PLINQDataSample class.
        static void OrderedThenUnordered()
        {

            var orders = GetOrders();
            var orderDetails = GetOrderDetails();

            var q2 = orders.AsParallel()
               .Where(o => o.OrderDate < DateTime.Parse("07/04/1997"))
               .Select(o => o)
               .OrderBy(o => o.CustomerID) // Preserve original ordering for Take operation.
               .Take(20)
               .AsUnordered()  // Remove ordering constraint to make join faster.
               .Join(
                      orderDetails.AsParallel(),
                      ord => ord.OrderID,
                      od => od.OrderID,
                      (ord, od) =>
                      new
                      {
                          ID = ord.OrderID,
                          Customer = ord.CustomerID,
                          Product = od.ProductID
                      }
                     )
               .OrderBy(i => i.Product); // Apply new ordering to final result sequence.

            foreach (var v in q2)
                Console.WriteLine("{0} {1} {2}", v.ID, v.Customer, v.Product);
        }
        //</snippet15>

        static void NestedLoops()
        {
            var date = DateTime.Now;
            var customers = GetCustomers();
            //<snippet20>
            var q = from cust in customers.AsParallel()
                    from order in cust.Orders.AsParallel()
                    where order.OrderDate > date
                    select new { cust, order };
            //</snippet20>
        }

        //<snippet22>
        // Paste into PLINQDataSample class.
        static void ForceParallel()
        {
            var customers = GetCustomers();
            var parallelQuery = (from cust in customers.AsParallel()
                                    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                 where cust.City == "Berlin"
                                 select cust.CustomerName)
                                .ToList();
        }
        //</snippet22>

        //<snippet24>
        // Paste into PLINQDataSample class.
        static void SequentialDemo()
        {
            var orders = GetOrders();
            var query = (from order in orders.AsParallel()
                         orderby order.OrderID
                         select new
                         {
                             order.OrderID,
                             OrderedOn = order.OrderDate,
                             ShippedOn = order.ShippedDate
                         })
                         .AsSequential().Take(5);
        }
        //</snippet24>

        //<snippet25>
        class FileIteration
        {
            static void Main() { }
        }
        //</snippet25>

        //<snippet41>
        // Paste into PLINQDataSample class.
        static void PLINQExceptions_1()
        {
            // Using the raw string array here. See PLINQ Data Sample.
            string[] customers = GetCustomersAsStrings().ToArray();

            // First, we must simulate some corrupt input.
            customers[54] = "###";

            var parallelQuery = from cust in customers.AsParallel()
                                let fields = cust.Split(',')
                                where fields[3].StartsWith("C") //throw indexoutofrange
                                select new { city = fields[3], thread = Thread.CurrentThread.ManagedThreadId };
            try
            {
                // We use ForAll although it doesn't really improve performance
                // since all output is serialized through the Console.
                parallelQuery.ForAll(e => Console.WriteLine("City: {0}, Thread:{1}", e.city, e.thread));
            }

            // In this design, we stop query processing when the exception occurs.
            catch (AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                    if (ex is IndexOutOfRangeException)
                        Console.WriteLine("The data source is corrupt. Query stopped.");
                }
            }
        }
        //</snippet41>

        //<snippet42>
        // Paste into PLINQDataSample class.
        static void PLINQExceptions_2()
        {
            var customers = GetCustomersAsStrings().ToArray();
            // Using the raw string array here.
            // First, we must simulate some corrupt input
            customers[54] = "###";

            // Assume that in this app, we expect malformed data
            // occasionally and by design we just report it and continue.
            static bool IsTrue(string[] f, string c)
            {
                try
                {
                    string s = f[3];
                    return s.StartsWith(c);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"Malformed cust: {f}");
                    return false;
                }
            };

            // Using the raw string array here
            var parallelQuery =
                from cust in customers.AsParallel()
                let fields = cust.Split(',')
                where IsTrue(fields, "C") //use a named delegate with a try-catch
                select new { City = fields[3] };

            try
            {
                // We use ForAll although it doesn't really improve performance
                // since all output must be serialized through the Console.
                parallelQuery.ForAll(e => Console.WriteLine(e.City));
            }

            // IndexOutOfRangeException will not bubble up
            // because we handle it where it is thrown.
            catch (AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        //</snippet42>
    }
}
