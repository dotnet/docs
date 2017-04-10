// <Snippet1>
using System;
using System.Threading;

class WaitOne
{
    static AutoResetEvent autoEvent = new AutoResetEvent(false);

    static void Main()
    {
        Console.WriteLine("Main starting.");

        ThreadPool.QueueUserWorkItem(
            new WaitCallback(WorkMethod), autoEvent);

        // Wait for work method to signal.
        autoEvent.WaitOne();
        Console.WriteLine("Work method signaled.\nMain ending.");
    }

    static void WorkMethod(object stateInfo) 
    {
        Console.WriteLine("Work starting.");

        // Simulate time spent working.
        Thread.Sleep(new Random().Next(100, 2000));

        // Signal that work is finished.
        Console.WriteLine("Work ending.");
        ((AutoResetEvent)stateInfo).Set();
    }
}
// </Snippet1>