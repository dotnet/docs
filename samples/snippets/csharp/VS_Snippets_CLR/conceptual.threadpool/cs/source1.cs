// <snippet1>
using System;
using System.Threading;

public class Example
{
    public static void Main()
    {
        // Queue the task.
        ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));

        Console.WriteLine("Main thread does some work, then sleeps.");
        // If you comment out the Sleep, the main thread exits before
        // the thread pool task runs.  The thread pool uses background
        // threads, which do not keep the application running.  (This
        // is a simple example of a race condition.)
        Thread.Sleep(1000);

        Console.WriteLine("Main thread exits.");
    }

    // This thread procedure performs the task.
    static void ThreadProc(Object stateInfo)
    {
        // No state object was passed to QueueUserWorkItem, so
        // stateInfo is null.
        Console.WriteLine("Hello from the thread pool.");
    }
}
// </snippet1>
