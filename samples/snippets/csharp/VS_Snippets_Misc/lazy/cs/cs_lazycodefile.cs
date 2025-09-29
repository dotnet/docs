using System;
using System.Threading;
using Microsoft.Data.SqlClient;

namespace CS_lazy
{
    class Order
    {
        public override string ToString()
        {

            return "Order";
        }
    }

    class Orders
    {
        public Orders(int numOrders) { }
        public Orders(string custID) { }
        public Order[] OrderData;
    }

    class IntroSnippets
    {
        static readonly bool s_displayOrders = true;
        public static void Test()
        {
            //<snippet1>
            // Initialize by using default Lazy<T> constructor. The
            // Orders array itself is not created yet.
            Lazy<Orders> _orders = new();
            //</snippet1>
        }

        //dummy method for snippet3
        public static void DisplayOrders(Order[] orders) { }
        public static void Test2()
        {
            //<snippet2>
            // Initialize by invoking a specific constructor on Order when Value
            // property is accessed
            Lazy<Orders> _orders = new(() => new Orders(100));
            //</snippet2>

            //<snippet3>
            // We need to create the array only if displayOrders is true
            if (s_displayOrders == true)
            {
                DisplayOrders(_orders.Value.OrderData);
            }
            else
            {
                // Don't waste resources getting order data.
            }
            //</snippet3>

            //<snippet4>
            _orders = new Lazy<Orders>(() => new Orders(10));
            //</snippet4>
        }

        //<snippet5>
        class Customer
        {
            private readonly Lazy<Orders> _orders;
            public string CustomerID { get; private set; }
            public Customer(string id)
            {
                CustomerID = id;
                _orders = new Lazy<Orders>(() =>
                {
                    // You can specify any additional
                    // initialization steps here.
                    return new Orders(CustomerID);
                });
            }

            public Orders MyOrders
            {
                get
                {
                    // Orders is created on first access here.
                    return _orders.Value;
                }
            }
        }
        //</snippet5>

        //<snippet6>
        [ThreadStatic]
        static int s_counter = 1;
        //</snippet6>

        //<snippet7>
        ThreadLocal<int> _betterCounter = new(() => 1);
        //</snippet7>
    }

    class DataInitializedFromDb
    {
        public DataInitializedFromDb(SqlDataReader reader) { }
        public int Count { get; private set; }
    }

    class MyClass3
    {
        static void Main()
        {
            string connectionString = "";
            Lazy<DataInitializedFromDb> _data =
                new(delegate
                {
                    using (SqlConnection conn = new(connectionString))
                    using (SqlCommand comm = new())
                    {
                        SqlDataReader reader = comm.ExecuteReader();
                        DataInitializedFromDb data = new(reader);
                        return data;
                    }
                });
            //…
            // use the data
            if (_data.Value.Count > 10) ProcessData(_data.Value);
        }

        static void ProcessData(DataInitializedFromDb data) { }
    }
    class LazyProgram
    {
        static void Main(string[] args)
        {
            // LazyAndThreadLocal();
            TestEnsureInitialized();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void LazyAndThreadLocal()
        {
            //<snippet8>
            // Initialize the integer to the managed thread id of the
            // first thread that accesses the Value property.
            Lazy<int> number = new(() => Environment.CurrentManagedThreadId);

            Thread t1 = new(() => Console.WriteLine($"number on t1 = {number.Value} ThreadID = {Environment.CurrentManagedThreadId}"));
            t1.Start();

            Thread t2 = new(() => Console.WriteLine($"number on t2 = {number.Value} ThreadID = {Environment.CurrentManagedThreadId}"));
            t2.Start();

            Thread t3 = new(() => Console.WriteLine($"number on t3 = {number.Value} ThreadID = {Environment.CurrentManagedThreadId}"));
            t3.Start();

            // Ensure that thread IDs are not recycled if the
            // first thread completes before the last one starts.
            t1.Join();
            t2.Join();
            t3.Join();

            /* Sample Output:
                number on t1 = 11 ThreadID = 11
                number on t3 = 11 ThreadID = 13
                number on t2 = 11 ThreadID = 12
                Press any key to exit.
            */
            //</snippet8>

            //<snippet9>
            // Initialize the integer to the managed thread id on a per-thread basis.
            ThreadLocal<int> threadLocalNumber = new(() => Environment.CurrentManagedThreadId);
            Thread t4 = new(() => Console.WriteLine($"threadLocalNumber on t4 = {threadLocalNumber.Value} ThreadID = {Environment.CurrentManagedThreadId}"));
            t4.Start();

            Thread t5 = new(() => Console.WriteLine($"threadLocalNumber on t5 = {threadLocalNumber.Value} ThreadID = {Environment.CurrentManagedThreadId}"));
            t5.Start();

            Thread t6 = new(() => Console.WriteLine($"threadLocalNumber on t6 = {threadLocalNumber.Value} ThreadID = {Environment.CurrentManagedThreadId}"));
            t6.Start();

            // Ensure that thread IDs are not recycled if the
            // first thread completes before the last one starts.
            t4.Join();
            t5.Join();
            t6.Join();

            /* Sample Output:
               threadLocalNumber on t4 = 14 ThreadID = 14
               threadLocalNumber on t5 = 15 ThreadID = 15
               threadLocalNumber on t6 = 16 ThreadID = 16
            */
            //</snippet9>
        }

        static void TestEnsureInitialized()
        {
            Order[] _orders = new Order[100];
            bool displayOrderInfo = true;

            //<snippet10>
            // Assume that _orders contains null values, and
            // we only need to initialize them if displayOrderInfo is true
            if (displayOrderInfo == true)
            {
                for (int i = 0; i < _orders.Length; i++)
                {
                    // Lazily initialize the orders without wrapping them in a Lazy<T>
                    LazyInitializer.EnsureInitialized(ref _orders[i], () =>
                    {
                        // Returns the value that will be placed in the ref parameter.
                        return GetOrderForIndex(i);
                    });
                }
            }
            //</snippet10>
            foreach (Order v in _orders)
                Console.WriteLine(v.ToString());
        }

        static Order GetOrderForIndex(int slot)
        { return new Order(); }

        static void InitializeDBConnection()
        {
        }

        static void InitializeBigComputation(long bigNum)
        {
            Lazy<int[]> primeFactors = new(() => GetPrimeFactors(bigNum), true);
        }

        static int[] GetPrimeFactors(long bigNum)
        { return new int[1]; }
    }
}

namespace HowToSnippets
{
    using System;
    using System.Net.Http;

    class Number
    {
        public int Num { get; private set; }
        public Lazy<int[]> primeFactors;
        public Number(int i)
        {
            Num = i;
            primeFactors = new Lazy<int[]>(() => GetPrimeFactors(Num));
        }

        private static int[] GetPrimeFactors(int i)
        {
            return new int[100];
        }

        class WebPage
        {
            private readonly Lazy<string> _text;
            public WebPage(string url, string title)
            {
                Url = url;
                Title = title;
                _text = new Lazy<string>(() =>
                    {
                        return new HttpClient().GetStringAsync(Url).Result;
                    });
            }

            public string Url { get; private set; }
            public string Title { get; private set; }
            public string Text
            {
                get
                {
                    return _text.Value;
                }
            }
        }

        static void Main()
        {
            WebPage[] catalog =
            [
                new WebPage("", ""),
                new WebPage("", ""),
                new WebPage("", ""),
                new WebPage("", ""),
                new WebPage("", ""),
            ];
        }
    }
}
