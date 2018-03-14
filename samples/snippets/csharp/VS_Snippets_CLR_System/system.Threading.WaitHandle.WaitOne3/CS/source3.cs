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
        if(autoEvent.WaitOne(new TimeSpan(0, 0, 1), false))
        {
            Console.WriteLine("Work method signaled.");
        }
        else
        {
            Console.WriteLine("Timed out waiting for work " +
                "method to signal.");
        }
        Console.WriteLine("Main ending.");
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