Imports System.Collections.Concurrent
Imports System.Threading

Module Program
    Sub Main()
        DefaultBehaviorDemo()
        AsyncPumpDemo()
        Console.WriteLine("All demos complete.")
    End Sub

    ' <DefaultBehavior>
    Sub DefaultBehaviorDemo()
        DemoAsync().GetAwaiter().GetResult()
    End Sub

    Async Function DemoAsync() As Task
        Dim d As New Dictionary(Of Integer, Integer)()
        For i As Integer = 0 To 9999
            Dim id As Integer = Thread.CurrentThread.ManagedThreadId
            Dim count As Integer
            If d.TryGetValue(id, count) Then
                d(id) = count + 1
            Else
                d(id) = 1
            End If

            Await Task.Yield()
        Next

        For Each pair In d
            Console.WriteLine(pair)
        Next
    End Function
    ' </DefaultBehavior>

    ' <AsyncPumpDemo>
    Sub AsyncPumpDemo()
        AsyncPump.Run(
            Async Function() As Task
                Dim d As New Dictionary(Of Integer, Integer)()
                For i As Integer = 0 To 9999
                    Dim id As Integer = Thread.CurrentThread.ManagedThreadId
                    Dim count As Integer
                    If d.TryGetValue(id, count) Then
                        d(id) = count + 1
                    Else
                        d(id) = 1
                    End If

                    Await Task.Yield()
                Next

                For Each pair In d
                    Console.WriteLine(pair)
                Next
            End Function)
    End Sub
    ' </AsyncPumpDemo>
End Module

' <SingleThreadContext>
Class SingleThreadSynchronizationContext
    Inherits SynchronizationContext

    Private ReadOnly _queue As New _
        BlockingCollection(Of KeyValuePair(Of SendOrPostCallback, Object))()

    Public Overrides Sub Post(d As SendOrPostCallback, state As Object)
        _queue.Add(New KeyValuePair(Of SendOrPostCallback, Object)(d, state))
    End Sub

    Public Sub RunOnCurrentThread()
        Dim workItem As New KeyValuePair(Of SendOrPostCallback, Object)(Nothing, Nothing)
        While _queue.TryTake(workItem, Timeout.Infinite)
            workItem.Key.Invoke(workItem.Value)
        End While
    End Sub

    Public Sub Complete()
        _queue.CompleteAdding()
    End Sub
End Class
' </SingleThreadContext>

' <AsyncPumpRun>
Class AsyncPump
    Public Shared Sub Run(func As Func(Of Task))
        Dim prevCtx As SynchronizationContext = SynchronizationContext.Current
        Try
            Dim syncCtx As New SingleThreadSynchronizationContext()
            SynchronizationContext.SetSynchronizationContext(syncCtx)

            Dim t As Task
            Try
                t = func()
            Catch
                syncCtx.Complete()
                Throw
            End Try

            t.ContinueWith(
                Sub(unused) syncCtx.Complete(), TaskScheduler.Default)

            syncCtx.RunOnCurrentThread()

            t.GetAwaiter().GetResult()
        Finally
            SynchronizationContext.SetSynchronizationContext(prevCtx)
        End Try
    End Sub
    ' </AsyncPumpRun>

    ' <AsyncVoidSupport>
    Public Shared Sub Run(asyncMethod As Action)
        Dim prevCtx As SynchronizationContext = SynchronizationContext.Current
        Try
            Dim syncCtx As New AsyncVoidSynchronizationContext()
            SynchronizationContext.SetSynchronizationContext(syncCtx)

            syncCtx.OperationStarted()
            Try
                asyncMethod()
            Catch
                syncCtx.Complete()
                Throw
            Finally
                syncCtx.OperationCompleted()
            End Try

            syncCtx.RunOnCurrentThread()
        Finally
            SynchronizationContext.SetSynchronizationContext(prevCtx)
        End Try
    End Sub
End Class

Class AsyncVoidSynchronizationContext
    Inherits SynchronizationContext

    Private ReadOnly _queue As New _
        BlockingCollection(Of KeyValuePair(Of SendOrPostCallback, Object))()
    Private _operationCount As Integer

    Public Overrides Sub Post(d As SendOrPostCallback, state As Object)
        _queue.Add(New KeyValuePair(Of SendOrPostCallback, Object)(d, state))
    End Sub

    Public Overrides Sub OperationStarted()
        Interlocked.Increment(_operationCount)
    End Sub

    Public Overrides Sub OperationCompleted()
        If Interlocked.Decrement(_operationCount) = 0 Then
            Complete()
        End If
    End Sub

    Public Sub RunOnCurrentThread()
        Dim workItem As New KeyValuePair(Of SendOrPostCallback, Object)(Nothing, Nothing)
        While _queue.TryTake(workItem, Timeout.Infinite)
            workItem.Key.Invoke(workItem.Value)
        End While
    End Sub

    Public Sub Complete()
        _queue.CompleteAdding()
    End Sub
End Class
' </AsyncVoidSupport>
