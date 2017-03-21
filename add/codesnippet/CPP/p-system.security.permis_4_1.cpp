   // Use the enumeration flags to indicate that this method exposes synchronization 
   //  and external threading.

   [HostProtection(Synchronization=true,ExternalThreading=true)]
   static void StartThread()
   {
      Thread^ t = gcnew Thread( gcnew ThreadStart( WatchFileEvents ) );
      
      // Start the new thread.  On a uniprocessor, the thread is not given 
      // any processor time until the main thread yields the processor.  
      t->Start();
      
      // Give the new thread a chance to execute.
      Thread::Sleep( 1000 );
   }