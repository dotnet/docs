//<snippet03>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class ParallelOptionsDemo
{
    // Demonstrated features:
    // 		Parallel.For()
    //		ParallelOptions
    // Expected results:
    // 		An iteration for each argument value (0, 1, 2, 3, 4, 5, 6, 7, 8, 9) is executed.
    //		The order of execution of the iterations is undefined.
    //		Verify that no more than two threads have been used for the iterations.
    // Documentation:
    //		http://msdn.microsoft.com/library/system.threading.tasks.parallel.for(VS.100).aspx
    static void Main()
    {
        ParallelOptions options = new ParallelOptions();
        options.MaxDegreeOfParallelism = 2; // -1 is for unlimited. 1 is for sequential.

        try
        {
            Parallel.For(
                    0,
                    9,
                    options,
                    (i) =>
                    {
                        Console.WriteLine("Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
                    }
                );
        }
        // No exception is expected in this example, but if one is still thrown from a task,
        // it will be wrapped in AggregateException and propagated to the main thread.
        catch (AggregateException e)
        {
            Console.WriteLine($"Parallel.For has thrown the following (unexpected) exception:\n{e}");
        }
    }
}


//</snippet03>