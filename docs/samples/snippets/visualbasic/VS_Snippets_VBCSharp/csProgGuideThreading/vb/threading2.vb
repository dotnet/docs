' Thread Synchronization
' 413e1f28a2c54eec8338aa43e7982ff4

'<Snippet13>
Public Class TestThreading
    Dim lockThis As New Object

    Public Sub Process()
        SyncLock lockThis
            ' Access thread-sensitive resources.
        End SyncLock
    End Sub
End Class
'</Snippet13>

Public Class TestThreading2
    Public Sub DoSomething()

    End Sub

    Public Sub TestMonitors()
        Dim x As New Object

        '<Snippet14>
        SyncLock x
            DoSomething()
        End SyncLock
        '</Snippet14>

        '<Snippet15>
        Dim obj As Object = CType(x, Object)
        System.Threading.Monitor.Enter(obj)
        Try
            DoSomething()
        Finally
            System.Threading.Monitor.Exit(obj)
        End Try
        '</Snippet15>
    End Sub

End Class
