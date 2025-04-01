' Visual Basic .NET Document
Option Strict On

'<snippet9>
Imports System.Threading
Imports System.Threading.Tasks

Class CancelOldStyleEvents
    ' Old-style MRE that doesn't support unified cancellation.
    Shared mre As New ManualResetEvent(False)

    Shared Sub Main9()
        Dim cts As New CancellationTokenSource()

        ' Pass the same token source to the delegate and to the task instance.
        Task.Run(Sub() DoWork(cts.Token), cts.Token)
        Console.WriteLine("Press c to cancel, p to pause, or s to start/restart.")
        Console.WriteLine("Or any other key to exit.")

        ' Old-style UI thread.
        Dim goAgain As Boolean = True
        While goAgain
            Dim ch As Char = Console.ReadKey(True).KeyChar
            Select Case ch
                Case "c"c
                    cts.Cancel()
                Case "p"c
                    mre.Reset()
                Case "s"c
                    mre.Set()
                Case Else
                    goAgain = False
            End Select

            Thread.Sleep(100)
        End While
        cts.Dispose()
    End Sub

    Shared Sub DoWork(ByVal token As CancellationToken)
        While True
            '<snippet5>
            ' Wait on the event if it is not signaled.
            Dim waitHandles() As WaitHandle = {mre, token.WaitHandle}
            Dim eventThatSignaledIndex =
                WaitHandle.WaitAny(waitHandles, _
                                   New TimeSpan(0, 0, 20))
            '</snippet5>

            ' Were we canceled while waiting?
            ' The first If statement is equivalent to
            ' token.ThrowIfCancellationRequested()
            If eventThatSignaledIndex = 1 Then
                Console.WriteLine("The wait operation was canceled.")
                Throw New OperationCanceledException(token)
                ' Were we canceled while running?
            ElseIf token.IsCancellationRequested = True Then
                Console.WriteLine("Cancelling per user request.")
                token.ThrowIfCancellationRequested()
                ' Did we time out?
            ElseIf eventThatSignaledIndex = WaitHandle.WaitTimeout Then
                Console.WriteLine("The wait operation timed out.")
                Exit While
            Else
                ' Simulating work.
                Console.Write("Working... ")
                Thread.SpinWait(5000000)
            End If
        End While
    End Sub
End Class
'</snippet9>
