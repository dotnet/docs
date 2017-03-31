// When you run this, Ignore each of the 3 asserts. At the end, go
// check the event log for the 4 entries this generates.
//
using System;
using System.Threading;
using System.Diagnostics;

public class Dummy
{
    public static void Main()
    {
        // Set these really low, so one thread is enough to surpass the
        // threshold.
        const int READ_THRESHOLD = 0;
        const int UPGRADEABLEREAD_THRESHOLD = 0;
        const int WRITE_THRESHOLD = 0;

        // Used for all code examples.
        //<Snippet1>
        using (ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim()) {
           //</Snippet1>
   
           // Used for all code examples that employ EventLog.
           //<Snippet2>
           if (!EventLog.SourceExists("MySource"))
           {
               EventLog.CreateEventSource("MySource", "MyPerformanceLog");
           }
           EventLog performanceLog = new EventLog();
           performanceLog.Source = "MySource";
           //</Snippet2>
   
   
           rwLock.EnterReadLock();
           //<Snippet11>
           int readCt = rwLock.CurrentReadCount;
           if (readCt > READ_THRESHOLD)
           {
               performanceLog.WriteEntry(String.Format(
                   "{0} reader threads; exceeds recommended maximum.", readCt));
           }
           //</Snippet11>
   
           //<Snippet21>
           Debug.Assert(!rwLock.IsReadLockHeld,
               String.Format("Thread {0} already held the read lock when MyFunction began executing.",
                             Thread.CurrentThread.ManagedThreadId));
           //</Snippet21>
           rwLock.ExitReadLock();
   
   
           rwLock.EnterUpgradeableReadLock();
           //<Snippet22>
           Debug.Assert(!rwLock.IsUpgradeableReadLockHeld,
               String.Format("Thread {0} has entered the upgradeable read lock while MyFunction is still executing.",
                             Thread.CurrentThread.ManagedThreadId));
           //</Snippet22>
           rwLock.ExitUpgradeableReadLock();
   
   
           rwLock.EnterWriteLock();
           //<Snippet23>
           Debug.Assert(!rwLock.IsWriteLockHeld, 
               String.Format("Thread {0} is still holding the write lock after MyFunction has finished.", 
                             Thread.CurrentThread.ManagedThreadId));
           //</Snippet23>
           rwLock.ExitWriteLock();
   
   
           rwLock.EnterReadLock();
           // Order of the following three statements is critical! We queue a
           // writer first, so it will block on the reader. Then we queue an
           // upgradeable and another reader, which block because we've already
           // got a writer waiting. THEN we go on to check the number of waiting
           // threads in each category.
           Thread blocked = new Thread(BlockedWrite);
           blocked.Start(rwLock);
           Thread.Sleep(100);
           blocked = new Thread(BlockedUpgradeableRead);
           blocked.Start(rwLock);
           Thread.Sleep(100);
           blocked = new Thread(BlockedRead);
           blocked.Start(rwLock);
           Thread.Sleep(100);
   
           // Check each category against the ridiculously low bar, and write
           // three event log records.
           //
           //<Snippet31>
           int waitingReadCt = rwLock.WaitingReadCount;
           if (waitingReadCt > READ_THRESHOLD)
           {
               performanceLog.WriteEntry(String.Format(
                   "{0} blocked reader threads; exceeds recommended maximum.", 
                   waitingReadCt));
           }
           //</Snippet31>
   
           //<Snippet32>
           int waitingWriteCt = rwLock.WaitingWriteCount;
           if (waitingWriteCt > WRITE_THRESHOLD)
           {
               performanceLog.WriteEntry(String.Format(
                   "{0} blocked writer threads; exceeds recommended maximum.", 
                   waitingWriteCt));
           }
           //</Snippet32>
   
           //<Snippet33>
           int waitingUpgradeableReadCt = rwLock.WaitingUpgradeCount;
           if (waitingUpgradeableReadCt > UPGRADEABLEREAD_THRESHOLD)
           {
               performanceLog.WriteEntry(String.Format(
                   "{0} blocked upgradeable reader threads; exceeds recommended maximum.", 
                   waitingUpgradeableReadCt));
           }
           //</Snippet33>
   
           rwLock.ExitReadLock();
           // When we exit the read lock, the other threads will enter and 
           // and exit like lightning.
           Console.WriteLine("Test is done; check the event log for 4 events.");
           Console.ReadLine();
        }
    }

    private static void BlockedWrite(object state)
    {
        ReaderWriterLockSlim rwl = (ReaderWriterLockSlim)state;
        rwl.EnterWriteLock();
        rwl.ExitWriteLock();
    }

    private static void BlockedRead(object state)
    {
        ReaderWriterLockSlim rwl = (ReaderWriterLockSlim)state;
        rwl.EnterReadLock();
        rwl.ExitReadLock();
    }

    private static void BlockedUpgradeableRead(object state)
    {
        ReaderWriterLockSlim rwl = (ReaderWriterLockSlim)state;
        rwl.EnterUpgradeableReadLock();
        rwl.ExitUpgradeableReadLock();
    }
}



