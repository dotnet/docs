    Private Shared instanceCount As Integer = 0
    Public Sub New()
        If 1 = Interlocked.Increment(instanceCount) Then
            Throw New ApplicationException("Throw only ONCE.")
        End If

        initBy = Thread.CurrentThread.ManagedThreadId
        Console.WriteLine("LargeObject was created on thread id {0}.", initBy)
    End Sub