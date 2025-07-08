// <Snippet04>
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
    public static async Task Main()
    {
        // Cancellation token source for cancellation. Make sure to dispose after use (which is done here through the using expression).
        using var tokenSource = new CancellationTokenSource();

        // The cancellation token will be used to communicate cancellation to tasks
        var token = tokenSource.Token;

        Console.WriteLine("Main: Press any key to begin tasks...");
        Console.ReadKey(true);
        Console.WriteLine("Main: To terminate the example, press 'c' to cancel and exit...");
        Console.WriteLine();

        // Store references to the tasks so that we can wait on them and
        // observe their status after cancellation.
        var tasks = new ConcurrentBag<Task>();

        // Pass the token to the user delegate so it can cancel during execution,
        // and also to the task so it can cancel before execution starts.
        var cancellableTask = Task.Run(() => {
            DoSomeWork(token);
            Console.WriteLine($"Cancellable: Task {Task.CurrentId} ran to completion");
        }, token);
        Console.WriteLine($"Main: Cancellable Task {cancellableTask.Id} created");
        tasks.Add(cancellableTask);

        var parentTask = Task.Run(() =>
        {
            for (int i = 0; i <= 7; i++)
            {
                // If cancellation was requested we don't need to start any more
                // child tasks (that would immediately cancel) => break out of loop
                if (token.IsCancellationRequested) break;

                // For each child task, pass the same token
                // to each user delegate and to Task.Run.
                var childTask = Task.Run(() => {
                    DoSomeWork(token);
                    Console.WriteLine($"Child: Task {Task.CurrentId} ran to completion");
                }, token);
                Console.WriteLine($"Parent: Task {childTask.Id} created");
                tasks.Add(childTask);

                DoSomeWork(token, maxIterations: 1);
            }

            Console.WriteLine($"Parent: Task {Task.CurrentId} ran to completion");
        }, token);
        Console.WriteLine($"Main: Parent Task {parentTask.Id} created");
        tasks.Add(parentTask);

        // Request cancellation from the UI thread.
        char ch = Console.ReadKey().KeyChar;
        if (ch == 'c' || ch == 'C')
        {
            tokenSource.Cancel();
            Console.WriteLine("\nMain: Task cancellation requested.");

            // Optional: Observe the change in the Status property on the task.
            // It is not necessary to wait on tasks that have canceled. However,
            // if you do wait, you must enclose the call in a try-catch block to
            // catch the OperationCanceledExceptions that are thrown. If you do
            // not wait, no exception is thrown if the token that was passed to the
            // Task.Run method is the same token that requested the cancellation.
        }

        try
        {
            // Wait for all tasks before disposing the cancellation token source
            await Task.WhenAll(tasks);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine($"\nMain: {nameof(OperationCanceledException)} thrown\n");
        }

        // Display status of all tasks.
        foreach (var task in tasks)
        {
            Console.WriteLine($"Main: Task {task.Id} status is now {task.Status}");
        }
    }

    static void DoSomeWork(CancellationToken ct, int maxIterations = 10)
    {
        // Was cancellation already requested?
        if (ct.IsCancellationRequested)
        {
            Console.WriteLine($"Task {Task.CurrentId} was cancelled before it got started.");
            ct.ThrowIfCancellationRequested();
        }

        // NOTE!!! A "TaskCanceledException was unhandled
        // by user code" error will be raised here if "Just My Code"
        // is enabled on your computer. On Express editions JMC is
        // enabled and cannot be disabled. The exception is benign.
        // Just press F5 to continue executing your code.
        for (int i = 0; i <= maxIterations; i++)
        {
            // Do a bit of work. Not too much.
            var sw = new SpinWait();
            for (int j = 0; j <= 100; j++)
                sw.SpinOnce();

            if (ct.IsCancellationRequested)
            {
                Console.WriteLine($"Task {Task.CurrentId} work cancelled");
                ct.ThrowIfCancellationRequested();
            }
        }
    }
}
// The example displays output like the following:
//    Main: Press any key to begin tasks...
//    Main: To terminate the example, press 'c' to cancel and exit...
//
//    Main: Cancellable Task 13 created
//    Main: Parent Task 14 created
//    Parent: Task 15 created
//    Parent: Task 16 created
//    Parent: Task 17 created
//    Parent: Task 18 created
//    Parent: Task 19 created
//    Parent: Task 20 created
//    Cancellable: Task 13 ran to completion
//    Child: Task 15 ran to completion
//    Parent: Task 21 created
//    Child: Task 16 ran to completion
//    Parent: Task 22 created
//    Child: Task 17 ran to completion
//    c
//    Main: Task cancellation requested.
//    Task 20 work cancelled
//    Task 21 work cancelled
//    Task 22 work cancelled
//    Task 18 work cancelled
//    Task 14 work cancelled
//    Task 19 work cancelled
//
//    Main: OperationCanceledException thrown
//
//    Main: Task 22 status is now Canceled
//    Main: Task 21 status is now Canceled
//    Main: Task 20 status is now Canceled
//    Main: Task 19 status is now Canceled
//    Main: Task 18 status is now Canceled
//    Main: Task 17 status is now RanToCompletion
//    Main: Task 16 status is now RanToCompletion
//    Main: Task 15 status is now RanToCompletion
//    Main: Task 14 status is now Canceled
//    Main: Task 13 status is now RanToCompletion
// </Snippet04>
