   // Release all locks and later restores the lock state.
   // Uses sequence numbers to determine whether another thread has
   // obtained a writer lock since this thread last accessed the resource.
   static void ReleaseRestore(int timeOut)
   {
      int lastWriter;

      try {
         rwl.AcquireReaderLock(timeOut);
         try {
            // It's safe for this thread to read from the shared resource,
            // so read and cache the resource value.
            int resourceValue = resource;     // Cache the resource value.
            Display("reads resource value " + resourceValue);
            Interlocked.Increment(ref reads);

            // Save the current writer sequence number.
            lastWriter = rwl.WriterSeqNum;

            // Release the lock and save a cookie so the lock can be restored later.
            LockCookie lc = rwl.ReleaseLock();

            // Wait for a random interval and then restore the previous state of the lock.
            Thread.Sleep(rnd.Next(250));
            rwl.RestoreLock(ref lc);

            // Check whether other threads obtained the writer lock in the interval.
            // If not, then the cached value of the resource is still valid.
            if (rwl.AnyWritersSince(lastWriter)) {
               resourceValue = resource;
               Interlocked.Increment(ref reads);
               Display("resource has changed " + resourceValue);
            }
            else {
               Display("resource has not changed " + resourceValue);
            }
         }
         finally {
            // Ensure that the lock is released.
            rwl.ReleaseReaderLock();
         }
      }
      catch (ApplicationException) {
         // The reader lock request timed out.
         Interlocked.Increment(ref readerTimeouts);
      }
   }