   // Shows how to request a reader lock, upgrade the
   // reader lock to the writer lock, and downgrade to a
   // reader lock again.
   static void UpgradeDowngrade( int timeOut )
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
            
            // If it is necessary to write to the resource,
            // you must either release the reader lock and 
            // then request the writer lock, or upgrade the
            // reader lock. Note that upgrading the reader lock
            // puts the thread in the write queue, behind any
            // other threads that might be waiting for the 
            // writer lock.
            try
            {
               LockCookie lc = rwl->UpgradeToWriterLock( timeOut );
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
                  rwl->DowngradeFromWriterLock( lc );
               }

            }
            catch ( ApplicationException^ ) 
            {
               
               // The upgrade request timed out.
               Interlocked::Increment( writerTimeouts );
            }

            
            // When the lock has been downgraded, it is 
            // still safe to read from the resource.
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

