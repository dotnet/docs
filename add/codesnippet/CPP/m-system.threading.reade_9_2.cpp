   // Shows how to request and release the writer lock, and
   // how to handle time-outs.
   static void WriteToResource( int timeOut )
   {
      try
      {
         rwl->AcquireWriterLock( timeOut );
         try
         {
            
            // It is safe for this thread to read or write
            // from the shared resource.
            resource = rnd->Next( 500 );
            Display( String::Format( "writes resource value {0}", resource ) );
            Interlocked::Increment( writes );
         }
         finally
         {
            
            // Ensure that the lock is released.
            rwl->ReleaseWriterLock();
         }

      }
      catch ( ApplicationException^ ) 
      {
         
         // The writer lock request timed out.
         Interlocked::Increment( writerTimeouts );
      }

   }

