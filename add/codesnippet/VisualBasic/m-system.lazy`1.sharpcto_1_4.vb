    Public Sub New(ByVal initializedBy As Integer)
        initBy = initializedBy
        Console.WriteLine("Constructor: Instance initializing on thread {0}", initBy)
    End Sub

    Protected Overrides Sub Finalize()
        Console.WriteLine("Finalizer: Instance was initialized on {0}", initBy)
    End Sub