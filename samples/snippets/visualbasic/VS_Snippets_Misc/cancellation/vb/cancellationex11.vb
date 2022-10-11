Option Strict On

' How to: Cancel by using a WaitHandle
'<snippet11>
Imports System.Threading
Imports System.Threading.Tasks

Public Structure Rectangle
    Public columns As Integer
    Public rows As Integer
End Structure

Class CancelByPolling
    Shared Sub Main()
        Dim tokenSource As New CancellationTokenSource()
        ' Toy object for demo purposes
        Dim rect As New Rectangle()
        rect.columns = 1000
        rect.rows = 500

        ' Simple cancellation scenario #1. Calling thread does not wait
        ' on the task to complete, and the user delegate simply returns
        ' on cancellation request without throwing.
        Task.Run(Sub() NestedLoops(rect, tokenSource.Token), tokenSource.Token)

        ' Simple cancellation scenario #2. Calling thread does not wait
        ' on the task to complete, and the user delegate throws 
        ' OperationCanceledException to shut down task and transition its state.
        ' Task.Run(Sub() PollByTimeSpan(tokenSource.Token), tokenSource.Token)

        Console.WriteLine("Press 'c' to cancel")
        If Console.ReadKey(True).KeyChar = "c"c Then

            tokenSource.Cancel()
            Console.WriteLine("Press any key to exit.")
        End If

        Console.ReadKey()
        tokenSource.Dispose()
    End Sub

    '<snippet3>
    Shared Sub NestedLoops(ByVal rect As Rectangle, ByVal token As CancellationToken)
        For x As Integer = 0 To rect.columns
            ' Assume that we know that the inner loop is very fast.
            ' Therefore, checking once per row in the outer loop is sufficient.
            For y As Integer = 0 To rect.rows
                ' Simulating work.
                Thread.SpinWait(5000)
                Console.Write("0' end block,1' end block ", x, y)
            Next
        Next

        If token.IsCancellationRequested = True Then
            ' Cleanup or undo here if necessary...
            Console.WriteLine(vbCrLf + "Cancelling after row 0' end block.", x)
            Console.WriteLine("Press any key to exit.")

            ' If using Task:
            ' token.ThrowIfCancellationRequested()
        End If
    End Sub
    '</snippet3>
End Class
'</snippet11>







