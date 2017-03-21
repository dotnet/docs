   // Request and release the writer lock, and handle time-outs.
   static void WriteToResource(int timeOut)
   {
      try {
         rwl.AcquireWriterLock(timeOut);
         try {
            // It's safe for this thread to access from the shared resource.
            resource = rnd.Next(500);
            Display("writes resource value " + resource);
            Interlocked.Increment(ref writes);
         }
         finally {
            // Ensure that the lock is released.
            rwl.ReleaseWriterLock();
         }
      }
      catch (ApplicationException) {
         // The writer lock request timed out.
         Interlocked.Increment(ref writerTimeouts);
      }
   }