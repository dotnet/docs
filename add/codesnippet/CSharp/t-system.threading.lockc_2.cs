   // Requests a reader lock, upgrades the reader lock to the writer
   // lock, and downgrades it to a reader lock again.
   static void UpgradeDowngrade(int timeOut)
   {
      try {
         rwl.AcquireReaderLock(timeOut);
         try {
            // It's safe for this thread to read from the shared resource.
            Display("reads resource value " + resource);
            Interlocked.Increment(ref reads);

            // To write to the resource, either release the reader lock and
            // request the writer lock, or upgrade the reader lock. Upgrading
            // the reader lock puts the thread in the write queue, behind any
            // other threads that might be waiting for the writer lock.
            try {
               LockCookie lc = rwl.UpgradeToWriterLock(timeOut);
               try {
                  // It's safe for this thread to read or write from the shared resource.
                  resource = rnd.Next(500);
                  Display("writes resource value " + resource);
                  Interlocked.Increment(ref writes);
               }
               finally {
                  // Ensure that the lock is released.
                  rwl.DowngradeFromWriterLock(ref lc);
               }
            }
            catch (ApplicationException) {
               // The upgrade request timed out.
               Interlocked.Increment(ref writerTimeouts);
            }

            // If the lock was downgraded, it's still safe to read from the resource.
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