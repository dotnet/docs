// <Snippet1>
using System;
using System.Threading;

class IsThreadPool
{
    static void Main()
    {
        AutoResetEvent autoEvent = new AutoResetEvent(false);

        Thread regularThread = 
            new Thread(new ThreadStart(ThreadMethod));
        regularThread.Start();
        ThreadPool.QueueUserWorkItem(new WaitCallback(WorkMethod), 
            autoEvent);

        // Wait for foreground thread to end.
        regularThread.Join();

        // Wait for background thread to end.
        autoEvent.WaitOne();
    }

    // <Snippet2>
    static void ThreadMethod()
    {
        Console.WriteLine("ThreadOne, executing ThreadMethod, " +
            "is {0}from the thread pool.", 
            Thread.CurrentThread.IsThreadPoolThread ? "" : "not ");
    }
    // </Snippet2>

    static void WorkMethod(object stateInfo)
    {
        Console.WriteLine("ThreadTwo, executing WorkMethod, " +
            "is {0}from the thread pool.", 
            Thread.CurrentThread.IsThreadPoolThread ? "" : "not ");

        // Signal that this thread is finished.
        ((AutoResetEvent)stateInfo).Set();
    }
}
// </Snippet1>