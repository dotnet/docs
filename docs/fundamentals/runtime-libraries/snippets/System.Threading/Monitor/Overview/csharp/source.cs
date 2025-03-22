// <Snippet1>
using System;
using System.Threading;

internal class SyncResource
{
    // Use a monitor to enforce synchronization.
    public void Access()
    {
        lock(this) {
            Console.WriteLine($"Starting synchronized resource access on thread #{Thread.CurrentThread.ManagedThreadId}");
            if (Thread.CurrentThread.ManagedThreadId % 2 == 0)
                Thread.Sleep(2000);

            Thread.Sleep(200);
            Console.WriteLine($"Stopping synchronized resource access on thread #{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}

internal class UnSyncResource
{
    // Do not enforce synchronization.
    public void Access()
    {
        Console.WriteLine($"Starting unsynchronized resource access on Thread #{Thread.CurrentThread.ManagedThreadId}");
        if (Thread.CurrentThread.ManagedThreadId % 2 == 0)
            Thread.Sleep(2000);

        Thread.Sleep(200);
        Console.WriteLine($"Stopping unsynchronized resource access on thread #{Thread.CurrentThread.ManagedThreadId}");
    }
}

public class App
{
    private static int numOps;
    private static AutoResetEvent opsAreDone = new AutoResetEvent(false);
    private static SyncResource SyncRes = new SyncResource();
    private static UnSyncResource UnSyncRes = new UnSyncResource();

   public static void Main()
   {
        // Set the number of synchronized calls.
        numOps = 5;
        for (int ctr = 0; ctr <= 4; ctr++)
            ThreadPool.QueueUserWorkItem(new WaitCallback(SyncUpdateResource));

        // Wait until this WaitHandle is signaled.
        opsAreDone.WaitOne();
        Console.WriteLine("\t\nAll synchronized operations have completed.\n");

        // Reset the count for unsynchronized calls.
        numOps = 5;
        for (int ctr = 0; ctr <= 4; ctr++)
            ThreadPool.QueueUserWorkItem(new WaitCallback(UnSyncUpdateResource));

        // Wait until this WaitHandle is signaled.
        opsAreDone.WaitOne();
        Console.WriteLine("\t\nAll unsynchronized thread operations have completed.\n");
   }

    static void SyncUpdateResource(Object state)
    {
        // Call the internal synchronized method.
        SyncRes.Access();

        // Ensure that only one thread can decrement the counter at a time.
        if (Interlocked.Decrement(ref numOps) == 0)
            // Announce to Main that in fact all thread calls are done.
            opsAreDone.Set();
    }

    static void UnSyncUpdateResource(Object state)
    {
        // Call the unsynchronized method.
        UnSyncRes.Access();

        // Ensure that only one thread can decrement the counter at a time.
        if (Interlocked.Decrement(ref numOps) == 0)
            // Announce to Main that in fact all thread calls are done.
            opsAreDone.Set();
    }
}
// The example displays output like the following:
//    Starting synchronized resource access on thread #6
//    Stopping synchronized resource access on thread #6
//    Starting synchronized resource access on thread #7
//    Stopping synchronized resource access on thread #7
//    Starting synchronized resource access on thread #3
//    Stopping synchronized resource access on thread #3
//    Starting synchronized resource access on thread #4
//    Stopping synchronized resource access on thread #4
//    Starting synchronized resource access on thread #5
//    Stopping synchronized resource access on thread #5
//
//    All synchronized operations have completed.
//
//    Starting unsynchronized resource access on Thread #7
//    Starting unsynchronized resource access on Thread #9
//    Starting unsynchronized resource access on Thread #10
//    Starting unsynchronized resource access on Thread #6
//    Starting unsynchronized resource access on Thread #3
//    Stopping unsynchronized resource access on thread #7
//    Stopping unsynchronized resource access on thread #9
//    Stopping unsynchronized resource access on thread #3
//    Stopping unsynchronized resource access on thread #10
//    Stopping unsynchronized resource access on thread #6
//
//    All unsynchronized thread operations have completed.
// </Snippet1>
