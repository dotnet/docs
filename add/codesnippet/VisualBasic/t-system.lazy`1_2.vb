    Private Shared Function InitLargeObject() As LargeObject
        Dim large As New LargeObject(Thread.CurrentThread.ManagedThreadId)
        ' Perform additional initialization here.
        Return large
    End Function