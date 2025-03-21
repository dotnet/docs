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

        static void RunProducer(object stateInfo)
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
            foreach (long item in collection.GetConsumingEnumerable())
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
        static string[] s_cities = ["London", "Mumbai", "Beijing", "Baghdad", "Paris", "Berlin", "Moscow", "Sydney", "Buenos Aires", "Tokyo"];
        static double[] s_population = [7.65, 18.041, 12.037, 4.795, 9.642, 3.339, 9.3, 3.664, 12.435, 38.027];

        static void Main()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ConsumeData), blockingCollection);
            Thread.Sleep(100); //Give the other thread time to spin up.

            // Produce data
            for (int i = 0; i < s_cities.Length; i++)
            {
                blockingCollection.Add(new Data() { City = s_cities[i], Population = (int)(s_population[i] * 1000000) });
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
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Data.SqlClient;

    //<snippet08>

    class MyBarrier
    {
        const int Partitions = 3;

        static byte[][] s_data = new byte[Partitions][];
        static double[] s_results = new double[Partitions];

        static void Main()
        {
            // Create a new barrier, specifying a participant count and a
            // delegate to invoke when the first phase is complete.
            Barrier b = new(Partitions);

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
            s_data[taskNumber] = new byte[100];
            var rand = new Random();
            rand.NextBytes(s_data[taskNumber]);

            Console.WriteLine($"Generate for {taskNumber}");
            int total = 0;
            foreach (byte b in s_data[taskNumber])
            {
                total += b;
            }
            s_results[taskNumber] = (double)((double)total / s_data[taskNumber].Length);
            Console.WriteLine($"results[{taskNumber}] = {s_results[taskNumber]}");
        }

        // In this example, we simply take the average and compare it to other partitions.
        // In a real-world application, this would be a more computationally expensive
        // operation.
        static void ComputeForMyPartition(int index)
        {
            double myAverage = s_results[index];
            var sb = new StringBuilder();
            sb.AppendFormat("results for buffer[{0}]:\n", index);
            for (int i = 0; i < s_results.Length; i++)
            {
                if (i == index) continue; // Don't compare to myself.
                double them = s_results[i];
                var diff = Math.Abs(them - myAverage);

                if (myAverage > them)
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

    class MyBarrierOld
    {
        const int P = 4;

        static void Main()
        {
            byte[][] data = new byte[P][];
            Barrier b = new(P);
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
            byte[] myBytes = new byte[50];
            rand.NextBytes(myBytes);
            buffer[index] = myBytes;
        }

        static void CompareMyPartitionToTotal(int index, byte[][] buffer)
        {
            // To gain efficiency, the average value of all buffers
            // could be calculated once instead of once per task.
            double average = (from buf in buffer
                           from b in buf
                           select b).Average(n => n);

            double myAverage = buffer[index].Average(n => n);
            if (myAverage > average)
            {
                Console.WriteLine($"Buffer [{index}] is above average!");
            }
        }
    }

    class DataInitializedFromDb
    {
        public DataInitializedFromDb(SqlDataReader reader) { }
        public int Rows = 0;
    }
}

class Test5
{
}
