//<Snippet1>
using System;
using System.Text;
using System.Timers;
using System.Threading;
using Microsoft.Win32;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;

public class PerfCounter1
{

    [STAThread]
    public static void Main(string[] args)
    {
        try
        {
            if (!PerformanceCounterCategory.Exists("Orders"))
            {
                // If the category does not exist, create the category and exit.
                // Performance counters should not be created and immediately used.
                // There is a latency time to enable the counters, they should be created
                // prior to executing the application that uses the counters.

                // Create custom counters.
                Writer.CreateCounters();
                return;
            }
            Writer server = new Writer();
            // Start the counters.
            server.StartCounters();
            Reader client = new Reader();
            // Read the counters from the client.
            client.StartCounters();
            server.CloseTimer();
            client.Finish();
            Writer.DeleteCounters();
            Console.WriteLine("Press any key to exit.");
            Console.Read();

        }
        catch (Exception e)
        {
            Console.WriteLine("Sample failed with exception: " + e.ToString());
        }
    }

    public class Writer
    {
        private System.Timers.Timer timer1;
        private PerformanceCounter counter1;
        private PerformanceCounter counter2;
        private PerformanceCounter counter3;
        private PerformanceCounter counter4;
        private int finalCount;

        public Writer()
        {
            this.timer1 = new System.Timers.Timer(100);
            this.finalCount = 0;
            timer1.Elapsed += new ElapsedEventHandler(this.OnTimer1);
        }

        //<Snippet4>
        public static void CreateCounters()
        {
            //<Snippet2>
            CounterCreationData data1 = new CounterCreationData("Trucks",
                "Number of orders", PerformanceCounterType.NumberOfItems32);
            CounterCreationData data2 = new CounterCreationData("Rate of sales",
                "Orders/second", PerformanceCounterType.RateOfCountsPerSecond32);
            CounterCreationDataCollection ccds = new CounterCreationDataCollection();
            ccds.Add(data1);
            ccds.Add(data2);
            Console.WriteLine("Creating Orders custom counter.");
            if (!PerformanceCounterCategory.Exists("Orders"))
                PerformanceCounterCategory.Create("Orders",
                    "Processed orders",
                    PerformanceCounterCategoryType.MultiInstance,
                    ccds);
            //</Snippet2>

            //<Snippet3>
            Console.WriteLine("Creating Inventory custom counter");
            if (!PerformanceCounterCategory.Exists("Inventory"))
                PerformanceCounterCategory.Create("Inventory",
                    "Truck inventory",
                    PerformanceCounterCategoryType.SingleInstance,
                    "Trucks", "Number of trucks on hand");
            //</Snippet3>

        }
        //</Snippet4>

        public void StartCounters()
        {
            Console.WriteLine(
                "Instantiating Custom Counter Orders, Trucks, United States");
            this.counter1 = new PerformanceCounter(
                "Orders", "Trucks", "United States", false);
            this.counter1.RawValue = 5;
            Console.WriteLine(
                "Instantiating Custom Counter Orders, Trucks, Europe");
            this.counter2 = new PerformanceCounter(
                "Orders", "Trucks", "Europe", false);
            this.counter2.RawValue = 10;
            Console.WriteLine(
                "Instantiating Custom Counter Orders, Rate of Sales, Total");
            this.counter3 = new PerformanceCounter(
                "Orders", "Rate of Sales", "Total", false);
            this.counter3.RawValue = 10;
            Console.WriteLine(
                "Instantiating Custom Counter Inventory, Trucks");
            this.counter4 = new PerformanceCounter(
                "Inventory", "Trucks", false);
            this.counter4.RawValue = 15;

            this.timer1.Start();
        }

        public void CloseTimer()
        {
            this.timer1.Close();
        }

        public static void DeleteCounters()
        {
            try
            {
                PerformanceCounterCategory.Delete("Orders");
                PerformanceCounterCategory.Delete("Inventory");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        private void OnTimer1(object sender, ElapsedEventArgs args)
        {
            try
            {
                this.counter1.IncrementBy(100);
                this.counter1.Increment();
                this.counter2.IncrementBy(50);
                this.counter2.Decrement();
                this.counter3.IncrementBy(1);
                this.counter4.IncrementBy(150);
                ++this.finalCount;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception thrown :" + e.ToString());
            }
        }
    }

    public class Reader
    {
        private ManualResetEvent signal;
        private System.Timers.Timer timer1;
        private PerformanceCounter counter1;
        private PerformanceCounter counter2;
        private PerformanceCounter counter3;
        private PerformanceCounter counter4;
        private int finalCount;

        public Reader()
        {
            signal = new ManualResetEvent(false);
            this.timer1 = new System.Timers.Timer(500);
            this.finalCount = 0;
            timer1.Elapsed += new ElapsedEventHandler(this.OnTimer1);
        }

        public void Finish()
        {
            this.signal.WaitOne();
            this.timer1.Close();
            PerformanceCounter.CloseSharedResources();
        }

        private void OnTimer1(object sender, ElapsedEventArgs args)
        {
            try
            {
                lock (this)
                {
                    if (this.finalCount >= 10)
                        return;

                    float value1 = this.counter1.NextValue();
                    Console.WriteLine(
                                "Custom Counter Orders, Trucks, United States: {0}", value1.ToString());

                    float value2 = this.counter2.NextValue();
                    Console.WriteLine(
                        "Custom Counter Orders, Trucks, Europe: {0}", value2.ToString());

                    float value3 = this.counter3.NextValue();
                    Console.WriteLine(
                        "Custom Counter Orders, Rate of sales, United Total: {0}", value3.ToString());

                    float value4 = this.counter4.NextValue();
                    Console.WriteLine(
                        "Custom Counter Inventory, Trucks, United States: {0}", value4.ToString());

                    if (this.finalCount < 5)
                        ++this.finalCount;
                    else
                    {
                        ++this.finalCount;
                        this.signal.Set();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Sample failure :" + e.ToString());
                this.signal.Set();
            }
        }

        public void StartCounters()
        {
            Console.WriteLine(
                "Instantiating Custom Counter Orders, Trucks, United States");
            // Instantiate a counter, category "Orders, counter name "Trucks", instance "United States"
            this.counter1 = new PerformanceCounter(
                "Orders", "Trucks", "United States");
            Console.WriteLine("Instantiating Custom Counter Orders, Trucks, Europe");
            // Instantiate a counter, category "Orders, counter name "Trucks", instance "Europe"
            this.counter2 = new PerformanceCounter(
                "Orders", "Trucks", "Europe");
            Console.WriteLine("Instantiating Custom Counter Orders, Rate of Sales.");
            // Instantiate a counter, category "Orders", counter name "Rate of Sales", single instance.
            this.counter3 = new PerformanceCounter(
                "Orders", "Rate of Sales", "Total");
            Console.WriteLine("Instantiating Custom Counter Inventory, Trucks, Only instance.");
            // Instantiate a single instance counter, category "Inventory", counter name "Trucks".
            this.counter4 = new PerformanceCounter(
                "Inventory", "Trucks", false);

            this.timer1.Start();
        }
    }
}
//</Snippet1>

