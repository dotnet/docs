//<snippet02>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class ForEachWithThreadLocal
{
    // Demonstrated features:
    // 		Parallel.ForEach()
    //		Thread-local state
    // Expected results:
    //      This example sums up the elements of an int[] in parallel.
    //      Each thread maintains a local sum. When a thread is initialized, that local sum is set to 0.
    //      On every iteration the current element is added to the local sum.
    //      When a thread is done, it safely adds its local sum to the global sum.
    //      After the loop is complete, the global sum is printed out.
    // Documentation:
    //		http://msdn.microsoft.com/library/dd990270(VS.100).aspx
    static void Main()
    {
        // The sum of these elements is 40.
        int[] input = { 4, 1, 6, 2, 9, 5, 10, 3 };
        int sum = 0;

        try
        {
            Parallel.ForEach(
                    input,					        // source collection
                    () => 0,					        // thread local initializer
                    (n, loopState, localSum) =>		// body
                    {
                        localSum += n;
                        Console.WriteLine("Thread={0}, n={1}, localSum={2}", Thread.CurrentThread.ManagedThreadId, n, localSum);
                        return localSum;
                    },
                    (localSum) => Interlocked.Add(ref sum, localSum)					// thread local aggregator
                );

            Console.WriteLine($"\nSum={sum}");
        }
        // No exception is expected in this example, but if one is still thrown from a task,
        // it will be wrapped in AggregateException and propagated to the main thread.
        catch (AggregateException e)
        {
            Console.WriteLine($"Parallel.ForEach has thrown an exception. THIS WAS NOT EXPECTED.\n{e}");
        }
    }
}
//</snippet02>
