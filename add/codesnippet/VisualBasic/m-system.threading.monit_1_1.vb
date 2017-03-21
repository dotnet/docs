      Dim lockObj As New Object()
      Dim timeout As Integer = 500
      Dim lockTaken As Boolean = False
      
      Try
         Monitor.TryEnter(lockObj, timeout, lockTaken)
         If lockTaken Then
            ' The critical section.
         Else
            ' The lock was not acquired.
         End If
      Finally
         ' Ensure that the lock is released.
         If lockTaken Then Monitor.Exit(lockObj)
      End Try