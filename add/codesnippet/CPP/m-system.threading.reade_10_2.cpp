   // Shows how to request and release a reader lock, and
   // how to handle time-outs.
   static void ReadFromResource( int timeOut )
   {
      try
      {
         rwl->AcquireReaderLock( timeOut );
         try
         {
            
            // It is safe for this thread to read from
            // the shared resource.
            Display( String::Format( "reads resource value {0}", resource ) );
            Interlocked::Increment( reads );
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

