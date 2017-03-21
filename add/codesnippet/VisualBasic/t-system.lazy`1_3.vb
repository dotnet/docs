        lazyLargeObject = New Lazy(Of LargeObject)(Function () 
            Dim large As New LargeObject(Thread.CurrentThread.ManagedThreadId) 
            ' Perform additional initialization here.
            Return large
        End Function)