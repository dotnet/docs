      Dim lockObj As New Object()
      Dim lockTaken As Boolean = False
      
      Try 
         Monitor.TryEnter(lockObj, lockTaken) 
         If lockTaken Then
            ' The critical section.
         Else 
            ' The lock was not acquired.
         End If
      Finally 
         ' Ensure that the lock is released.
         If lockTaken Then Monitor.Exit(lockObj)
      End Try