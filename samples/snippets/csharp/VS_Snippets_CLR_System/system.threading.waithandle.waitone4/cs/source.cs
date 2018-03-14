//<snippet1>
using System;
using System.Threading;
using System.Runtime.Remoting.Contexts;

[Synchronization(true)]
public class SyncingClass : ContextBoundObject
{
    private EventWaitHandle waitHandle;

    public SyncingClass()
    {
         waitHandle =
            new EventWaitHandle(false, EventResetMode.ManualReset);
    }

    public void Signal()
    {
        Console.WriteLine("Thread[{0:d4}]: Signalling...", Thread.CurrentThread.GetHashCode());
        waitHandle.Set();
    }

    public void DoWait(bool leaveContext)
    {
        bool signalled;

        waitHandle.Reset();
        Console.WriteLine("Thread[{0:d4}]: Waiting...", Thread.CurrentThread.GetHashCode());
        signalled = waitHandle.WaitOne(3000, leaveContext);
        if (signalled)
        {
            Console.WriteLine("Thread[{0:d4}]: Wait released!!!", Thread.CurrentThread.GetHashCode());
        }
        else
        {
            Console.WriteLine("Thread[{0:d4}]: Wait timeout!!!", Thread.CurrentThread.GetHashCode());
        }
    }
}

public class TestSyncDomainWait
{
    public static void Main()
    {
        SyncingClass syncClass = new SyncingClass();

        Thread runWaiter;

        Console.WriteLine("\nWait and signal INSIDE synchronization domain:\n");
        runWaiter = new Thread(RunWaitKeepContext);
        runWaiter.Start(syncClass);
        Thread.Sleep(1000);
        Console.WriteLine("Thread[{0:d4}]: Signal...", Thread.CurrentThread.GetHashCode());
        // This call to Signal will block until the timeout in DoWait expires.
        syncClass.Signal();
        runWaiter.Join();

        Console.WriteLine("\nWait and signal OUTSIDE synchronization domain:\n");
        runWaiter = new Thread(RunWaitLeaveContext);
        runWaiter.Start(syncClass);
        Thread.Sleep(1000);
        Console.WriteLine("Thread[{0:d4}]: Signal...", Thread.CurrentThread.GetHashCode());
        // This call to Signal is unblocked and will set the wait handle to
        // release the waiting thread.
        syncClass.Signal();
        runWaiter.Join();
    }

    public static void RunWaitKeepContext(object parm)
    {
        ((SyncingClass)parm).DoWait(false);
    }

    public static void RunWaitLeaveContext(object parm)
    {
        ((SyncingClass)parm).DoWait(true);
    }
}

// The output for the example program will be similar to the following:
//
// Wait and signal INSIDE synchronization domain:
//
// Thread[0004]: Waiting...
// Thread[0001]: Signal...
// Thread[0004]: Wait timeout!!!
// Thread[0001]: Signalling...
//
// Wait and signal OUTSIDE synchronization domain:
//
// Thread[0006]: Waiting...
// Thread[0001]: Signal...
// Thread[0001]: Signalling...
// Thread[0006]: Wait released!!!
//</snippet1>
