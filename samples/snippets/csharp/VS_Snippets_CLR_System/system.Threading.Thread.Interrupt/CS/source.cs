// <Snippet1>
using System;
using System.Security.Permissions;
using System.Threading;

class ThreadInterrupt
{
    static void Main()
    {
        StayAwake stayAwake = new StayAwake();
        Thread newThread = 
            new Thread(new ThreadStart(stayAwake.ThreadMethod));
        newThread.Start();

        // The following line causes an exception to be thrown 
        // in ThreadMethod if newThread is currently blocked
        // or becomes blocked in the future.
        newThread.Interrupt();
        Console.WriteLine("Main thread calls Interrupt on newThread.");

        // Tell newThread to go to sleep.
        stayAwake.SleepSwitch = true;

        // Wait for newThread to end.
        newThread.Join();
    }
}

class StayAwake
{
    bool sleepSwitch = false;

    public bool SleepSwitch
    {
        set{ sleepSwitch = value; }
    }

    public StayAwake(){}

    public void ThreadMethod()
    {
        Console.WriteLine("newThread is executing ThreadMethod.");
        while(!sleepSwitch)
        {
            // Use SpinWait instead of Sleep to demonstrate the 
            // effect of calling Interrupt on a running thread.
            Thread.SpinWait(10000000);
        }
        try
        {
            Console.WriteLine("newThread going to sleep.");

            // When newThread goes to sleep, it is immediately 
            // woken up by a ThreadInterruptedException.
            Thread.Sleep(Timeout.Infinite);
        }
        catch(ThreadInterruptedException e)
        {
            Console.WriteLine("newThread cannot go to sleep - " +
                "interrupted by main thread.");
        }
    }
}
// </Snippet1>