Option Strict On
Option Explicit On

Class Class14501703298f4d43b139c4b6366af176
    ' SyncLock Statement

    ' <snippet1>
    Class simpleMessageList
        Public messagesList() As String = New String(50) {}
        Public messagesLast As Integer = -1
        Private messagesLock As New Object
        Public Sub addAnotherMessage(ByVal newMessage As String)
            SyncLock messagesLock
                messagesLast += 1
                If messagesLast < messagesList.Length Then
                    messagesList(messagesLast) = newMessage
                End If
            End SyncLock
        End Sub
    End Class
    ' </snippet1>

End Class

Class Class20440b0cfffd4408ab8153ba826e6b26
    ' Advanced Synchronization Techniques

    ' <snippet2>
    Sub ThreadA(ByRef IntA As Integer)
        System.Threading.Interlocked.Increment(IntA)
    End Sub

    Sub ThreadB(ByRef IntA As Integer)
        System.Threading.Interlocked.Increment(IntA)
    End Sub
    ' </snippet2>

End Class

Class Class4b8bb2c88ca4457c9afdd11bc9a05701
    ' Thread Pooling

    ' <snippet3>
    Sub DoWork()
        ' Queue a task
        System.Threading.ThreadPool.QueueUserWorkItem( 
            New System.Threading.WaitCallback(AddressOf SomeLongTask))
        ' Queue another task
        System.Threading.ThreadPool.QueueUserWorkItem( 
            New System.Threading.WaitCallback(AddressOf AnotherLongTask))
    End Sub
    Sub SomeLongTask(ByVal state As Object)
        ' Insert code to perform a long task.
    End Sub
    Sub AnotherLongTask(ByVal state As Object)
        ' Insert code to perform another long task.
    End Sub
    ' </snippet3>

End Class
