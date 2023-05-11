// <Snippet1>
using System;
using System.Threading;

public class Example
{
    public static void Main()
    {
        // Create the token source.
        CancellationTokenSource cts = new CancellationTokenSource();

        // Pass the token to the cancelable operation.
        ThreadPool.QueueUserWorkItem(new WaitCallback(DoSomeWork), cts.Token);
        Thread.Sleep(2500);

        // Request cancellation.
        cts.Cancel();
        Console.WriteLine("Cancellation set in token source...");
        Thread.Sleep(2500);
        // Cancellation should have happened, so call Dispose.
        cts.Dispose();
    }

    // Thread 2: The listener
    static void DoSomeWork(object? obj)
    {
        if (obj is null)
            return;

        CancellationToken token = (CancellationToken)obj;

        for (int i = 0; i < 100000; i++)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("In iteration {0}, cancellation has been requested...",
                                  i + 1);
                // Perform cleanup if necessary.
                //...
                // Terminate the operation.
                break;
            }
            // Simulate some work.
            Thread.SpinWait(500000);
        }
    }
}
// The example displays output like the following:
//       Cancellation set in token source...
//       In iteration 1430, cancellation has been requested...
// </Snippet1>
