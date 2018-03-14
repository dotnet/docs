//<snippet01>
using System;
using System.Threading;
using System.Threading.Tasks;

class SemaphoreSlimDemo
{
    // Demonstrates:
    //      SemaphoreSlim construction
    //      SemaphoreSlim.Wait()
    //      SemaphoreSlim.Release()
    //      SemaphoreSlim.AvailableWaitHandle
    static void Main()
    { 
    
        SemaphoreSlim ss = new SemaphoreSlim(2); // set initial count to 2
        Console.WriteLine("Constructed a SemaphoreSlim with an initial count of 2");

        Console.WriteLine("First non-blocking Wait: {0} (should be true)", ss.Wait(0));
        Console.WriteLine("Second non-blocking Wait: {0} (should be true)", ss.Wait(0));
        Console.WriteLine("Third non-blocking Wait: {0} (should be false)", ss.Wait(0));

        // Do a Release to free up a spot
        ss.Release();

        Console.WriteLine("Non-blocking Wait after Release: {0} (should be true)", ss.Wait(0));

        // Launch an asynchronous Task that releases the semaphore after 100 ms
        Task t1 = Task.Factory.StartNew(() =>
        {
            Thread.Sleep(100);
            Console.WriteLine("Task about to release SemaphoreSlim");
            ss.Release();
        });

        // You can also wait on the SemaphoreSlim via the underlying Semaphore WaitHandle.
        // HOWEVER, unlike SemaphoreSlim.Wait(), it WILL NOT decrement the count.
        // In the printout below, you will see that CurrentCount is still 1
        ss.AvailableWaitHandle.WaitOne();
        Console.WriteLine("ss.AvailableWaitHandle.WaitOne() returned, ss.CurrentCount = {0}", ss.CurrentCount);

        // Now a real Wait(), which should return immediately and decrement the count.
        ss.Wait();
        Console.WriteLine("ss.CurrentCount after ss.Wait() = {0}", ss.CurrentCount);

        // Clean up
        t1.Wait();
        ss.Dispose();
    }
}
//</snippet01>