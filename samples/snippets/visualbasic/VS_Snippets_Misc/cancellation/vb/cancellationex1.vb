' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading

Module Example1
    Public Sub Main1()
        ' Create the token source.
        Dim cts As New CancellationTokenSource()

        ' Pass the token to the cancelable operation.
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf DoSomeWork), cts.Token)
        Thread.Sleep(2500)

        ' Request cancellation by setting a flag on the token.
        cts.Cancel()
        Console.WriteLine("Cancellation set in token source...")
        Thread.Sleep(2500)
        ' Cancellation should have happened, so call Dispose.
        cts.Dispose()
    End Sub

    ' Thread 2: The listener
    Sub DoSomeWork(ByVal obj As Object)
        Dim token As CancellationToken = CType(obj, CancellationToken)

        For i As Integer = 0 To 1000000
            If token.IsCancellationRequested Then
                Console.WriteLine("In iteration {0}, cancellation has been requested...",
                                  i + 1)
                ' Perform cleanup if necessary.
                '...
                ' Terminate the operation.
                Exit For
            End If

            ' Simulate some work.
            Thread.SpinWait(500000)
        Next
    End Sub
End Module
' The example displays output like the following:
'       Cancellation set in token source...
'       In iteration 1430, cancellation has been requested...
' </Snippet1>

