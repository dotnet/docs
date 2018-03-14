// <Snippet1>
using System;
using System.Threading;

class Example
{
    // By default, the lock recursion policy for a new 
    // ReaderWriterLockSlim does not allow recursion.
    private static ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();
    private static ReaderWriterLockSlim rwlsWithRecursion =
        new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

    static void ThreadProc()
    { 
        Console.WriteLine("1. Enter the read lock recursively.");
        ReadRecursive(rwls);
        ReadRecursive(rwlsWithRecursion);

        Console.WriteLine("\n2. Enter the write lock recursively from the read lock.");
        ReadWriteRecursive(rwls);
        ReadWriteRecursive(rwlsWithRecursion);
    } 

    static void ReadRecursive(ReaderWriterLockSlim rwls)
    {
        Console.WriteLine("LockRecursionPolicy.{0}:", rwls.RecursionPolicy);
        rwls.EnterReadLock();

        try {
            rwls.EnterReadLock();
            Console.WriteLine("\nThe read lock was entered recursively.");
            rwls.ExitReadLock();
        }    
        catch (LockRecursionException lre) {
            Console.WriteLine("\n{0}: {1}",
                lre.GetType().Name, lre.Message);
        }

        rwls.ExitReadLock();
    }

    static void ReadWriteRecursive(ReaderWriterLockSlim rwls)
    {
        Console.WriteLine("LockRecursionPolicy.{0}:", rwls.RecursionPolicy);
        rwls.EnterReadLock();

        try {
            rwls.EnterWriteLock();
            Console.WriteLine("\nThe write lock was entered recursively.");
        }
        catch (LockRecursionException lre) {
            Console.WriteLine("\n{0}: {1}", 
                lre.GetType().Name, lre.Message);
        }

        rwls.ExitReadLock();
    }

    static void Main() 
    {
        Thread t = new Thread(ThreadProc);
        t.Start();
        t.Join();
        
        // Dispose of ReaderWriterLockSlim objects' unmanaged resources.
        if (rwls != null) rwls.Dispose();
        if (rwlsWithRecursion != null) rwlsWithRecursion.Dispose();
    } 
} 
// This example displays output similar to the following:
//    1. Enter the read lock recursively.
//    LockRecursionPolicy.NoRecursion:
//    
//    LockRecursionException: Recursive read lock acquisitions not allowed in this mode.
//    LockRecursionPolicy.SupportsRecursion:
//    
//    The read lock was entered recursively.
//    
//    2. Enter the write lock recursively from the read lock.
//    LockRecursionPolicy.NoRecursion:
//    
//    LockRecursionException: Write lock may not be acquired with read lock held. This pattern i
//    s prone to deadlocks. Please ensure that read locks are released before taking a write loc
//    k. If an upgrade is necessary, use an upgrade lock in place of the read lock.
//    LockRecursionPolicy.SupportsRecursion:
//    
//    LockRecursionException: Write lock may not be acquired with read lock held. This pattern i
//    s prone to deadlocks. Please ensure that read locks are released before taking a write loc
//    k. If an upgrade is necessary, use an upgrade lock in place of the read lock.
// </Snippet1>
