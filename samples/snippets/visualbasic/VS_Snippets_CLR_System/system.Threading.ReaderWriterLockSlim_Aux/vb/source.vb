' When you run this, Ignore each of the 3 asserts. At the end, go
' check the event log for the 4 entries this generates.
'
Imports System
Imports System.Threading
Imports System.Diagnostics

Public Class Dummy
    Shared Sub Main()
        ' Set these really low, so one thread is enough to surpass the
        ' threshold.
        Const READ_THRESHOLD As Integer = 0
        Const UPGRADEABLEREAD_THRESHOLD As Integer = 0
        Const WRITE_THRESHOLD As Integer = 0

        ' Used for all code examples.
        '<Snippet1>
        Using rwLock As New ReaderWriterLockSlim()
        '</Snippet1>

           ' Used for all code examples that employ EventLog.
           '<Snippet2>
           If Not EventLog.SourceExists("MySource") Then
               EventLog.CreateEventSource("MySource", "MyPerformanceLog")
           End If
           Dim performanceLog As New EventLog()
           performanceLog.Source = "MySource"
           '</Snippet2>
   
   
           rwLock.EnterReadLock()
           '<Snippet11>
           Dim readCt As Integer = rwLock.CurrentReadCount
           If readCt > READ_THRESHOLD Then
               performanceLog.WriteEntry(String.Format( _
                   "{0} reader threads; exceeds recommended maximum.", readCt))
           End If
           '</Snippet11>
   
           '<Snippet21>
           Debug.Assert(Not rwLock.IsReadLockHeld, _
               String.Format("Thread {0} already held the read lock when MyFunction began executing.", _
                             Thread.CurrentThread.ManagedThreadId))
           '</Snippet21>
           rwLock.ExitReadLock()
   
   
           rwLock.EnterUpgradeableReadLock()
           '<Snippet22>
           Debug.Assert(Not rwLock.IsUpgradeableReadLockHeld, _
               String.Format("Thread {0} has entered the upgradeable read lock while MyFunction is still executing.", _
                             Thread.CurrentThread.ManagedThreadId))
           '</Snippet22>
           rwLock.ExitUpgradeableReadLock()
   
   
           rwLock.EnterWriteLock()
           '<Snippet23>
           Debug.Assert(Not rwLock.IsWriteLockHeld, _
               String.Format("Thread {0} is still holding the write lock after MyFunction has finished.", _
                             Thread.CurrentThread.ManagedThreadId))
           '</Snippet23>
           rwLock.ExitWriteLock()
   
   
           rwLock.EnterReadLock()
           ' Order of the following three statements is critical! We queue a
           ' writer first, so it will block on the reader. Then we queue an
           ' upgradeable and another reader, which block because we've already
           ' got a writer waiting. THEN we go on to check the number of waiting
           ' threads in each category.
           Dim blocked As New Thread(AddressOf BlockedWrite)
           blocked.Start(rwLock)
           Thread.Sleep(100)
           blocked = New Thread(AddressOf BlockedUpgradeableRead)
           blocked.Start(rwLock)
           Thread.Sleep(100)
           blocked = New Thread(AddressOf BlockedRead)
           blocked.Start(rwLock)
           Thread.Sleep(100)
   
           ' Check each category against the ridiculously low bar, and write
           ' three event log records.
           '
           '<Snippet31>
           Dim waitingReadCt As Integer = rwLock.WaitingReadCount
           If waitingReadCt > READ_THRESHOLD Then
               performanceLog.WriteEntry(String.Format( _
                   "{0} blocked reader threads; exceeds recommended maximum.", _
                   waitingReadCt))
           End If
           '</Snippet31>
   
           '<Snippet32>
           Dim waitingWriteCt As Integer = rwLock.WaitingWriteCount
           If waitingWriteCt > WRITE_THRESHOLD Then
               performanceLog.WriteEntry(String.Format( _
                   "{0} blocked writer threads; exceeds recommended maximum.", _
                   waitingWriteCt))
           End If
           '</Snippet32>
   
           '<Snippet33>
           Dim waitingUpgradeableReadCt As Integer = rwLock.WaitingUpgradeCount
           If waitingUpgradeableReadCt > UPGRADEABLEREAD_THRESHOLD Then
               performanceLog.WriteEntry(String.Format( _
                   "{0} blocked upgradeable reader threads; exceeds recommended maximum.", _
                   waitingUpgradeableReadCt))
           End If
           '</Snippet33>
   
           rwLock.ExitReadLock()
           ' When we exit the read lock, the other threads will enter and 
           ' and exit like lightning.
           Console.WriteLine("Test is done; check the event log for 4 events.")
           Console.ReadLine()
        End Using
    End Sub

    Private Shared Sub BlockedWrite(ByVal state As Object)
        Dim rwl As ReaderWriterLockSlim = CType(state, ReaderWriterLockSlim)
        rwl.EnterWriteLock()
        rwl.ExitWriteLock()
    End Sub

    Private Shared Sub BlockedRead(ByVal state As Object)
        Dim rwl As ReaderWriterLockSlim = CType(state, ReaderWriterLockSlim)
        rwl.EnterReadLock()
        rwl.ExitReadLock()
    End Sub

    Private Shared Sub BlockedUpgradeableRead(ByVal state As Object)
        Dim rwl As ReaderWriterLockSlim = CType(state, ReaderWriterLockSlim)
        rwl.EnterUpgradeableReadLock()
        rwl.ExitUpgradeableReadLock()
    End Sub
End Class
