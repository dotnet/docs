//<snippet01>
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


class SpinLockDemo
{


    // Demonstrates:
    //      Default SpinLock construction ()
    //      SpinLock.Enter(ref bool)
    //      SpinLock.Exit()
    static void SpinLockSample1()
    {
        SpinLock sl = new SpinLock();

        StringBuilder sb = new StringBuilder();

        // Action taken by each parallel job.
        // Append to the StringBuilder 10000 times, protecting
        // access to sb with a SpinLock.
        Action action = () =>
        {
            bool gotLock = false;
            for (int i = 0; i < 10000; i++)
            {
                gotLock = false;
                try
                {
                    sl.Enter(ref gotLock);
                    sb.Append((i % 10).ToString());
                }
                finally
                {
                    // Only give up the lock if you actually acquired it
                    if (gotLock) sl.Exit();
                }
            }
        };

        // Invoke 3 concurrent instances of the action above
        Parallel.Invoke(action, action, action);

        // Check/Show the results
        Console.WriteLine("sb.Length = {0} (should be 30000)", sb.Length);
        Console.WriteLine("number of occurrences of '5' in sb: {0} (should be 3000)",
            sb.ToString().Where(c => (c == '5')).Count());
    }

    // Demonstrates:
    //      Default SpinLock constructor (tracking thread owner)
    //      SpinLock.Enter(ref bool)
    //      SpinLock.Exit() throwing exception
    //      SpinLock.IsHeld
    //      SpinLock.IsHeldByCurrentThread
    //      SpinLock.IsThreadOwnerTrackingEnabled
    static void SpinLockSample2()
    {
        // Instantiate a SpinLock
        SpinLock sl = new SpinLock();

        // These MRESs help to sequence the two jobs below
        ManualResetEventSlim mre1 = new ManualResetEventSlim(false);
        ManualResetEventSlim mre2 = new ManualResetEventSlim(false);
        bool lockTaken = false;

        Task taskA = Task.Factory.StartNew(() =>
        {
            try
            {
                sl.Enter(ref lockTaken);
                Console.WriteLine("Task A: entered SpinLock");
                mre1.Set(); // Signal Task B to commence with its logic

                // Wait for Task B to complete its logic
                // (Normally, you would not want to perform such a potentially
                // heavyweight operation while holding a SpinLock, but we do it
                // here to more effectively show off SpinLock properties in
                // taskB.)
                mre2.Wait();
            }
            finally
            {
                if (lockTaken) sl.Exit();
            }
        });

        Task taskB = Task.Factory.StartNew(() =>
        {
            mre1.Wait(); // wait for Task A to signal me
            Console.WriteLine("Task B: sl.IsHeld = {0} (should be true)", sl.IsHeld);
            Console.WriteLine("Task B: sl.IsHeldByCurrentThread = {0} (should be false)", sl.IsHeldByCurrentThread);
            Console.WriteLine("Task B: sl.IsThreadOwnerTrackingEnabled = {0} (should be true)", sl.IsThreadOwnerTrackingEnabled);

            try
            {
                sl.Exit();
                Console.WriteLine("Task B: Released sl, should not have been able to!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Task B: sl.Exit resulted in exception, as expected: {0}", e.Message);
            }

            mre2.Set(); // Signal Task A to exit the SpinLock
        });

        // Wait for task completion and clean up
        Task.WaitAll(taskA, taskB);
        mre1.Dispose();
        mre2.Dispose();
    }

    // Demonstrates:
    //      SpinLock constructor(false) -- thread ownership not tracked
    static void SpinLockSample3()
    {
        // Create SpinLock that does not track ownership/threadIDs
        SpinLock sl = new SpinLock(false);

        // Used to synchronize with the Task below
        ManualResetEventSlim mres = new ManualResetEventSlim(false);

        // We will verify that the Task below runs on a separate thread
        Console.WriteLine("main thread id = {0}", Thread.CurrentThread.ManagedThreadId);

        // Now enter the SpinLock.  Ordinarily, you would not want to spend so
        // much time holding a SpinLock, but we do it here for the purpose of 
        // demonstrating that a non-ownership-tracking SpinLock can be exited 
        // by a different thread than that which was used to enter it.
        bool lockTaken = false;
        sl.Enter(ref lockTaken);

        // Create a separate Task from which to Exit() the SpinLock
        Task worker = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("worker task thread id = {0} (should be different than main thread id)",
                Thread.CurrentThread.ManagedThreadId);

            // Now exit the SpinLock
            try
            {
                sl.Exit();
                Console.WriteLine("worker task: successfully exited SpinLock, as expected");
            }
            catch (Exception e)
            {
                Console.WriteLine("worker task: unexpected failure in exiting SpinLock: {0}", e.Message);
            }

            // Notify main thread to continue
            mres.Set();
        });

        // Do this instead of worker.Wait(), because worker.Wait() could inline the worker Task,
        // causing it to be run on the same thread.  The purpose of this example is to show that
        // a different thread can exit the SpinLock created (without thread tracking) on your thread.
        mres.Wait();

        // now Wait() on worker and clean up
        worker.Wait();
        mres.Dispose();
    }

}
//</snippet01>