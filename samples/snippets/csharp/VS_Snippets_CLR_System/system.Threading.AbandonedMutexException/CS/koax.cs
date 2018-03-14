//<Snippet1>

using System;
using System.Threading;

public class Example
{
    private static ManualResetEvent _dummy = new ManualResetEvent(false);

    private static Mutex _orphan1 = new Mutex();
    private static Mutex _orphan2 = new Mutex();
    private static Mutex _orphan3 = new Mutex();
    private static Mutex _orphan4 = new Mutex();
    private static Mutex _orphan5 = new Mutex();

    [MTAThread]
    public static void Main()
    {
        // Start a thread that takes all five mutexes, and then
        // ends without releasing them.
        //
        Thread t = new Thread(new ThreadStart(AbandonMutex));
        t.Start();
        // Make sure the thread is finished.
        t.Join();

        // Wait on one of the abandoned mutexes. The WaitOne returns
        // immediately, because its wait condition is satisfied by
        // the abandoned mutex, but on return it throws
        // AbandonedMutexException.
        try
        {
            _orphan1.WaitOne();
            Console.WriteLine("WaitOne succeeded.");
        }
        catch(AbandonedMutexException ex)
        {
            Console.WriteLine("Exception on return from WaitOne." +
                "\r\n\tMessage: {0}", ex.Message);
        }
        finally
        {
            // Whether or not the exception was thrown, the current
            // thread owns the mutex, and must release it.
            //
            _orphan1.ReleaseMutex();
        }

        // Create an array of wait handles, consisting of one
        // ManualResetEvent and two mutexes, using two more of the
        // abandoned mutexes.
        WaitHandle[] waitFor = {_dummy, _orphan2, _orphan3};

        // WaitAny returns when any of the wait handles in the 
        // array is signaled, so either of the two abandoned mutexes
        // satisfy its wait condition. On returning from the wait,
        // WaitAny throws AbandonedMutexException. The MutexIndex
        // property returns the lower of the two index values for 
        // the abandoned mutexes. Note that the Try block and the
        // Catch block obtain the index in different ways.
        //  
        try
        {
            int index = WaitHandle.WaitAny(waitFor);
            Console.WriteLine("WaitAny succeeded.");

            // The current thread owns the mutex, and must release
            // it.
            Mutex m = waitFor[index] as Mutex;
            if (m != null) m.ReleaseMutex();
        }
        catch(AbandonedMutexException ex)
        {
            Console.WriteLine("Exception on return from WaitAny at index {0}." +
                "\r\n\tMessage: {1}", ex.MutexIndex, ex.Message);

            // Whether or not the exception was thrown, the current
            // thread owns the mutex, and must release it.
            //
            if (ex.Mutex != null) ex.Mutex.ReleaseMutex();
        }

        // Use two more of the abandoned mutexes for the WaitAll call.
        // WaitAll doesn't return until all wait handles are signaled,
        // so the ManualResetEvent must be signaled by calling Set().
        _dummy.Set();
        waitFor[1] = _orphan4;
        waitFor[2] = _orphan5;

        // The signaled event and the two abandoned mutexes satisfy
        // the wait condition for WaitAll, but on return it throws
        // AbandonedMutexException. For WaitAll, the MutexIndex
        // property is always -1 and the Mutex property is always
        // null.
        //  
        try
        {
            WaitHandle.WaitAll(waitFor);
            Console.WriteLine("WaitAll succeeded.");
        }
        catch(AbandonedMutexException ex)
        {
            Console.WriteLine("Exception on return from WaitAll. MutexIndex = {0}." +
                "\r\n\tMessage: {1}", ex.MutexIndex, ex.Message);
        }
        finally
        {
            // Whether or not the exception was thrown, the current
            // thread owns the mutexes, and must release them.
            //
            _orphan4.ReleaseMutex();
            _orphan5.ReleaseMutex();
        }
    }

    [MTAThread]
    public static void AbandonMutex()
    {
        _orphan1.WaitOne();
        _orphan2.WaitOne();
        _orphan3.WaitOne();
        _orphan4.WaitOne();
        _orphan5.WaitOne();
        // Abandon the mutexes by exiting without releasing them.
        Console.WriteLine("Thread exits without releasing the mutexes.");
    }
}

/* This code example produces the following output:

Thread exits without releasing the mutexes.
Exception on return from WaitOne.
        Message: The wait completed due to an abandoned mutex.
Exception on return from WaitAny at index 1.
        Message: The wait completed due to an abandoned mutex.
Exception on return from WaitAll. MutexIndex = -1.
        Message: The wait completed due to an abandoned mutex.
 */
//</Snippet1>



