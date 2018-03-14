'<Snippet1>
'<Snippet2>
' The complete code is located in the ReaderWriterLock class topic.
Imports System.Threading

Public Module Example
   Private rwl As New ReaderWriterLock()
   ' Define the shared resource protected by the ReaderWriterLock.
   Private resource As Integer = 0
   '</Snippet2>

   Const numThreads As Integer = 26
   Private running As Boolean = True
   Private rnd As New Random()
   
   ' Statistics.
   Private readerTimeouts As Integer = 0
   Private writerTimeouts As Integer = 0
   Private reads As Integer = 0
   Private writes As Integer = 0
  
   Public Sub Main()
      ' Start a series of threads to randomly read from and
      ' write to the shared resource.
      Dim t(numThreads - 1) As Thread
      Dim i As Integer
      For i = 0 To numThreads - 1
         t(i) = New Thread(New ThreadStart(AddressOf ThreadProc))
         t(i).Name = Chr(i + 65)
         t(i).Start()
         If i > 10 Then
            Thread.Sleep(300)
         End If
      Next

      ' Tell the threads to shut down and wait until they all finish.
      running = False
      For i = 0 To numThreads - 1
         t(i).Join()
      Next
      
      ' Display statistics.
      Console.WriteLine(vbCrLf & "{0} reads, {1} writes, {2} reader time-outs, {3} writer time-outs.",
                        reads, writes, readerTimeouts, writerTimeouts)
      Console.Write("Press ENTER to exit... ")
      Console.ReadLine()
   End Sub

   Sub ThreadProc()
      ' Randomly select a way for the thread to read and write from the shared
      ' resource.
      While running
         Dim action As Double = rnd.NextDouble()
         If action < 0.8 Then
            ReadFromResource(10)
         ElseIf action < 0.81 Then
            ReleaseRestore(50)
         ElseIf action < 0.9 Then
            UpgradeDowngrade(100)
         Else
            WriteToResource(100)
         End If
      End While
   End Sub
    
   '<Snippet3>
   ' Request and release a reader lock, and handle time-outs.
   Sub ReadFromResource(timeOut As Integer)
      Try
         rwl.AcquireReaderLock(timeOut)
         Try
            ' It's safe for this thread to read from the shared resource.
            Display("reads resource value " & resource)
            Interlocked.Increment(reads)
         Finally
            ' Ensure that the lock is released.
            rwl.ReleaseReaderLock()
         End Try
      Catch ex As ApplicationException
         ' The reader lock request timed out.
         Interlocked.Increment(readerTimeouts)
      End Try
   End Sub
   '</Snippet3>

   '<Snippet4>
   ' Request and release the writer lock, and handle time-outs.
   Sub WriteToResource(timeOut As Integer)
      Try
         rwl.AcquireWriterLock(timeOut)
         Try
            ' It's safe for this thread to read or write from the shared resource.
            resource = rnd.Next(500)
            Display("writes resource value " & resource)
            Interlocked.Increment(writes)
         Finally
            ' Ensure that the lock is released.
            rwl.ReleaseWriterLock()
         End Try
      Catch ex As ApplicationException
         ' The writer lock request timed out.
         Interlocked.Increment(writerTimeouts)
      End Try
   End Sub
   '</Snippet4>

   '<Snippet5>
   ' Requests a reader lock, upgrades the reader lock to the writer
   ' lock, and downgrades it to a reader lock again.
   Sub UpgradeDowngrade(timeOut As Integer)
      Try
         rwl.AcquireReaderLock(timeOut)
         Try
            ' It's safe for this thread to read from the shared resource.
            Display("reads resource value " & resource)
            Interlocked.Increment(reads)
            
            ' To write to the resource, either release the reader lock and
            ' request the writer lock, or upgrade the reader lock. Upgrading
            ' the reader lock puts the thread in the write queue, behind any
            ' other threads that might be waiting for the writer lock.
            Try
               Dim lc As LockCookie = rwl.UpgradeToWriterLock(timeOut)
               Try
                  ' It's safe for this thread to read or write from the shared resource.
                  resource = rnd.Next(500)
                  Display("writes resource value " & resource)
                  Interlocked.Increment(writes)
               Finally
                  ' Ensure that the lock is released.
                  rwl.DowngradeFromWriterLock(lc)
               End Try
            Catch ex As ApplicationException
               ' The upgrade request timed out.
               Interlocked.Increment(writerTimeouts)
            End Try
            
            ' If the lock was downgraded, it's still safe to read from the resource.
            Display("reads resource value " & resource)
            Interlocked.Increment(reads)
         Finally
            ' Ensure that the lock is released.
            rwl.ReleaseReaderLock()
         End Try
      Catch ex As ApplicationException
         ' The reader lock request timed out.
         Interlocked.Increment(readerTimeouts)
      End Try
   End Sub
   '</Snippet5>

   '<Snippet6>
   ' Release all locks and later restores the lock state.
   ' Uses sequence numbers to determine whether another thread has
   ' obtained a writer lock since this thread last accessed the resource.
   Sub ReleaseRestore(timeOut As Integer)
      Dim lastWriter As Integer
      
      Try
         rwl.AcquireReaderLock(timeOut)
         Try
            ' It's safe for this thread to read from the shared resource,
            ' so read and cache the resource value.
            Dim resourceValue As Integer = resource
            Display("reads resource value " & resourceValue)
            Interlocked.Increment(reads)
            
            ' Save the current writer sequence number.
            lastWriter = rwl.WriterSeqNum
            
            ' Release the lock and save a cookie so the lock can be restored later.
            Dim lc As LockCookie = rwl.ReleaseLock()
            
            ' Wait for a random interval and then restore the previous state of the lock.
            Thread.Sleep(rnd.Next(250))
            rwl.RestoreLock(lc)
           
            ' Check whether other threads obtained the writer lock in the interval.
            ' If not, then the cached value of the resource is still valid.
            If rwl.AnyWritersSince(lastWriter) Then
               resourceValue = resource
               Interlocked.Increment(reads)
               Display("resource has changed " & resourceValue)
            Else
               Display("resource has not changed " & resourceValue)
            End If
         Finally
            ' Ensure that the lock is released.
            rwl.ReleaseReaderLock()
         End Try
      Catch ex As ApplicationException
         ' The reader lock request timed out.
         Interlocked.Increment(readerTimeouts)
      End Try
   End Sub
   '</Snippet6>

   ' Helper method briefly displays the most recent thread action.
   Sub Display(msg As String)
      Console.Write("Thread {0} {1}.       " & vbCr, Thread.CurrentThread.Name, msg)
   End Sub
'<Snippet7>
End Module
'</Snippet7>
'</Snippet1>