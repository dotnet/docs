    Public Sub New()
        initBy = Thread.CurrentThread.ManagedThreadId
        Console.WriteLine("Constructor: Instance initializing on thread {0}", initBy)
    End Sub

    Protected Overrides Sub Finalize()
        Console.WriteLine("Finalizer: Instance was initialized on {0}", initBy)
    End Sub