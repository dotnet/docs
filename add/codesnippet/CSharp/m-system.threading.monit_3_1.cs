      var lockObj = new Object();
      int timeout = 500;
      
      if (Monitor.TryEnter(lockObj, timeout)) {
         try {
            // The critical section.
         }
         finally {
            // Ensure that the lock is released.
            Monitor.Exit(lockObj);
         }
      }
      else {
         // The lock was not acquired.
      }