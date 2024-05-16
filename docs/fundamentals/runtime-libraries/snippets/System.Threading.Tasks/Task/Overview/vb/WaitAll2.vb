' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Threading
Imports System.Threading.Tasks

Module Example7
    Public Sub Main()
        ' Create a cancellation token and cancel it.
        Dim source1 As New CancellationTokenSource()
        Dim token1 As CancellationToken = source1.Token
        source1.Cancel()
        ' Create a cancellation token for later cancellation.
        Dim source2 As New CancellationTokenSource()
        Dim token2 As CancellationToken = source2.Token

        ' Create a series of tasks that will complete, be cancelled, 
        ' timeout, or throw an exception.
        Dim tasks(11) As Task
        For i As Integer = 0 To 11
            Select Case i Mod 4
             ' Task should run to completion.
                Case 0
                    tasks(i) = Task.Run(Sub() Thread.Sleep(2000))
             ' Task should be set to canceled state.
                Case 1
                    tasks(i) = Task.Run(Sub() Thread.Sleep(2000), token1)
                Case 2
                    ' Task should throw an exception.
                    tasks(i) = Task.Run(Sub()
                                            Throw New NotSupportedException()
                                        End Sub)
                Case 3
                    ' Task should examine cancellation token.
                    tasks(i) = Task.Run(Sub()
                                            Thread.Sleep(2000)
                                            If token2.IsCancellationRequested Then
                                                token2.ThrowIfCancellationRequested()
                                            End If
                                            Thread.Sleep(500)
                                        End Sub, token2)
            End Select
        Next
        Thread.Sleep(250)
        source2.Cancel()

        Try
            Task.WaitAll(tasks)
        Catch ae As AggregateException
            Console.WriteLine("One or more exceptions occurred:")
            For Each ex In ae.InnerExceptions
                Console.WriteLine("   {0}: {1}", ex.GetType().Name, ex.Message)
            Next
        End Try
        Console.WriteLine()

        Console.WriteLine("Status of tasks:")
        For Each t In tasks
            Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status)
            If t.Exception IsNot Nothing Then
                For Each ex In t.Exception.InnerExceptions
                    Console.WriteLine("      {0}: {1}", ex.GetType().Name,
                                 ex.Message)
                Next
            End If
        Next
    End Sub
End Module
' The example displays output like the following:
'   One or more exceptions occurred:
'      TaskCanceledException: A task was canceled.
'      NotSupportedException: Specified method is not supported.
'      TaskCanceledException: A task was canceled.
'      TaskCanceledException: A task was canceled.
'      NotSupportedException: Specified method is not supported.
'      TaskCanceledException: A task was canceled.
'      TaskCanceledException: A task was canceled.
'      NotSupportedException: Specified method is not supported.
'      TaskCanceledException: A task was canceled.
'   
'   Status of tasks:
'      Task #13: RanToCompletion
'      Task #1: Canceled
'      Task #3: Faulted
'         NotSupportedException: Specified method is not supported.
'      Task #8: Canceled
'      Task #14: RanToCompletion
'      Task #4: Canceled
'      Task #6: Faulted
'         NotSupportedException: Specified method is not supported.
'      Task #7: Canceled
'      Task #15: RanToCompletion
'      Task #9: Canceled
'      Task #11: Faulted
'         NotSupportedException: Specified method is not supported.
'      Task #12: Canceled
' </Snippet12>
