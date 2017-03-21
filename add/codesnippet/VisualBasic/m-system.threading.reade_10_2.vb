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