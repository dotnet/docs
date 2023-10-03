' <Snippet04>
Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Module Example
    Sub Main()
        Dim tokenSource As New CancellationTokenSource()
        Dim token As CancellationToken = tokenSource.Token

        ' Store references to the tasks so that we can wait on them and
        ' observe their status after cancellation.
        Dim t As Task
        Dim tasks As New ConcurrentBag(Of Task)()

        Console.WriteLine("Press any key to begin tasks...")
        Console.ReadKey(True)
        Console.WriteLine("To terminate the example, press 'c' to cancel and exit...")
        Console.WriteLine()

        ' Request cancellation of a single task when the token source is canceled.
        ' Pass the token to the user delegate, and also to the task so it can
        ' handle the exception correctly.
        t = Task.Factory.StartNew(Sub() DoSomeWork(1, token), token)
        Console.WriteLine("Task {0} executing", t.Id)
        tasks.Add(t)

        ' Request cancellation of a task and its children. Note the token is passed
        ' to (1) the user delegate and (2) as the second argument to StartNew, so
        ' that the task instance can correctly handle the OperationCanceledException.
        t = Task.Factory.StartNew(Sub()
                                      ' Create some cancelable child tasks.
                                      Dim tc As Task
                                      For i As Integer = 3 To 10
                                          ' For each child task, pass the same token
                                          ' to each user delegate and to StartNew.
                                          tc = Task.Factory.StartNew(Sub(iteration) DoSomeWork(iteration, token), i, token)
                                          Console.WriteLine("Task {0} executing", tc.Id)
                                          tasks.Add(tc)
                                          ' Pass the same token again to do work on the parent task.
                                          ' All will be signaled by the call to tokenSource.Cancel below.
                                          DoSomeWork(2, token)
                                      Next
                                  End Sub,
                                  token)

        Console.WriteLine("Task {0} executing", t.Id)
        tasks.Add(t)

        ' Request cancellation from the UI thread.
        Dim ch As Char = Console.ReadKey().KeyChar
        If ch = "c"c Or ch = "C"c Then
            tokenSource.Cancel()
            Console.WriteLine(vbCrLf + "Task cancellation requested.")

            ' Optional: Observe the change in the Status property on the task.
            ' It is not necessary to wait on tasks that have canceled. However,
            ' if you do wait, you must enclose the call in a try-catch block to
            ' catch the OperationCanceledExceptions that are thrown. If you do
            ' not wait, no exception is thrown if the token that was passed to the
            ' StartNew method is the same token that requested the cancellation.
        End If

        Try
            Task.WaitAll(tasks.ToArray())
        Catch e As AggregateException
            Console.WriteLine()
            Console.WriteLine("AggregateException thrown with the following inner exceptions:")
            ' Display information about each exception.
            For Each v In e.InnerExceptions
                If TypeOf v Is OperationCanceledException
                    Console.WriteLine("   OperationCanceledException: Task {0}",
                                      DirectCast(v, OperationCanceledException).Task.Id)
                Else
                    Console.WriteLine("   Exception: {0}", v.GetType().Name)
                End If
            Next
            Console.WriteLine()
        Finally
            tokenSource.Dispose()
        End Try

        ' Display status of all tasks.
        For Each t In tasks
            Console.WriteLine("Task {0} status is now {1}", t.Id, t.Status)
        Next
    End Sub

    Sub DoSomeWork(ByVal taskNum As Integer, ByVal ct As CancellationToken)
        ' Was cancellation already requested?
        If ct.IsCancellationRequested = True Then
            Console.WriteLine("Task {0} was cancelled before it got started.",
                              taskNum)
            ct.ThrowIfCancellationRequested()
        End If

        Dim maxIterations As Integer = 100

        ' NOTE!!! A "TaskCanceledException was unhandled
        ' by user code" error will be raised here if "Just My Code"
        ' is enabled on your computer. On Express editions JMC is
        ' enabled and cannot be disabled. The exception is benign.
        ' Just press F5 to continue executing your code.
        For i As Integer = 0 To maxIterations
            ' Do a bit of work. Not too much.
            Dim sw As New SpinWait()
            For j As Integer = 0 To 100
                sw.SpinOnce()
            Next
            If ct.IsCancellationRequested Then
                Console.WriteLine("Task {0} cancelled", taskNum)
                ct.ThrowIfCancellationRequested()
            End If
        Next
    End Sub
End Module
' The example displays output like the following:
'    Press any key to begin tasks...
'    To terminate the example, press 'c' to cancel and exit...
'
'    Task 1 executing
'    Task 2 executing
'    Task 3 executing
'    Task 4 executing
'    Task 5 executing
'    Task 6 executing
'    Task 7 executing
'    Task 8 executing
'    c
'    Task cancellation requested.
'    Task 2 cancelled
'    Task 7 cancelled
'
'    AggregateException thrown with the following inner exceptions:
'       TaskCanceledException: Task 2
'       TaskCanceledException: Task 8
'       TaskCanceledException: Task 7
'
'    Task 2 status is now Canceled
'    Task 1 status is now RanToCompletion
'    Task 8 status is now Canceled
'    Task 7 status is now Canceled
'    Task 6 status is now RanToCompletion
'    Task 5 status is now RanToCompletion
'    Task 4 status is now RanToCompletion
'    Task 3 status is now RanToCompletion
' </Snippet04>
