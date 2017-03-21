    Private Shared instanceCount As Integer = 0
    Private Shared Function InitLargeObject() As LargeObject
        If 1 = Interlocked.Increment(instanceCount) Then
            Throw New ApplicationException( _
                "Lazy initialization function failed on thread " & _
                Thread.CurrentThread.ManagedThreadId & ".")
        End If
        Return New LargeObject(Thread.CurrentThread.ManagedThreadId)
    End Function