   // Request and release a reader lock, and handle time-outs.
   static void ReadFromResource(int timeOut)
   {
      try {
         rwl.AcquireReaderLock(timeOut);
         try {
            // It is safe for this thread to read from the shared resource.
            Display("reads resource value " + resource);
            Interlocked.Increment(ref reads);
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