   // Shows how to release all locks and later restore
   // the lock state. Shows how to use sequence numbers
   // to determine whether another thread has obtained
   // a writer lock since this thread last accessed the
   // resource.
   static void ReleaseRestore( int timeOut )
   {
      int lastWriter;
      try
      {
         rwl->AcquireReaderLock( timeOut );
         try
         {
            
            // It is safe for this thread to read from
            // the shared resource. Cache the value. (You
            // might do this if reading the resource is
            // an expensive operation.)
            int resourceValue = resource;
            Display( String::Format( "reads resource value {0}", resourceValue ) );
            Interlocked::Increment( reads );
            
            // Save the current writer sequence number.
            lastWriter = rwl->WriterSeqNum;
            
            // Release the lock, and save a cookie so the
            // lock can be restored later.
            LockCookie lc = rwl->ReleaseLock();
            
            // Wait for a random interval (up to a 
            // quarter of a second), and then restore
            // the previous state of the lock. Note that
            // there is no timeout on the Restore method.
            Thread::Sleep( rnd->Next( 250 ) );
            rwl->RestoreLock( lc );
            
            // Check whether other threads obtained the
            // writer lock in the interval. If not, then
            // the cached value of the resource is still
            // valid.
            if ( rwl->AnyWritersSince( lastWriter ) )
            {
               resourceValue = resource;
               Interlocked::Increment( reads );
               Display( String::Format( "resource has changed {0}", resourceValue ) );
            }
            else
            {
               Display( String::Format( "resource has not changed {0}", resourceValue ) );
            }
         }
         finally
         {
            
            // Ensure that the lock is released.
            rwl->ReleaseReaderLock();
         }

      }
      catch ( ApplicationException^ ) 
      {
         
         // The reader lock request timed out.
         Interlocked::Increment( readerTimeouts );
      }

   }

