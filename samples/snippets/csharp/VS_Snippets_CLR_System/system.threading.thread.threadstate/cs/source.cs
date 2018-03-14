// <Snippet1>
using System;
using System.Threading;

class Example
{
    static void Main()
    {
        Thread newThread = 
            new Thread(new ThreadStart(ThreadMethod));

        Console.WriteLine("ThreadState: {0}", newThread.ThreadState);
        newThread.Start();

        // Wait for newThread to start and go to sleep.
        Thread.Sleep(300);
        Console.WriteLine("ThreadState: {0}", newThread.ThreadState);
        
        // Wait for newThread to restart.
        Thread.Sleep(1000);
        Console.WriteLine("ThreadState: {0}", newThread.ThreadState);
    }

    static void ThreadMethod()
    {
        Thread.Sleep(1000);
    }
}
// The example displays the following output:
//       ThreadState: Unstarted
//       ThreadState: WaitSleepJoin
//       ThreadState: Stopped
// </Snippet1>