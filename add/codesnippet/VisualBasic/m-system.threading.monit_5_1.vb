        Dim acquiredLock As Boolean = False

        Try
            Monitor.Enter(lockObject, acquiredLock)

            ' Code that accesses resources that are protected by the lock.

        Finally
            If acquiredLock Then
                Monitor.Exit(lockObject)
            End If
        End Try