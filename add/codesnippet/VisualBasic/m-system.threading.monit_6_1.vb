      Dim lockObj As New Object()
      
      If Monitor.TryEnter(lockObj) Then
         Try
            ' The critical section.
         Finally
            ' Ensure that the lock is released.
            Monitor.Exit(lockObj)
         End Try
      Else
         ' The lock was not acquired.
      End If