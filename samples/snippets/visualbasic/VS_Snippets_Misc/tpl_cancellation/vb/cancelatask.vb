'<snippet03>
Imports System.Threading.Tasks
Imports System.Threading

Namespace CancellationWithOCE

    Friend Class Program
        Shared Sub Main(ByVal args() As String)
            Console.WriteLine("Press any key to start. Press 'c' to cancel.")
            Console.ReadKey()

            Dim tokenSource = New CancellationTokenSource()
            Dim token = tokenSource.Token

            ' Store references to the tasks so that we can wait on them and
            ' observe their status after cancellation.
            Dim tasks(9) As Task

            ' Request cancellation of a single task when the token source is canceled.
            ' Pass the token to the user delegate, and also to the task so it can 
            ' handle the exception correctly.
            tasks(0) = Task.Factory.StartNew(Sub() DoSomeWork(1, token), token)

            ' Request cancellation of a task and its children. Note the token is passed
            ' to (1) the user delegate and (2) as the second argument to StartNew, so 
            ' that the task instance can correctly handle the OperationCanceledException.
            tasks(1) = Task.Factory.StartNew(Sub()
                                                 ' Create some cancelable child tasks.
                                                 ' For each child task, pass the same token
                                                 ' to each user delegate and to StartNew.
                                                 ' Passing the same token again to do work on the parent task. 
                                                 ' All will be signaled by the call to tokenSource.Cancel below.
                                                 For i As Integer = 2 To 9
                                                     tasks(i) = Task.Factory.StartNew(Sub(iteration) DoSomeWork(CInt(Fix(iteration)), token), i, token)
                                                 Next i
                                                 DoSomeWork(2, token)
                                             End Sub, token)

            ' Give the tasks a second to start.
            Thread.Sleep(1000)

            ' Request cancellation from the UI thread.
            If Console.ReadKey().KeyChar = "c"c Then
                tokenSource.Cancel()
                Console.WriteLine(vbLf & "Task cancellation requested.")

                ' Optional: Observe the change in the Status property on the task.
                ' It is not necessary to wait on tasks that have canceled. However,
                ' if you do wait, you must enclose the call in a try-catch block to
                ' catch the OperationCanceledExceptions that are thrown. If you do 
                ' not wait, no OCE is thrown if the token that was passed to the 
                ' StartNew method is the same token that requested the cancellation.

                '				#Region "Optional_WaitOnTasksToComplete"
                Try
                    Task.WaitAll(tasks)
                Catch e As AggregateException
                    ' For demonstration purposes, show the OCE message.
                    For Each v In e.InnerExceptions
                        Console.WriteLine("msg: " & v.Message)
                    Next v
                End Try

                ' Prove that the tasks are now all in a canceled state.
                For i As Integer = 0 To tasks.Length - 1
                    Console.WriteLine("task[{0}] status is now {1}", i, tasks(i).Status)
                Next i
                '				#End Region
            End If

            ' Keep the console window open while the
            ' task completes its output.
            Console.ReadLine()
            
            tokenSource.Dispose()
        End Sub

        Private Shared Sub DoSomeWork(ByVal taskNum As Integer, ByVal ct As CancellationToken)
            ' Was cancellation already requested?
            If ct.IsCancellationRequested Then
                Console.WriteLine("We were cancelled before we got started.")
                Console.WriteLine("Press Enter to quit.")
                ct.ThrowIfCancellationRequested()
            End If
            Dim maxIterations As Integer = 1000

            ' NOTE!!! A benign "OperationCanceledException was unhandled
            ' by user code" error might be raised here. Press F5 to continue. Or,
            '  to avoid the error, uncheck the "Enable Just My Code"
            ' option under Tools > Options > Debugging.
            For i As Integer = 0 To maxIterations - 1
                ' Do a bit of work. Not too much.
                Dim sw = New SpinWait()
                For j As Integer = 0 To 2999
                    sw.SpinOnce()
                Next j
                Console.WriteLine("...{0} ", taskNum)
                If ct.IsCancellationRequested Then
                    Console.WriteLine("bye from {0}.", taskNum)
                    Console.WriteLine(vbLf & "Press Enter to quit.")

                    ct.ThrowIfCancellationRequested()
                End If
            Next i
        End Sub
    End Class
End Namespace
'</snippet03>
