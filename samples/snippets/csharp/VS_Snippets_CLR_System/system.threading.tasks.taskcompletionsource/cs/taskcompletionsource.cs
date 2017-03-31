//<snippet01>
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class TCSDemo
{
    // Demonstrated features:
    // 		TaskCompletionSource ctor()
    // 		TaskCompletionSource.SetResult()
    // 		TaskCompletionSource.SetException()
    //		Task.Result
    // Expected results:
    // 		The attempt to get t1.Result blocks for ~1000ms until tcs1 gets signaled. 15 is printed out.
    // 		The attempt to get t2.Result blocks for ~1000ms until tcs2 gets signaled. An exception is printed out.
    static void Main()
    {
        TaskCompletionSource<int> tcs1 = new TaskCompletionSource<int>();
        Task<int> t1 = tcs1.Task;

        // Start a background task that will complete tcs1.Task
        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(1000);
            tcs1.SetResult(15);
        });

        // The attempt to get the result of t1 blocks the current thread until the completion source gets signaled.
        // It should be a wait of ~1000 ms.
        Stopwatch sw = Stopwatch.StartNew();
        int result = t1.Result;
        sw.Stop();

        Console.WriteLine("(ElapsedTime={0}): t1.Result={1} (expected 15) ", sw.ElapsedMilliseconds, result);

        // ------------------------------------------------------------------

        // Alternatively, an exception can be manually set on a TaskCompletionSource.Task
        TaskCompletionSource<int> tcs2 = new TaskCompletionSource<int>();
        Task<int> t2 = tcs2.Task;

        // Start a background Task that will complete tcs2.Task with an exception
        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(1000);
            tcs2.SetException(new InvalidOperationException("SIMULATED EXCEPTION"));
        });

        // The attempt to get the result of t2 blocks the current thread until the completion source gets signaled with either a result or an exception.
        // In either case it should be a wait of ~1000 ms.
        sw = Stopwatch.StartNew();
        try
        {
            result = t2.Result;

            Console.WriteLine("t2.Result succeeded. THIS WAS NOT EXPECTED.");
        }
        catch (AggregateException e)
        {
            Console.Write("(ElapsedTime={0}): ", sw.ElapsedMilliseconds);
            Console.WriteLine("The following exceptions have been thrown by t2.Result: (THIS WAS EXPECTED)");
            for (int j = 0; j < e.InnerExceptions.Count; j++)
            {
                Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
            }
        }
    }

}
//</snippet01>