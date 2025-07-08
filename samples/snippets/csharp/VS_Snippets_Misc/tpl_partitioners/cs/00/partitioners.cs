using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Numerics;

namespace PartitionerTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Consumer.Main2();
          //  TestDefaultRangePartitioner();
            //TestLoadBalancingCreateMethods();
            // ParallelLoopsWithPartitioner();
            //  XMLWithPartitioner();
            //var q = from num in part.AsParallel()
            //        select num;

            //foreach(var v in q)
            //    Console.WriteLine(v);

            Console.Write("Press any key.");
            Console.ReadKey();
        }

        static void TestDefaultRangePartitioner()
        {

            Console.WriteLine("Operation completed.");
            Console.ReadKey();
        }

        //dummy
        static void ProcessData(double d) { }
        static void ParallelLoopsWithPartitioner()
        {
            //<snippet02>
            // Static partitioning requires indexable source. Load balancing
            // can use any IEnumerable.
            var nums = Enumerable.Range(0, 100000000).ToArray();

            // Create a load-balancing partitioner. Or specify false for static partitioning.
            Partitioner<int> customPartitioner = Partitioner.Create(nums, true);

            // The partitioner is the query's data source.
            var q = from x in customPartitioner.AsParallel()
                    select x * Math.PI;

            q.ForAll((x) =>
            {
                ProcessData(x);
            });
            //</snippet02>

            Stopwatch sw = Stopwatch.StartNew();

            // Must be load balanced partitioner
            // for this simple data source.
         //   Partitioner<int> p = Partitioner.Create(nums, true);

            Parallel.ForEach(customPartitioner, (x) =>
            {
                double d = (double)x * Math.PI;
            }

             );
            Console.WriteLine($"elapsed for Parallel.For: {sw.ElapsedMilliseconds}");

            sw = Stopwatch.StartNew();

            customPartitioner = Partitioner.Create(nums, true);
            var q7 = from x in customPartitioner.AsParallel()
                    select x;// *Math.PI;

            q7.ForAll((x) =>
            {
                double d = (double)x * Math.PI;
            });
            Console.WriteLine($"elapsed for PLINQ with load-balancing: {sw.ElapsedMilliseconds}");

            //  Console.WriteLine("Clearing memory cache");

            //for (int i = 0; i < arr.Length; i++)
            //    arr[i] = Math.PI;

            sw = Stopwatch.StartNew();
            customPartitioner = Partitioner.Create(nums, false);
            var q2 = from x in customPartitioner.AsParallel()
                     select x;// *Math.PI;

            q2.ForAll((x) =>
            {
                double d = (double)x * Math.PI;
            });

            Console.WriteLine($"elapsed for PLINQ without load-balancing: {sw.ElapsedMilliseconds}");
        }

        static void TestLoadBalancingCreateMethods()
        {
            var source = Enumerable.Range(0, 10000).ToLookup((i) => i.ToString());
            var partitioner2 = Partitioner.Create(source);

            //   var p0 = Partitioner.Create(
            Parallel.ForEach(partitioner2, (item) =>
                {
                    Console.WriteLine(item.Key);
                    foreach (var v in item)
                    {
                        Console.WriteLine($"    {(double)(v * .075213):##.###}");
                    }
                });
        }
    }

    class PartTest2
    {
        static CancellationTokenSource cts = new CancellationTokenSource();
        static StringBuilder sb = new StringBuilder();

        static void Main2(string[] args)
        {
            //Math.
            int[] sourceArray = Enumerable.Range(1, 12680).ToArray();
          //  int partitionCount = 4;

            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey(true).KeyChar == 'c')
                    cts.Cancel();
            });

            MyPartitioner mp = new MyPartitioner(sourceArray, .50);

            PartTest2 p = new PartTest2();
            var q = from item in mp.AsParallel()
                    let result = p.FakeFibonacci(item)
                    orderby item
                    select new { Num = item, Result = result, MyThread = Thread.CurrentThread.ManagedThreadId };

            Console.WriteLine("Beginning custom partitioning");

            foreach (var v in q)
            {
                String s = String.Format("Val={0}:Fib={1}:Thread={2} ", v.Num, v.Result, v.MyThread);
                sb.AppendLine(s);
                //  Console.WriteLine(s);
            }

            //Thread.SpinWait(500000000);

            //var q2 = from item in sourceArray.AsParallel()
            //        let result = p.Fibonacci(item)
            //        orderby item
            //        select new { Num = item, Result = result, MyThread = Thread.CurrentThread.ManagedThreadId };

            //Console.WriteLine("Beginning default partitioning.");
            //sb.AppendLine("Beginning default partitioning.");

            //foreach (var v in q2)
            //{
            //       String s = String.Format("Val={0}:Fib={1}:Thread={2} ", v.Num, v.Result, v.MyThread);
            //      sb.AppendLine(s);
            //    //  Console.WriteLine(s);
            //}

            //   System.IO.File.WriteAllText(@"..\..\logfile1.txt", sb.ToString());
            //  Console.WriteLine("Press any key");
            //   Console.ReadKey();
           cts.Dispose();
        }

        BigInteger FakeFibonacci(int i)
        {
            //  SpinWait sw = new SpinWait();
            //  for (int j = 0; j < i; j++)
            Thread.SpinWait(i * 1000);
            return 1;
        }
        BigInteger Fibonacci(int x)
        {
            int loopCounter = 0;
            BigInteger fib1 = 0;
            BigInteger fib2 = 1;
            BigInteger tempTerm;
            do
            {
                if (loopCounter > 1)
                {
                    tempTerm = fib1 + fib2;
                    fib1 = fib2;
                    fib2 = tempTerm;
                }
                loopCounter++;
            } while (loopCounter <= x);

            return fib2;
        }
    }

    //<snippet05>
    // A static range partitioner for sources that require
    // a linear increase in processing time for each succeeding element.
    // The range sizes are calculated based on the rate of increase
    // with the first partition getting the most elements and the
    // last partition getting the least.
    class MyPartitioner : Partitioner<int>
    {
        int[] source;
        double rateOfIncrease = 0;

        public MyPartitioner(int[] source, double rate)
        {
            this.source = source;
            rateOfIncrease = rate;
        }

        public override IEnumerable<int> GetDynamicPartitions()
        {
            throw new NotImplementedException();
        }

        // Not consumable from Parallel.ForEach.
        public override bool SupportsDynamicPartitions
        {
            get
            {
                return false;
            }
        }

        public override IList<IEnumerator<int>> GetPartitions(int partitionCount)
        {
            List<IEnumerator<int>> _list = new List<IEnumerator<int>>();
            int end = 0;
            int start = 0;
            int[] nums = CalculatePartitions(partitionCount, source.Length);

            for (int i = 0; i < nums.Length; i++)
            {
                start = nums[i];
                if (i < nums.Length - 1)
                    end = nums[i + 1];
                else
                    end = source.Length;

                _list.Add(GetItemsForPartition(start, end));

                // For demonstration.
                Console.WriteLine($"start = {start} b (end) = {end}");
            }
            return (IList<IEnumerator<int>>)_list;
        }
        /*
         *
         *
         *                                                               B
          // Model increasing workloads as a right triangle           /  |
             divided into equal areas along vertical lines.         / |  |
             Each partition  is taller and skinnier               /   |  |
             than the last.                                     / |   |  |
                                                              /   |   |  |
                                                            /     |   |  |
                                                          /  |    |   |  |
                                                        /    |    |   |  |
                                                A     /______|____|___|__| C
         */
        private int[] CalculatePartitions(int partitionCount, int sourceLength)
        {
            // Corresponds to the opposite side of angle A, which corresponds
            // to an index into the source array.
            int[] partitionLimits = new int[partitionCount];
            partitionLimits[0] = 0;

            // Represent total work as rectangle of source length times "most expensive element"
            // Note: RateOfIncrease can be factored out of equation.
            double totalWork = sourceLength * (sourceLength * rateOfIncrease);
            // Divide by two to get the triangle whose slope goes from zero on the left to "most"
            // on the right. Then divide by number of partitions to get area of each partition.
            totalWork /= 2;
            double partitionArea = totalWork / partitionCount;

            // Draw the next partitionLimit on the vertical coordinate that gives
            // an area of partitionArea * currentPartition.
            for (int i = 1; i < partitionLimits.Length; i++)
            {
                double area = partitionArea * i;

               // Solve for base given the area and the slope of the hypotenuse.
                partitionLimits[i] = (int)Math.Floor(Math.Sqrt((2 * area) / rateOfIncrease));
            }
            return partitionLimits;
        }

        IEnumerator<int> GetItemsForPartition(int start, int end)
        {
            // For demonstration purposes. Each thread receives its own enumerator.
            Console.WriteLine($"called on thread {Thread.CurrentThread.ManagedThreadId}");
            for (int i = start; i < end; i++)
                yield return source[i];
        }
    }

    class Consumer
    {
        public static void Main2()
        {
            var source = Enumerable.Range(0, 10000).ToArray();

            Stopwatch sw = Stopwatch.StartNew();
            MyPartitioner partitioner = new MyPartitioner(source, .5);

            var query = from n in partitioner.AsParallel()
                        select ProcessData(n);

            foreach (var v in query) { }
            Console.WriteLine($"Processing time with custom partitioner {sw.ElapsedMilliseconds}");

            var source2 = Enumerable.Range(0, 10000).ToArray();

            sw = Stopwatch.StartNew();

            var query2 = from n in source2.AsParallel()
                        select ProcessData(n);

            foreach (var v in query2) { }
            Console.WriteLine($"Processing time with default partitioner {sw.ElapsedMilliseconds}");
        }

        // Consistent processing time for measurement purposes.
        static int ProcessData(int i)
        {
            Thread.SpinWait(i * 1000);
            return i;
        }
    }
    //</snippet05>

    class Dummy2
    {
        //Goes with snippet05. Not used until we figure out why this is the case.

        // More interesting calculation. However, this method
        // does not seem to exhibit the linear increase
        // that is assumed by the partitioner.
        BigInteger Fibonacci(int x)
        {
            int loopCounter = 0;
            BigInteger fib1 = 0;
            BigInteger fib2 = 1;
            BigInteger tempTerm;
            do
            {
                if (loopCounter > 1)
                {
                    tempTerm = fib1 + fib2;
                    fib1 = fib2;
                    fib2 = tempTerm;
                }
                loopCounter++;
            } while (loopCounter <= x);

            return fib2;
        }
    }

    class BasicMathTest
    {
        static void Main2()
        {
            int[] nums = Enumerable.Range(1, 10000).ToArray();
            //   CalculatePartitions(3, 4, 4, nums.Length);

            Console.ReadKey();
        }

        //not working (not correct?)
        public static int[] CalculatePartitionsWithoutUsingSlope(int partitions, int sourceLength)
        {

            partitions = 4;
            int[] boundaries = new int[partitions];
            boundaries[0] = 0;

            //   Console.WriteLine($"totalWork = {sourceLength}");
            double partitionSize = (sourceLength / partitions);
            double location = 0;
            for (int i = 0; i < boundaries.Length; i++)
            {
                Console.WriteLine($"length = {location}");
                boundaries[i] = (int)(Math.Floor(Math.Sqrt(location) * 100));
                location = partitionSize * (i + 1);
            }

            //  Console.WriteLine($"len={height} height={len} area={height * len} hyp={Math.Sqrt(height * height + len * len):###.##}");

            return boundaries;
        }

        public static int[] CalculatePartitions(double height, double len, int partitions, int sourceLength)
        {
            double slope = (double)(height / len);

            int[] boundaries = new int[partitions];
            boundaries[0] = 0;
            ulong totalWork = (ulong)(sourceLength * (sourceLength * slope));
            ulong partitionSize = (ulong)((totalWork / (ulong)partitions) / 2);

            for (int i = 1; i < boundaries.Length; i++)
            {
                double area = partitionSize * (ulong)(i);
                Console.WriteLine($"area = {area}");
                boundaries[i] = (int)Math.Floor(Math.Sqrt((2 * area) / slope));
            }
            Console.WriteLine($"len={height} height={len} area={height * len} hyp={Math.Sqrt(height * height + len * len):###.##}");

            return boundaries;
        }
    }

    namespace myPrivateNamespace
    {
        partial class Dummy
        {
            // used for code snippet in conceptual overview topic
            /*
            //<snippet03>
            // When loadBalance is false - uses static partitioning
            // When loadBalance is true - uses load-balanced partitioning
            public static OrderablePartitioner<TSource> Create<TSource>(IList<TSource> source, bool loadBalance);
            public static OrderablePartitioner<TSource> Create<TSource>(TSource[] source, bool loadBalance);

            // Always uses load-balanced partitioning
            public static OrderablePartitioner<TSource> Create<TSource>(IEnumerator<TSource> source);
            //</snippet03>
            */
        }
    }
}
