Imports System.Threading

Class Example

    Private Shared lockObject As New Object()

    Shared Sub Main()
        T1()
        T2()
        T3()
    End Sub

    Shared Sub T1()

        '<Snippet2>
        Dim acquiredLock As Boolean = False

        Try
            Monitor.Enter(lockObject, acquiredLock)

            ' Code that accesses resources that are protected by the lock.

        Finally
            If acquiredLock Then
                Monitor.Exit(lockObject)
            End If
        End Try
        '</Snippet2>

    End Sub

    Shared Sub T2()

        '<Snippet3>
        Dim acquiredLock As Boolean = False

        Try
            Monitor.TryEnter(lockObject, acquiredLock)
            If acquiredLock Then

                ' Code that accesses resources that are protected by the lock.

            Else

                ' Code to deal with the fact that the lock was not acquired.

            End If
        Finally
            If acquiredLock Then
                Monitor.Exit(lockObject)
            End If
        End Try
        '</Snippet3>

    End Sub

    Shared Sub T3()

        '<Snippet4>
        Dim acquiredLock As Boolean = False

        Try
            Monitor.TryEnter(lockObject, 500, acquiredLock)
            If acquiredLock Then

                ' Code that accesses resources that are protected by the lock.

            Else

                ' Code to deal with the fact that the lock was not acquired.

            End If
        Finally
            If acquiredLock Then
                Monitor.Exit(lockObject)
            End If
        End Try
        '</Snippet4>

    End Sub
End Class