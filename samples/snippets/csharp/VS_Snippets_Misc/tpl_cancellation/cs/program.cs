

//<snippet03>

namespace CancellationWithOCE
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start. Press 'c' to cancel.");
            Console.ReadKey();

            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            // Store references to the tasks so that we can wait on them and
            // observe their status after cancellation.
            Task[] tasks = new Task[10];

            // Request cancellation of a single task when the token source is canceled.
            // Pass the token to the user delegate, and also to the task so it can
            // handle the exception correctly.
            tasks[0] = Task.Factory.StartNew(() => DoSomeWork(1, token), token);

            // Request cancellation of a task and its children. Note the token is passed
            // to (1) the user delegate and (2) as the second argument to StartNew, so
            // that the task instance can correctly handle the OperationCanceledException.
            tasks[1] = Task.Factory.StartNew(() =>
            {
                // Create some cancelable child tasks.
                for (int i = 2; i < 10; i++)
                {
                    // For each child task, pass the same token
                    // to each user delegate and to StartNew.
                    tasks[i] = Task.Factory.StartNew(iteration =>
                                DoSomeWork((int)iteration, token), i, token);
                }
                // Passing the same token again to do work on the parent task.
                // All will be signaled by the call to tokenSource.Cancel below.
                DoSomeWork(2, token);
            }, token);

            // Give the tasks a second to start.
            Thread.Sleep(1000);

            // Request cancellation from the UI thread.
            if (Console.ReadKey().KeyChar == 'c')
            {
                tokenSource.Cancel();
                Console.WriteLine("\nTask cancellation requested.");

                // Optional: Observe the change in the Status property on the task.
                // It is not necessary to wait on tasks that have canceled. However,
                // if you do wait, you must enclose the call in a try-catch block to
                // catch the OperationCanceledExceptions that are thrown. If you do
                // not wait, no OCE is thrown if the token that was passed to the
                // StartNew method is the same token that requested the cancellation.

                #region Optional_WaitOnTasksToComplete
                try
                {
                    Task.WaitAll(tasks);
                }
                catch (AggregateException e)
                {
                    // For demonstration purposes, show the OCE message.
                    foreach (var v in e.InnerExceptions)
                        Console.WriteLine("msg: " + v.Message);
                }

                // Prove that the tasks are now all in a canceled state.
                for (int i = 0; i < tasks.Length; i++)
                    Console.WriteLine($"task[{i}] status is now {tasks[i].Status}");
                #endregion
            }

            // Keep the console window open while the
            // task completes its output.
            Console.ReadLine();
            tokenSource.Dispose();
        }

        static void DoSomeWork(int taskNum, CancellationToken ct)
        {
            // Was cancellation already requested?
            if (ct.IsCancellationRequested)
            {
                Console.WriteLine("We were cancelled before we got started.");
                Console.WriteLine("Press Enter to quit.");
                ct.ThrowIfCancellationRequested();
            }
            int maxIterations = 1000;

            // NOTE!!! A benign "OperationCanceledException was unhandled
            // by user code" error might be raised here. Press F5 to continue. Or,
            //  to avoid the error, uncheck the "Enable Just My Code"
            // option under Tools > Options > Debugging.
            for (int i = 0; i < maxIterations; i++)
            {
                // Do a bit of work. Not too much.
                var sw = new SpinWait();
                for (int j = 0; j < 3000; j++) sw.SpinOnce();
                Console.WriteLine($"...{taskNum} ");
                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine($"bye from {taskNum}.");
                    Console.WriteLine("\nPress Enter to quit.");

                    ct.ThrowIfCancellationRequested();
                }
            }
        }
    }
}
    //</snippet03>
