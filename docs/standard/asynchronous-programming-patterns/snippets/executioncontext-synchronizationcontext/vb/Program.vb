Imports System.Threading

Module Program
    Sub Main()
        ExecutionContextCaptureExample()

        SyncContextExample.DoWork()

        ' Install a SynchronizationContext to simulate a UI thread environment
        Dim uiContext As New SimpleSynchronizationContext()
        SynchronizationContext.SetSynchronizationContext(uiContext)

        ' Call ProcessOnUIThread with a SynchronizationContext present
        TaskRunExampleClass.ProcessOnUIThread().Wait()

        Thread.Sleep(200)
        Console.WriteLine("Done.")
    End Sub

    ' <ExecutionContextCapture>
    Sub ExecutionContextCaptureExample()
        ' Capture the current ExecutionContext
        Dim ec As ExecutionContext = ExecutionContext.Capture()

        ' Later, run a delegate within that captured context
        If ec IsNot Nothing Then
            ExecutionContext.Run(ec,
                Sub(state)
                    ' Code here sees the ambient state from the point of capture
                    Console.WriteLine("Running inside captured ExecutionContext.")
                End Sub, Nothing)
        End If
    End Sub
    ' </ExecutionContextCapture>
End Module

' <SyncContextUsage>
Class SyncContextExample
    Public Shared Sub DoWork()
        ' Install a custom SynchronizationContext for demonstration
        Dim customContext As New SimpleSynchronizationContext()
        SynchronizationContext.SetSynchronizationContext(customContext)

        ' Capture the current SynchronizationContext
        Dim sc As SynchronizationContext = SynchronizationContext.Current

        ThreadPool.QueueUserWorkItem(
            Sub(state)
                ' ... do work on the ThreadPool ...

                If sc IsNot Nothing Then
                    sc.Post(
                        Sub(s)
                            ' This runs on the original context (e.g. UI thread)
                            Console.WriteLine("Back on the original context.")
                        End Sub, Nothing)
                Else
                    Console.WriteLine("No SynchronizationContext was captured.")
                End If
            End Sub)
    End Sub
End Class

' A minimal SynchronizationContext for demonstration purposes
Class SimpleSynchronizationContext
    Inherits SynchronizationContext

    Public Overrides Sub Post(d As SendOrPostCallback, state As Object)
        ' Queue the callback to run on a thread pool thread
        ThreadPool.QueueUserWorkItem(
            Sub(s)
                d(state)
            End Sub)
    End Sub
End Class
' </SyncContextUsage>

' <TaskRunExample>
Class TaskRunExampleClass
    Public Shared Async Function ProcessOnUIThread() As Task
        ' If a SynchronizationContext is present when this method starts,
        ' the outer await captures it. Task.Run still offloads work to the thread pool.
        Dim result As String = Await Task.Run(
            Async Function()
                Dim data As String = Await DownloadAsync()
                ' Compute runs on the thread pool, not the caller's context,
                ' because SynchronizationContext doesn't flow into Task.Run.
                Return Compute(data)
            End Function)

        ' Resume on the captured context, if one was available.
        Console.WriteLine(result)
    End Function

    Private Shared Async Function DownloadAsync() As Task(Of String)
        Await Task.Delay(100)
        Return "downloaded data"
    End Function

    Private Shared Function Compute(data As String) As String
        Return $"Computed: {data.Length} chars"
    End Function
End Class
' </TaskRunExample>
