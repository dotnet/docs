        Dim acquiredLock As Boolean = False

        Try
            Monitor.TryEnter(lockObject, 500, acquiredLock)
            If acquiredLock Then

                ' Code that accesses resources that are protected by the lock.

            Else

                ' Code to deal with the fact that the lock was not acquired.

            End If
        Finally
            If acquiredLock Then
                Monitor.Exit(lockObject)
            End If
        End Try