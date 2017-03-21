      ' Define the lock object.
      Dim obj As New Object()
      
      ' Define the critical section.
      Monitor.Enter(obj)
      Try 
         ' Code to execute one thread at a time.

      ' catch blocks go here.
      Finally 
         Monitor.Exit(obj)
      End Try