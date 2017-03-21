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