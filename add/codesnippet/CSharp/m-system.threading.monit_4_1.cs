      var lockObj = new Object();
      var timeout = TimeSpan.FromMilliseconds(500);
      
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