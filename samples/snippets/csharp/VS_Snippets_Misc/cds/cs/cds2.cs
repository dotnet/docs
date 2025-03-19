

//<snippet01>
namespace ProducerConsumer
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    class Program
    {

        // Limit the collection size to 2000 items
        // at any given time.
        const int upperLimit = 2000;

        static BlockingCollection<long> collection = new BlockingCollection<long>(upperLimit);

        // Variables for diagnostic output only.
        static Stopwatch sw = new Stopwatch();
        static int additions = 0;
        static int subtractions = 0;

        static void Main(string[] args)
        {

            // Start the stopwatch.
            sw.Start();

            // Queue the ProduceData thread.
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunProducer));

            // Queue the ConsumeData thread.
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunConsumer));
            // ThreadPool.QueueUserWorkItem(new WaitCallback(RunConsumer2));

            // Keep the console window open while the
            // consumer thread completes its output.
            Console.ReadKey();
        }

        static void RunProducer(Object stateInfo)
        {

            for (int i = 0; i < 100; i++)
            {

                long ticks = sw.ElapsedTicks;

                // Uncomment this line to see interleaved additions and subtractions.
                Console.WriteLine($"adding tick value {ticks}. item# {additions}");

                collection.Add(ticks);

                // Counter for demonstration purposes only.
                additions++;

                // For demonstration purposes, uncomment this line to
                // slow down the producer thread without sleeping.

                // Thread.SpinWait(100000);
            }

            // Important!!! Tell consumers that no more items will be added.
            collection.CompleteAdding();

            Console.WriteLine($"Done adding: {additions} items");
        }

        static void RunConsumer(Object stateInfo)
        {
            // GetConsumingEnumerable returns the enumerator for the
            // underlying collection.
            foreach (var item in collection.GetConsumingEnumerable())
            {
                Console.WriteLine("Consuming tick value {0} : item# {1} ",
                        item.ToString("D18"), subtractions++);
            }

            Console.WriteLine("Total added: {0} Total consumed: {1} Current count: {2} ",
                                additions, subtractions, collection.Count());
            sw.Stop();

            Console.WriteLine("Press any key to exit");
        }

        //<snippet02>
        static void RunConsumer2(Object stateInfo)
        {
            // Count may be zero while still waiting for more items.
            // IsCompleted may be true while Count is still > 0.
            // Therefore, iterate as long as either condition is true.
            while (collection.IsCompleted == false || collection.Count > 0)
            {
                long ticks = 0;
                bool b = collection.TryTake(out ticks, 30);
                if (b == true)
                {
                    Console.WriteLine("Consuming {0} : {1} ", ticks.ToString("D18"), subtractions++);
                }
                else
                {
                    // Do something else useful before trying again.
                    Console.WriteLine("Doing something useful here");
                }
            }

            Console.WriteLine($"Total added: {additions} Total consumed: {subtractions} Current count: {collection.Count} ");
        }
        //</snippet02>
    }
}
//</snippet01>

//<snippet03>
namespace BlockingCollectionExamples
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;

    class Data
    {
        public string City { get; set; }
        public int Population { get; set; }
    }

    class Blocking
    {

        private static BlockingCollection<Data> blockingCollection = new BlockingCollection<Data>(10);

        // Some data to add.
        static string[] cities = new string[10] { "London", "Mumbai", "Beijing", "Baghdad", "Paris", "Berlin", "Moscow", "Sydney", "Buenos Aires", "Tokyo" };
        static double[] population = new double[10] { 7.65, 18.041, 12.037, 4.795, 9.642, 3.339, 9.3, 3.664, 12.435, 38.027 };

        static void Main()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ConsumeData), blockingCollection);
            Thread.Sleep(100); //Give the other thread time to spin up.

            // Produce data
            for (int i = 0; i < cities.Length; i++)
            {
                blockingCollection.Add(new Data() { City = cities[i], Population = (int)(population[i] * 1000000) });
                Thread.SpinWait(5000000); // Simulate some extra work.
            }
            blockingCollection.CompleteAdding();

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        // Consume concurrently from other thread until collection is empty.
        private static void ConsumeData(object collection)
        {
            BlockingCollection<Data> coll = (BlockingCollection<Data>)collection;
            foreach (Data d in coll.GetConsumingEnumerable())
            {
                Console.WriteLine($"The population of {d.City} is approximately {d.Population}");
            }
            Console.WriteLine("Done");
        }
    }
}
//</snippet03>

namespace Demos
{
    using System;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Collections.Concurrent;
    using System.Text;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    //<snippet08>

    class MyBarrier
    {
        const int Partitions = 3;

        static byte[][] data = new byte[Partitions][];
        static double[] results = new double[Partitions];

        static void Main()
        {
            // Create a new barrier, specifying a participant count and a
            // delegate to invoke when the first phase is complete.
            Barrier b = new Barrier(Partitions);

            Task[] tasks = new Task[Partitions];
            for (int i = 0; i < Partitions; i++)
            {
                // Declare a variable that captures
                // changing value of i on each iteration.
                int index = i;

                tasks[i] = Task.Run(() =>
                {

                    // Fill each buffer, then wait.
                    GenerateDataForMyPartition(index);
                    b.SignalAndWait();

                    // Compare results from all
                    ComputeForMyPartition(index);
                    b.SignalAndWait();
                });
            }

            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }

        // Toy implementation to generate some data.
        static void GenerateDataForMyPartition(int taskNumber)
        {
            data[taskNumber] = new byte[100];
            var rand = new Random();
            rand.NextBytes(data[taskNumber]);

            Console.WriteLine($"Generate for {taskNumber}");
            int total = 0;
            foreach (var b in data[taskNumber])
            {
                total += b;
            }
            results[taskNumber] = (double)((double)total / data[taskNumber].Length);
            Console.WriteLine($"results[{taskNumber}] = {results[taskNumber]}");
        }

        // In this example, we simply take the average and compare it to other partitions.
        // In a real-world application, this would be a more computationally expensive
        // operation.
        static void ComputeForMyPartition(int index)
        {
            double myAverage = results[index];
            var sb = new StringBuilder();
            sb.AppendFormat("results for buffer[{0}]:\n", index);
            for (int i = 0; i < results.Length; i++)
            {
                if (i == index) continue; // Don't compare to myself.
                var them = results[i];
                var diff = Math.Abs(them - myAverage);

                if(myAverage > them)
                    sb.AppendFormat("    greater than buffer[{0}] by {1}\n", i, diff);
                else if (myAverage == them)
                        sb.AppendFormat("    equal to buffer[{0}]\n", i, diff);
                else if (myAverage < them)
                    sb.AppendFormat("    less than buffer[{0}] by {1}\n", i, diff);
            }

            Console.WriteLine(sb.ToString());
        }
    }
    //</snippet08>

    //might use this for another barrier example
    class HoldingPatter
    {
        static byte[][] data = new byte[10][]; //
        static void AdjustValues(int index, double factor)
        {

            for (int i = 0; i < data[index].Length; i++)
            {
                var val = data[index][i];
                var newVal = val * factor;
                data[index][i] = newVal > 1 ? (byte)newVal : (byte)255;
            }
        }
    }

    class MyBarrierOld
    {
        const int P = 4;

        static void Main()
        {
            byte[][] data = new byte[P][];
            Barrier b = new Barrier(P);
            Task[] tasks = new Task[P];

            for (int i = 0; i < P; i++)
            {
                int index = i;
                tasks[i] = Task.Run(() =>
                {
                    GenerateDataForMyPartition(index, data);
                    b.SignalAndWait();
                    CompareMyPartitionToTotal(index, data);
                });
            }
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }

        static void GenerateDataForMyPartition(int index, byte[][] buffer)
        {
            var rand = new Random();
            var myBytes = new Byte[50];
            rand.NextBytes(myBytes);
            buffer[index] = myBytes;
        }

        static void CompareMyPartitionToTotal(int index, byte[][] buffer)
        {
            // To gain efficiency, the average value of all buffers
            // could be calculated once instead of once per task.
            var average = (from buf in buffer
                           from b in buf
                           select b).Average(n => n);

            var myAverage = buffer[index].Average(n => n);
            if (myAverage > average)
            {
                Console.WriteLine($"Buffer [{index}] is above average!");
            }
        }
    }

        //class Lazy<T> : Lazy<T> where T: MyClass, new()
        //{
        //    public Lazy(Action<T> action)
        //    {
        //        return new MyClass(() => "test");
        //    }
        //    public Lazy()
        //{}
        //}

    class DataInitializedFromDb
            {
                public DataInitializedFromDb (SqlDataReader reader){}
                public int Rows = 0;
            }
        //class ThreadLocal<T>
        //{
        //    public ThreadLocal(T input) {}
        //    public T Value {get; set;}
        //}
        /*
            class LazyDemo
            {
                static void Main()
                {
                    Lazy<MyClass> mc = new Lazy<MyClass>();

                    LazyInit.EnsureInitialized<MyClass>(ref mc);


                    MyClass mc2 = null;

                    LazyInit.EnsureInitialized<MyClass>(ref mc2);

                    Console.WriteLine("I've created the LI");

                    Console.WriteLine("Process Data? Y/N");
                    char c = Console.ReadKey().KeyChar;
                    if (c == 'y' || c == 'Y')
                        //  mc.Value.DoSomething();
                        mc.Value.DoSomething();

                    else
                        Console.WriteLine("Program complete.");

                    Console.WriteLine("Enter Name to find? Exapmle: Fred ");
                    string s = Console.ReadLine();

                    if (s.Length > 0)
                    {
                        Console.WriteLine("mc.Value.data.Value");
                        mc = new Lazy<MyClass>(() => new MyClass(s));
                        Console.WriteLine(mc.Value.data.Value.Name);

                    }
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                }

                static void Test()
                {
                    // snip pet 9 was here. deleted per JoshP

                }

                private static void ProcessData(DataInitializedFromDb data){}
                private static void Test2()
                {
                    string cmdText = "";
                    // was snippet 10 removed per joshp

                    Lazy<DataInitializedFromDb> _data =
                        new Lazy<DataInitializedFromDb>(delegate
                    {
                        using(SqlConnection conn = new SqlConnection(...))
                        using(SqlCommand comm = new SqlCommand(cmdText, conn))
                        {
                            SqlDataReader reader = comm.ExecuteReader();
                            DataInitializedFromDb data =
                                new DataInitializedFromDb(reader);
                            return data;
                        }
                    }, LazyExecutionMode.AllowMultipleThreadSafeExecutions);

                    // use the data
                    if (_data.Value.Rows > 10)
                    {
                        ProcessData(_data.Value);
                    }
                    ///snippet 10
                }

                private static int Compute(int i){return i;}
                private static void Test3()
                {
                    //<snippet11>
                    //Initializing a value with a big computation, computed in parallel
                    Lazy<int> _data = new Lazy<int>(delegate
                    {
                        return ParallelEnumerable.Range(0, 1000).
                            Select(i => Compute(i)).Aggregate((x,y) => x + y);
                    }, LazyExecutionMode.EnsureSingleThreadSafeExecution);
                  //  ...
                    // use the data
                    if (_data.Value > 100)
                    {
                        Console.WriteLine("Good data");
                    }
                    //</snippet11>
                }




                   //<snippet12>
                    // Direct initialization to avoid overhead
                    static List<Exception> m_exceptions;

                    static void AddException(Exception e)
                    {
                        LazyInitializer.EnsureInitialized(ref m_exceptions).Add(e);
                    }
                    //</snippet12>

                 private static void Test5()
                {
                    //<snippet13>
                    //Initializing a value per thread, per instance
                     ThreadLocal<int[][]> _scratchArrays =
                         new ThreadLocal<int[][]>(InitializeArrays);
                    // . . .
                     static int[][] InitializeArrays () {return new int[][]}
                    //   . . .
                    // use the thread-local data
                    int i = 8;
                    int [] tempArr = _scratchArrays.Value[i];
                //</snippet13>

                }

                    static void Test6()
                    {

                        //<snippet14>
                        Action<int>[] actions = new Action<int>[5];
                        // ...initialize actions

                        // Lazily-initializing a local with minimal overhead
                        var exceptions = new LazyVariable<List<Exception>>();
                        foreach(var action in actions)
                        {
                            try
                            {
                                action();
                            }
                            catch(Exception exc)
                            {
                                exceptions.Value.Add(exc);
                            }
                        }
                        if (exceptions.IsValueCreated)
                            throw new AggregateException(exceptions.Value);

                    //</snippet14>
                    }

    }

        class Data
        {
            public Data(string s) { Name = s; }
            public string Name {get; set;}
            public int Number {get; set;}
            //... assume
        }
            class MyClass
            {

                public LazyVariable<Data> data;
                public MyClass()
                {
                    Console.WriteLine("Default constructor called.");
                }
                public MyClass(string str)
                {
                    Console.Write("Constructor with string argument called: ");
                    data = new LazyVariable<Data>( () => new Data(str));
                    Console.WriteLine(data.Value.Name);
                }

                public void DoSomething()
                {
                    Console.WriteLine("Do something");
                }

            }
            */

    // NOT USED!!!!!
    //<snippet15>
    class MRES
    {
        static ManualResetEventSlim _signalled = new ManualResetEventSlim();
        static byte[] data = new byte[4];

        static void Main()
        {
            SpinUntilCondition();
        }

        private static void SpinUntilCondition()
        {
            // Do something on another thread.
            ThreadPool.QueueUserWorkItem(new WaitCallback(PostData), null);

            // The data will be ready very soon.
            _signalled.Wait();

            //Consume data
            Console.WriteLine($"{0:X} {1:X} {2:X} {3:X}");
        }

        static void PostData(object state)
        {
            Random rand = new Random();
            rand.NextBytes(data);
            _signalled.Set();
        }
    }
    //</snippet15>
    }

class Test5
{
}
