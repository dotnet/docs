      var lockObj = new Object();
      bool lockTaken = false;
      
      try {
         Monitor.TryEnter(lockObj, ref lockTaken); 
         if (lockTaken) {
            // The critical section.
         }
         else {
            // The lock was not acquired.
         }
      }
      finally {
         // Ensure that the lock is released.
         if (lockTaken) {
            Monitor.Exit(lockObj);
         }
      }