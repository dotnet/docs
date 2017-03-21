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