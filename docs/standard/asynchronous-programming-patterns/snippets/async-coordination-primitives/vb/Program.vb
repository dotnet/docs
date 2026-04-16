Imports System.Threading

' <AsyncManualResetEvent>
Public Class AsyncManualResetEvent
    Private _tcs As TaskCompletionSource = New TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously)

    Public Function WaitAsync() As Task
        Return _tcs.Task
    End Function

    Public Sub [Set]()
        _tcs.TrySetResult()
    End Sub

    Public Sub Reset()
        Do
            Dim tcs As TaskCompletionSource = _tcs
            If Not tcs.Task.IsCompleted OrElse
               Interlocked.CompareExchange(
                   _tcs,
                   New TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously),
                   tcs) Is tcs Then
                Return
            End If
        Loop
    End Sub
End Class
' </AsyncManualResetEvent>

' <AsyncManualResetEventUsage>
Public Module AsyncManualResetEventDemo
    Public Async Function RunAsync() As Task
        Dim gate As New AsyncManualResetEvent()

        Dim waiter As Task = Task.Run(Async Function()
            Console.WriteLine("Waiter: waiting for signal...")
            Await gate.WaitAsync()
            Console.WriteLine("Waiter: signal received!")
        End Function)

        Await Task.Delay(100)
        Console.WriteLine("Signaler: setting the event.")
        gate.Set()

        Await waiter
    End Function
End Module
' </AsyncManualResetEventUsage>

' <AsyncAutoResetEvent>
Public Class AsyncAutoResetEvent
    Private ReadOnly _waiters As New Queue(Of TaskCompletionSource)()
    Private _signaled As Boolean

    Public Function WaitAsync() As Task
        SyncLock _waiters
            If _signaled Then
                _signaled = False
                Return Task.CompletedTask
            Else
                Dim tcs As New TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously)
                _waiters.Enqueue(tcs)
                Return tcs.Task
            End If
        End SyncLock
    End Function

    Public Sub [Set]()
        Dim toRelease As TaskCompletionSource = Nothing

        SyncLock _waiters
            If _waiters.Count > 0 Then
                toRelease = _waiters.Dequeue()
            ElseIf Not _signaled Then
                _signaled = True
            End If
        End SyncLock

        toRelease?.TrySetResult()
    End Sub
End Class
' </AsyncAutoResetEvent>

' <AsyncAutoResetEventUsage>
Public Module AsyncAutoResetEventDemo
    Public Async Function RunAsync() As Task
        Dim autoEvent As New AsyncAutoResetEvent()

        Dim consumer As Task = Task.Run(Async Function()
            For i As Integer = 0 To 2
                Await autoEvent.WaitAsync()
                Console.WriteLine($"Consumer: received signal {i + 1}")
            Next
        End Function)

        For i As Integer = 0 To 2
            Await Task.Delay(50)
            Console.WriteLine($"Producer: sending signal {i + 1}")
            autoEvent.Set()
        Next

        Await consumer
    End Function
End Module
' </AsyncAutoResetEventUsage>

' <AsyncCountdownEvent>
Public Class AsyncCountdownEvent
    Private ReadOnly _event As New AsyncManualResetEvent()
    Private _count As Integer

    Public Sub New(initialCount As Integer)
        If initialCount <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(initialCount))
        _count = initialCount
    End Sub

    Public Function WaitAsync() As Task
        Return _event.WaitAsync()
    End Function

    Public Sub Signal()
        If _count <= 0 Then
            Throw New InvalidOperationException("The event is already signaled.")
        End If

        Dim newCount As Integer = Interlocked.Decrement(_count)

        If newCount = 0 Then
            _event.Set()
        ElseIf newCount < 0 Then
            Throw New InvalidOperationException("Too many signals.")
        End If
    End Sub

    Public Function SignalAndWait() As Task
        Signal()
        Return WaitAsync()
    End Function
End Class
' </AsyncCountdownEvent>

' <AsyncCountdownEventUsage>
Public Module AsyncCountdownEventDemo
    Public Async Function RunAsync() As Task
        Dim countdown As New AsyncCountdownEvent(3)

        For i As Integer = 1 To 3
            Dim id As Integer = i
            Dim backgroundTask As Task = Task.Run(Async Function()
                Await Task.Delay(id * 30)
                Console.WriteLine($"Worker {id}: done.")
                countdown.Signal()
            End Function)
        Next

        Await countdown.WaitAsync()
        Console.WriteLine("All workers finished.")
    End Function
End Module
' </AsyncCountdownEventUsage>

' <AsyncBarrier>
Public Class AsyncBarrier
    Private ReadOnly _participantCount As Integer
    Private _remainingParticipants As Integer
    Private _tcs As TaskCompletionSource = New TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously)

    Public Sub New(participantCount As Integer)
        If participantCount <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(participantCount))
        _participantCount = participantCount
        _remainingParticipants = participantCount
    End Sub

    Public Function SignalAndWait() As Task
        Dim tcs As TaskCompletionSource = _tcs

        If Interlocked.Decrement(_remainingParticipants) = 0 Then
            _remainingParticipants = _participantCount
            _tcs = New TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously)
            tcs.SetResult()
        End If

        Return tcs.Task
    End Function
End Class
' </AsyncBarrier>

' <AsyncBarrierUsage>
Public Module AsyncBarrierDemo
    Public Async Function RunAsync() As Task
        Dim barrier As New AsyncBarrier(3)
        Dim rounds As Integer = 2

        Dim participants As Task() = Enumerable.Range(1, 3).Select(
            Function(id) Task.Run(Async Function()
                For round As Integer = 1 To rounds
                    Console.WriteLine($"Participant {id}: working on round {round}")
                    Await Task.Delay(id * 20)
                    Console.WriteLine($"Participant {id}: finished round {round}, waiting at barrier")
                    Await barrier.SignalAndWait()
                Next
            End Function)).ToArray()

        Await Task.WhenAll(participants)
        Console.WriteLine("All rounds complete.")
    End Function
End Module
' </AsyncBarrierUsage>

Module Program
    Sub Main()
        Console.WriteLine("--- AsyncManualResetEvent ---")
        AsyncManualResetEventDemo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("--- AsyncAutoResetEvent ---")
        AsyncAutoResetEventDemo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("--- AsyncCountdownEvent ---")
        AsyncCountdownEventDemo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("--- AsyncBarrier ---")
        AsyncBarrierDemo.RunAsync().Wait()
    End Sub
End Module
