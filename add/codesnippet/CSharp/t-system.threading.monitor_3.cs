      // Define the lock object.
      var obj = new Object();
      
      // Define the critical section.
      Monitor.Enter(obj);
      try {
         // Code to execute one thread at a time.
      }
      // catch blocks go here.
      finally {
         Monitor.Exit(obj);
      }