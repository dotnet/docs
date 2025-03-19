// <Snippet12>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example6
{
    public static void Main()
    {
        // Create a cancellation token and cancel it.
        var source1 = new CancellationTokenSource();
        var token1 = source1.Token;
        source1.Cancel();
        // Create a cancellation token for later cancellation.
        var source2 = new CancellationTokenSource();
        var token2 = source2.Token;

        // Create a series of tasks that will complete, be cancelled, 
        // timeout, or throw an exception.
        Task[] tasks = new Task[12];
        for (int i = 0; i < 12; i++)
        {
            switch (i % 4)
            {
                // Task should run to completion.
                case 0:
                    tasks[i] = Task.Run(() => Thread.Sleep(2000));
                    break;
                // Task should be set to canceled state.
                case 1:
                    tasks[i] = Task.Run(() => Thread.Sleep(2000),
                             token1);
                    break;
                case 2:
                    // Task should throw an exception.
                    tasks[i] = Task.Run(() => { throw new NotSupportedException(); });
                    break;
                case 3:
                    // Task should examine cancellation token.
                    tasks[i] = Task.Run(() =>
                    {
                        Thread.Sleep(2000);
                        if (token2.IsCancellationRequested)
                            token2.ThrowIfCancellationRequested();
                        Thread.Sleep(500);
                    }, token2);
                    break;
            }
        }
        Thread.Sleep(250);
        source2.Cancel();

        try
        {
            Task.WaitAll(tasks);
        }
        catch (AggregateException ae)
        {
            Console.WriteLine("One or more exceptions occurred:");
            foreach (var ex in ae.InnerExceptions)
                Console.WriteLine("   {0}: {1}", ex.GetType().Name, ex.Message);
        }

        Console.WriteLine("\nStatus of tasks:");
        foreach (var t in tasks)
        {
            Console.WriteLine($"   Task #{t.Id}: {t.Status}");
            if (t.Exception != null)
            {
                foreach (var ex in t.Exception.InnerExceptions)
                    Console.WriteLine("      {0}: {1}", ex.GetType().Name,
                                      ex.Message);
            }
        }
    }
}
// The example displays output like the following:
//   One or more exceptions occurred:
//      TaskCanceledException: A task was canceled.
//      NotSupportedException: Specified method is not supported.
//      TaskCanceledException: A task was canceled.
//      TaskCanceledException: A task was canceled.
//      NotSupportedException: Specified method is not supported.
//      TaskCanceledException: A task was canceled.
//      TaskCanceledException: A task was canceled.
//      NotSupportedException: Specified method is not supported.
//      TaskCanceledException: A task was canceled.
//   
//   Status of tasks:
//      Task #13: RanToCompletion
//      Task #1: Canceled
//      Task #3: Faulted
//         NotSupportedException: Specified method is not supported.
//      Task #8: Canceled
//      Task #14: RanToCompletion
//      Task #4: Canceled
//      Task #6: Faulted
//         NotSupportedException: Specified method is not supported.
//      Task #7: Canceled
//      Task #15: RanToCompletion
//      Task #9: Canceled
//      Task #11: Faulted
//         NotSupportedException: Specified method is not supported.
//      Task #12: Canceled
// </Snippet12>
