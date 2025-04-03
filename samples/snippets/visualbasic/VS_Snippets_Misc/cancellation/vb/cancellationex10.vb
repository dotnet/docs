' Visual Basic .NET Document
Option Strict On

'<Snippet10>
Imports System.Threading
Imports System.Threading.Tasks

Class CancelNewStyleEvents

    ' New-style MRESlim that supports unified cancellation
    ' in its Wait methods.
    Shared mres As ManualResetEventSlim = New ManualResetEventSlim(False)

    Shared Sub Main10()

        Dim cts As New CancellationTokenSource()

        ' Pass the same token source to the delegate and to the task instance.
        Task.Run(Sub() DoWork(cts.Token), cts.Token)
        Console.WriteLine("Press c to cancel, p to pause, or s to start/restart,")
        Console.WriteLine("or any other key to exit.")

        ' New-style UI thread.
        Dim goAgain As Boolean = True
        While goAgain = True

            Dim ch As Char = Console.ReadKey(True).KeyChar

            Select Case ch
                Case "c"c
                    ' Token can only be canceled once.
                    cts.Cancel()
                Case "p"c
                    mres.Reset()
                Case "s"c
                    mres.Set()
                Case Else
                    goAgain = False
            End Select

            Thread.Sleep(100)
        End While
        cts.Dispose()
    End Sub

    Shared Sub DoWork(ByVal token As CancellationToken)
        While True
            If token.IsCancellationRequested Then
                Console.WriteLine("Canceled while running.")
                token.ThrowIfCancellationRequested()
            End If

            ' Wait on the event to be signaled
            ' or the token to be canceled,
            ' whichever comes first. The token
            ' will throw an exception if it is canceled
            ' while the thread is waiting on the event.
            '<snippet6>
            Try
                ' mres is a ManualResetEventSlim
                mres.Wait(token)
            Catch e As OperationCanceledException
                ' Throw immediately to be responsive. The
                ' alternative is to do one more item of work,
                ' and throw on next iteration, because
                ' IsCancellationRequested will be true.
                Console.WriteLine("Canceled while waiting.")
                Throw
            End Try

            ' Simulating work.
            Console.Write("Working...")
            Thread.SpinWait(500000)
            '</snippet6>
        End While
    End Sub
End Class
'</Snippet10>
