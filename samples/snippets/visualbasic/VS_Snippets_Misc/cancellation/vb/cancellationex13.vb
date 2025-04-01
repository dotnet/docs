' Visual Basic .NET Document
Option Strict On

'<snippet13>
Imports System.Threading
Imports System.Threading.Tasks

Class LinkedTokenSourceDemo
    Shared Sub Main13()
        Dim worker As New WorkerWithTimer()
        Dim cts As New CancellationTokenSource()

        ' Task for UI thread, so we can call Task.Wait wait on the main thread.
        Task.Run(Sub()
                     Console.WriteLine("Press 'c' to cancel within 3 seconds after work begins.")
                     Console.WriteLine("Or let the task time out by doing nothing.")
                     If Console.ReadKey(True).KeyChar = "c"c Then
                         cts.Cancel()
                     End If
                 End Sub)
        ' Let the user read the UI message.
        Thread.Sleep(1000)

        ' Start the worker task.
        Dim t As Task = Task.Run(Sub() worker.DoWork(cts.Token), cts.Token)
        Try
            t.Wait()
        Catch ae As AggregateException
            For Each inner In ae.InnerExceptions
                Console.WriteLine(inner.Message)
            Next
        End Try

        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()
        cts.Dispose()
    End Sub
End Class

Class WorkerWithTimer
    Dim internalTokenSource As CancellationTokenSource
    Dim token As CancellationToken
    Dim timer As Timer

    Public Sub New()
        internalTokenSource = New CancellationTokenSource()
        token = internalTokenSource.Token

        ' A toy cancellation trigger that times out after 3 seconds
        ' if the user does not press 'c'.
        timer = New Timer(New TimerCallback(AddressOf CancelAfterTimeout), Nothing, 3000, 3000)
    End Sub

    '<snippet7>
    Public Sub DoWork(ByVal externalToken As CancellationToken)
        ' Create a new token that combines the internal and external tokens.
        Dim internalToken As CancellationToken = internalTokenSource.Token
        Dim linkedCts As CancellationTokenSource =
        CancellationTokenSource.CreateLinkedTokenSource(internalToken, externalToken)
        Using (linkedCts)
            Try
                DoWorkInternal(linkedCts.Token)
            Catch e As OperationCanceledException
                If e.CancellationToken = internalToken Then
                    Console.WriteLine("Operation timed out.")
                ElseIf e.CancellationToken = externalToken Then
                    Console.WriteLine("Canceled by external token.")
                    externalToken.ThrowIfCancellationRequested()
                End If
            End Try
        End Using
    End Sub
    '</snippet7>

    Private Sub DoWorkInternal(ByVal token As CancellationToken)
        For i As Integer = 0 To 1000
            If token.IsCancellationRequested Then
                ' We need to dispose the timer if cancellation
                ' was requested by the external token.
                timer.Dispose()

                ' Output for demonstration purposes.
                Console.WriteLine(vbCrLf + "Cancelling per request.")

                ' Throw the exception.
                token.ThrowIfCancellationRequested()
            End If

            ' Simulating work.
            Thread.SpinWait(7500000)
            Console.Write("working... ")
        Next
    End Sub

    Public Sub CancelAfterTimeout(ByVal state As Object)
        Console.WriteLine(vbCrLf + "Timer fired.")
        internalTokenSource.Cancel()
        timer.Dispose()
    End Sub
End Class
'</snippet13>
