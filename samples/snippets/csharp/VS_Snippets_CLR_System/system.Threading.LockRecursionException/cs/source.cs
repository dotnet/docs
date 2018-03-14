//<Snippet1>
using System;
using System.Threading;

class Example
{
    // By default, the lock recursion policy for a new 
    // ReaderWriterLockSlim does not allow recursion.
    static ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();

    static void ThreadProc()
    {
        Console.WriteLine("Acquire the reader lock.");
        rwls.EnterReadLock();

        try
        {
            Console.WriteLine("\nAttempt to acquire the reader lock recursively:");
            rwls.EnterReadLock();
        }
        catch (LockRecursionException lre)
        {
            Console.WriteLine("{0}: {1}", 
                lre.GetType().Name, lre.Message);
        }

        try
        {
            Console.WriteLine("\nAttempt to acquire the writer lock recursively:");
            rwls.EnterWriteLock();
        }
        catch (LockRecursionException lre)
        {
            Console.WriteLine("{0}: {1}", 
                lre.GetType().Name, lre.Message);
        }
    }

    static void Main()
    {
        Thread t = new Thread(ThreadProc);
        t.Start();
        t.Join();
    }
}

/* This code example produces output similar to the following:

Acquire the reader lock.

Attempt to acquire the reader lock recursively:
LockRecursionException: Recursive read lock acquisitions not allowed in this mode.

Attempt to acquire the writer lock recursively:
LockRecursionException: Write lock may not be acquired with read lock held. This pattern is prone to deadlocks. Consider using the upgrade lock.
 */
//</Snippet1>
