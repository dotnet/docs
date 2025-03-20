// <Snippet1>
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Example2
{
    public static void Main()
    {
        List<Task> tasks = new List<Task>();
        Random rnd = new Random();
        long total = 0;
        int n = 0;

        for (int taskCtr = 0; taskCtr < 10; taskCtr++)
            tasks.Add(Task.Run(() =>
            {
                int[] values = new int[10000];
                int taskTotal = 0;
                int taskN = 0;
                int ctr = 0;
                Monitor.Enter(rnd);
                // Generate 10,000 random integers
                for (ctr = 0; ctr < 10000; ctr++)
                    values[ctr] = rnd.Next(0, 1001);
                Monitor.Exit(rnd);
                taskN = ctr;
                foreach (var value in values)
                    taskTotal += value;

                Console.WriteLine("Mean for task {0,2}: {1:N2} (N={2:N0})",
                                  Task.CurrentId, (taskTotal * 1.0) / taskN,
                                  taskN);
                Interlocked.Add(ref n, taskN);
                Interlocked.Add(ref total, taskTotal);
            }));
        try
        {
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"\nMean for all tasks: {(total * 1.0) / n:N2} (N={n:N0})");
        }
        catch (AggregateException e)
        {
            foreach (var ie in e.InnerExceptions)
                Console.WriteLine($"{ie.GetType().Name}: {ie.Message}");
        }
    }
}
// The example displays output like the following:
//       Mean for task  1: 499.04 (N=10,000)
//       Mean for task  2: 500.42 (N=10,000)
//       Mean for task  3: 499.65 (N=10,000)
//       Mean for task  8: 502.59 (N=10,000)
//       Mean for task  5: 502.75 (N=10,000)
//       Mean for task  4: 494.88 (N=10,000)
//       Mean for task  7: 499.22 (N=10,000)
//       Mean for task 10: 496.45 (N=10,000)
//       Mean for task  6: 499.75 (N=10,000)
//       Mean for task  9: 502.79 (N=10,000)
//
//       Mean for all tasks: 499.75 (N=100,000)
// </Snippet1>
