      var lockObj = new Object();
      
      if (Monitor.TryEnter(lockObj)) {
         try {
            // The critical section.
         }
         finally {
            // Ensure that the lock is released.
            Monitor.Exit(lockObj);
         }
      }
      else {
         // The lock was not axquired.
      }