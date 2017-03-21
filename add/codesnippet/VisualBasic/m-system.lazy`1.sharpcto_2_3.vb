    Private Shared pleaseThrow As Boolean = True
    Public Sub New()
        If pleaseThrow Then
            pleaseThrow = False
            Throw New ApplicationException("Throw only ONCE.")
        End If

        Console.WriteLine("LargeObject was created on thread id {0}.", _
            Thread.CurrentThread.ManagedThreadId)
    End Sub