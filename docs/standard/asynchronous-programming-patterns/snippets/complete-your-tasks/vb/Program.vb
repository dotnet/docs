Imports System.Threading

' <MissingSetExceptionBug>
' ⚠️ DON'T copy this snippet. It demonstrates a problem that causes hangs.
Public NotInheritable Class MissingSetExceptionBug
    Public Function StartAsync(fail As Boolean) As Task(Of String)
        Dim tcs = New TaskCompletionSource(Of String)(TaskCreationOptions.RunContinuationsAsynchronously)

        Try
            If fail Then
                Throw New InvalidOperationException("Simulated failure")
            End If

            tcs.SetResult("success")
        Catch ex As Exception
            ' BUG: forgot SetException or TrySetException.
        End Try

        Return tcs.Task
    End Function
End Class
' </MissingSetExceptionBug>

' <MissingSetExceptionFix>
Public NotInheritable Class MissingSetExceptionFix
    Public Function StartAsync(fail As Boolean) As Task(Of String)
        Dim tcs = New TaskCompletionSource(Of String)(TaskCreationOptions.RunContinuationsAsynchronously)

        Try
            If fail Then
                Throw New InvalidOperationException("Simulated failure")
            End If

            tcs.TrySetResult("success")
        Catch ex As Exception
            tcs.TrySetException(ex)
        End Try

        Return tcs.Task
    End Function
End Class
' </MissingSetExceptionFix>

' <TrySetRace>
Public Module TrySetRaceExample
    Public Sub ShowRaceSafeCompletion()
        Dim tcs = New TaskCompletionSource(Of Integer)(TaskCreationOptions.RunContinuationsAsynchronously)

        Dim first As Boolean = tcs.TrySetResult(42)
        Dim second As Boolean = tcs.TrySetException(New TimeoutException("Too late"))

        Console.WriteLine($"First completion won: {first}")
        Console.WriteLine($"Second completion accepted: {second}")
        Console.WriteLine($"Result: {tcs.Task.Result}")
    End Sub
End Module
' </TrySetRace>

' <ResetBug>
' ⚠️ DON'T copy this snippet. It demonstrates a problem where old waiters never complete.
Public NotInheritable Class ResetBug
    Private _signal As TaskCompletionSource(Of Boolean) = NewSignal()

    Public Function WaitAsync() As Task
        Return _signal.Task
    End Function

    Public Sub Reset()
        ' BUG: waiters on the old task might never complete.
        _signal = NewSignal()
    End Sub

    Public Sub Pulse()
        _signal.TrySetResult(True)
    End Sub

    Private Shared Function NewSignal() As TaskCompletionSource(Of Boolean)
        Return New TaskCompletionSource(Of Boolean)(TaskCreationOptions.RunContinuationsAsynchronously)
    End Function
End Class
' </ResetBug>

' <ResetFix>
Public NotInheritable Class ResetFix
    Private _signal As TaskCompletionSource(Of Boolean) = NewSignal()

    Public Function WaitAsync() As Task
        Return _signal.Task
    End Function

    Public Sub Reset()
        Dim previous As TaskCompletionSource(Of Boolean) = Interlocked.Exchange(_signal, NewSignal())
        previous.TrySetCanceled()
    End Sub

    Public Sub Pulse()
        _signal.TrySetResult(True)
    End Sub

    Private Shared Function NewSignal() As TaskCompletionSource(Of Boolean)
        Return New TaskCompletionSource(Of Boolean)(TaskCreationOptions.RunContinuationsAsynchronously)
    End Function
End Class
' </ResetFix>

Module Program
    Sub Main()
        Console.WriteLine("--- MissingSetExceptionBug ---")
        Dim buggy = New MissingSetExceptionBug()
        Dim buggyTask As Task(Of String) = buggy.StartAsync(True)
        Dim completed As Boolean = buggyTask.Wait(200)
        Console.WriteLine($"Task completed: {completed}")

        Console.WriteLine("--- MissingSetExceptionFix ---")
        Dim fixedVersion = New MissingSetExceptionFix()
        Dim fixedTask As Task(Of String) = fixedVersion.StartAsync(True)
        Try
            fixedTask.GetAwaiter().GetResult()
        Catch ex As Exception
            Console.WriteLine($"Observed failure: {ex.GetType().Name}")
        End Try

        Console.WriteLine("--- TrySetRace ---")
        TrySetRaceExample.ShowRaceSafeCompletion()

        Console.WriteLine("--- ResetBug ---")
        Dim resetBug = New ResetBug()
        Dim oldWaiter As Task = resetBug.WaitAsync()
        resetBug.Reset()
        resetBug.Pulse()
        Console.WriteLine($"Original waiter completed: {oldWaiter.Wait(200)}")

        Console.WriteLine("--- ResetFix ---")
        Dim resetFix = New ResetFix()
        Dim oldWaiterFixed As Task = resetFix.WaitAsync()
        resetFix.Reset()
        resetFix.Pulse()
        Try
            oldWaiterFixed.GetAwaiter().GetResult()
        Catch ex As Exception
            Console.WriteLine($"Original waiter completed with: {ex.GetType().Name}")
        End Try
    End Sub
End Module
