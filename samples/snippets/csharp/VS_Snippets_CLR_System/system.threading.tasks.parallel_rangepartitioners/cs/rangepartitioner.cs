//<snippet01>
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class RangePartitionerDemo 
{
        static void Main()
        {
            Stopwatch sw = null;

            long sum = 0;
            long SUMTOP = 10000000;

            // Try sequential for
            sw = Stopwatch.StartNew();
            for (long i = 0; i < SUMTOP; i++) sum += i;
            sw.Stop();
            Console.WriteLine("sequential for result = {0}, time = {1} ms", sum, sw.ElapsedMilliseconds);

            // Try parallel for -- this is slow!
            //sum = 0;
            //sw = Stopwatch.StartNew();
            //Parallel.For(0L, SUMTOP, (item) => Interlocked.Add(ref sum, item));
            //sw.Stop();
            //Console.WriteLine("parallel for  result = {0}, time = {1} ms", sum, sw.ElapsedMilliseconds);

            // Try parallel for with locals
            sum = 0;
            sw = Stopwatch.StartNew();
            Parallel.For(0L, SUMTOP, () => 0L, (item, state, prevLocal) => prevLocal + item, local => Interlocked.Add(ref sum, local));
            sw.Stop();
            Console.WriteLine("parallel for w/locals result = {0}, time = {1} ms", sum, sw.ElapsedMilliseconds);

            // Try range partitioner
            sum = 0;
            sw = Stopwatch.StartNew();
            Parallel.ForEach(Partitioner.Create(0L, SUMTOP), (range) =>
            {
                long local = 0;
                for (long i = range.Item1; i < range.Item2; i++) local += i;
                Interlocked.Add(ref sum, local);
            });
            sw.Stop();
            Console.WriteLine("range partitioner result = {0}, time = {1} ms", sum, sw.ElapsedMilliseconds);
        }
}
//</snippet01>