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