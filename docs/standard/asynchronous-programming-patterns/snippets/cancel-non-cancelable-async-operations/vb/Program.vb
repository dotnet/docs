Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Threading

' <PreferTokenAwareApis>
Public Module StreamExamples
    Public Async Function ReadOnceAsync(
        stream As NetworkStream,
        buffer As Byte(),
        cancellationToken As CancellationToken) As Task(Of Integer)

        Return Await stream.ReadAsync(
            buffer.AsMemory(0, buffer.Length),
            cancellationToken)
    End Function
End Module
' </PreferTokenAwareApis>

' <WithCancellation>
Public Module TaskCancellationExtensions
    <Extension()>
    Public Async Function WithCancellation(Of T)(
        operationTask As Task(Of T),
        cancellationToken As CancellationToken) As Task(Of T)

        If operationTask.IsCompleted Then
            Return Await operationTask
        End If

        Dim cancellationTaskSource =
            New TaskCompletionSource(Of Boolean)(TaskCreationOptions.RunContinuationsAsynchronously)

        Using registration = cancellationToken.Register(
            Sub(state)
                DirectCast(state, TaskCompletionSource(Of Boolean)).TrySetResult(True)
            End Sub,
            cancellationTaskSource)

            Dim completed = Await Task.WhenAny(operationTask, cancellationTaskSource.Task)

            If completed IsNot operationTask Then
                Throw New OperationCanceledException(cancellationToken)
            End If
        End Using

        Return Await operationTask
    End Function
End Module
' </WithCancellation>

' <CancelBoth>
Public Module CancelBothDemo
    Public Async Function FetchDataAsync(cancellationToken As CancellationToken) As Task(Of String)
        Await Task.Delay(500, cancellationToken)
        Return "payload"
    End Function

    Public Async Function RunAsync() As Task
        Using cts = New CancellationTokenSource()
            cts.CancelAfter(100)

            Try
                Dim payload = Await FetchDataAsync(cts.Token).WithCancellation(cts.Token)
                Console.WriteLine(payload)
            Catch ex As OperationCanceledException
                Console.WriteLine("Canceled operation and wait.")
            End Try
        End Using
    End Function
End Module
' </CancelBoth>

' <ObserveLateFault>
Public Module ObserveLateFaultDemo
    Private Async Function FaultLaterAsync() As Task(Of Integer)
        Await Task.Delay(250)
        Throw New InvalidOperationException("Background operation failed.")
    End Function

    Public Async Function RunAsync() As Task
        Dim operation As Task(Of Integer) = FaultLaterAsync()

        Using cts = New CancellationTokenSource(50)
            Try
                Await operation.WithCancellation(cts.Token)
            Catch ex As OperationCanceledException
                Console.WriteLine("Stopped waiting; operation still running.")
            End Try
        End Using

        Dim observed = operation.ContinueWith(
            Sub(t)
                Console.WriteLine($"Observed late fault: {t.Exception.InnerException.Message}")
            End Sub,
            TaskContinuationOptions.OnlyOnFaulted)

        Await observed
    End Function
End Module
' </ObserveLateFault>

Module Program
    Sub Main()
        Console.WriteLine("=== Cancel both operation and wait ===")
        CancelBothDemo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("=== Cancel wait only and observe late fault ===")
        ObserveLateFaultDemo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("Done.")
    End Sub
End Module
