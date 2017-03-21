      Dim lockObj As New Object()
      Dim timeout As Integer = 500
      
      If Monitor.TryEnter(lockObj, timeout) Then
         Try
            ' The critical section.
         Finally
            ' Ensure that the lock is released.
            Monitor.Exit(lockObj)
         End Try
      Else
         ' The lock was not acquired.
      End If