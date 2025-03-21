//<snippet05>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class ParallelForCancellation
{
    // Demonstrated features:
    //		CancellationTokenSource
    // 		Parallel.For()
    //		ParallelOptions
    //		ParallelLoopResult
    // Expected results:
    // 		An iteration for each argument value (0, 1, 2, 3, 4, 5, 6, 7, 8, 9) is executed.
    //		The order of execution of the iterations is undefined.
    //		The iteration when i=2 cancels the loop.
    //		Some iterations may bail out or not start at all; because they are temporally executed in unpredictable order,
    //          it is impossible to say which will start/complete and which won't.
    //		At the end, an OperationCancelledException is surfaced.
    // Documentation:
    //		http://msdn.microsoft.com/library/system.threading.cancellationtokensource(VS.100).aspx
    static void CancelDemo()
    {
        CancellationTokenSource cancellationSource = new CancellationTokenSource();
        ParallelOptions options = new ParallelOptions();
        options.CancellationToken = cancellationSource.Token;

        try
        {
            ParallelLoopResult loopResult = Parallel.For(
                    0,
                    10,
                    options,
                    (i, loopState) =>
                    {
                        Console.WriteLine("Start Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);

                        // Simulate a cancellation of the loop when i=2
                        if (i == 2)
                        {
                            cancellationSource.Cancel();
                        }

                        // Simulates a long execution
                        for (int j = 0; j < 10; j++)
                        {
                            Thread.Sleep(1 * 200);

                            // check to see whether or not to continue
                            if (loopState.ShouldExitCurrentIteration) return;
                        }

                        Console.WriteLine("Finish Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
                    }
                );

            if (loopResult.IsCompleted)
            {
                Console.WriteLine("All iterations completed successfully. THIS WAS NOT EXPECTED.");
            }
        }
        // No exception is expected in this example, but if one is still thrown from a task,
        // it will be wrapped in AggregateException and propagated to the main thread.
        catch (AggregateException e)
        {
            Console.WriteLine($"Parallel.For has thrown an AggregateException. THIS WAS NOT EXPECTED.\n{e}");
        }
        // Catching the cancellation exception
        catch (OperationCanceledException e)
        {
            Console.WriteLine("An iteration has triggered a cancellation. THIS WAS EXPECTED.\n{0}", e.ToString());
        }
        finally
        {
           cancellationSource.Dispose();
        }
    }
}
//</snippet05>
