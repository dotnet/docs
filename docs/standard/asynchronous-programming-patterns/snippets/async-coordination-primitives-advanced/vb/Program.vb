Imports System.Collections.Concurrent
Imports System.Threading

' <SemaphoreSlimUsage>
Public Module SemaphoreSlimDemo
    Public Async Function RunAsync() As Task
        Dim semaphore As New SemaphoreSlim(3)

        Dim tasks As Task() = Enumerable.Range(1, 6).Select(
            Function(id) Task.Run(Async Function()
                Await semaphore.WaitAsync()
                Try
                    Console.WriteLine($"Task {id}: entered (count = {semaphore.CurrentCount})")
                    Await Task.Delay(100)
                Finally
                    semaphore.Release()
                    Console.WriteLine($"Task {id}: released")
                End Try
            End Function)).ToArray()

        Await Task.WhenAll(tasks)
    End Function
End Module
' </SemaphoreSlimUsage>

' <AsyncSemaphore>
Public Class AsyncSemaphore
    Private ReadOnly _waiters As New Queue(Of TaskCompletionSource)()
    Private _currentCount As Integer

    Public Sub New(initialCount As Integer)
        If initialCount < 0 Then Throw New ArgumentOutOfRangeException(NameOf(initialCount))
        _currentCount = initialCount
    End Sub

    Public Function WaitAsync() As Task
        SyncLock _waiters
            If _currentCount > 0 Then
                _currentCount -= 1
                Return Task.CompletedTask
            Else
                Dim waiter As New TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously)
                _waiters.Enqueue(waiter)
                Return waiter.Task
            End If
        End SyncLock
    End Function

    Public Sub Release()
        Dim toRelease As TaskCompletionSource = Nothing

        SyncLock _waiters
            If _waiters.Count > 0 Then
                toRelease = _waiters.Dequeue()
            Else
                _currentCount += 1
            End If
        End SyncLock

        toRelease?.TrySetResult()
    End Sub
End Class
' </AsyncSemaphore>

' <SemaphoreSlimAsLock>
Public Module SemaphoreSlimAsLockDemo
    Private ReadOnly s_lock As New SemaphoreSlim(1, 1)
    Private s_sharedCounter As Integer

    Public Async Function RunAsync() As Task
        Dim tasks As Task() = Enumerable.Range(1, 5).Select(
            Function(unused) Task.Run(Async Function()
                Await s_lock.WaitAsync()
                Try
                    Dim before As Integer = s_sharedCounter
                    Await Task.Delay(10)
                    s_sharedCounter = before + 1
                Finally
                    s_lock.Release()
                End Try
            End Function)).ToArray()

        Await Task.WhenAll(tasks)
        Console.WriteLine($"Counter = {s_sharedCounter} (expected 5)")
    End Function
End Module
' </SemaphoreSlimAsLock>

' <AsyncLock>
Public Class AsyncLock
    Private ReadOnly _semaphore As New SemaphoreSlim(1, 1)
    Private ReadOnly _releaser As Task(Of Releaser)

    Public Sub New()
        _releaser = Task.FromResult(New Releaser(Me))
    End Sub

    Public Function LockAsync() As Task(Of Releaser)
        Dim wait As Task = _semaphore.WaitAsync()
        If wait.IsCompleted Then
            Return _releaser
        Else
            Return wait.ContinueWith(
                Function(unused, state) New Releaser(DirectCast(state, AsyncLock)),
                Me,
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default)
        End If
    End Function

    Public Structure Releaser
        Implements IDisposable

        Private ReadOnly _toRelease As AsyncLock

        Friend Sub New(toRelease As AsyncLock)
            _toRelease = toRelease
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            _toRelease?._semaphore.Release()
        End Sub
    End Structure
End Class
' </AsyncLock>

' <AsyncLockUsage>
Public Module AsyncLockDemo
    Private ReadOnly s_lock As New AsyncLock()
    Private s_sharedValue As Integer

    Public Async Function RunAsync() As Task
        Dim tasks As Task() = Enumerable.Range(1, 5).Select(
            Function(id) Task.Run(Async Function()
                Using Await s_lock.LockAsync()
                    Dim before As Integer = s_sharedValue
                    Await Task.Delay(10)
                    s_sharedValue = before + 1
                    Console.WriteLine($"Task {id}: incremented to {s_sharedValue}")
                End Using
            End Function)).ToArray()

        Await Task.WhenAll(tasks)
        Console.WriteLine($"Final value = {s_sharedValue} (expected 5)")
    End Function
End Module
' </AsyncLockUsage>

' <ConcurrentExclusiveUsage>
Public Module ConcurrentExclusiveDemo
    Public Async Function RunAsync() As Task
        Dim pair As New ConcurrentExclusiveSchedulerPair()
        Dim exclusiveFactory As New TaskFactory(pair.ExclusiveScheduler)

        Dim sharedValue As Integer = 0

        Dim writerTask As Task = exclusiveFactory.StartNew(Sub()
            sharedValue = 42
            Console.WriteLine($"Writer: set value to {sharedValue}")
        End Sub)

        Dim readerFactory As New TaskFactory(pair.ConcurrentScheduler)

        Dim readerTasks As Task() = Enumerable.Range(1, 3).Select(
            Function(id) readerFactory.StartNew(Sub()
                Console.WriteLine($"Reader {id}: value = {sharedValue}")
            End Sub)).ToArray()

        Await writerTask
        Await Task.WhenAll(readerTasks)
    End Function
End Module
' </ConcurrentExclusiveUsage>

' <AsyncReaderWriterLock>
Public Class AsyncReaderWriterLock
    Private ReadOnly _waitingWriters As New Queue(Of TaskCompletionSource(Of Releaser))()
    Private _waitingReader As New TaskCompletionSource(Of Releaser)()
    Private _readersWaiting As Integer
    Private _status As Integer ' 0 = free, -1 = writer active, >0 = reader count

    Private ReadOnly _readerReleaser As Task(Of Releaser)
    Private ReadOnly _writerReleaser As Task(Of Releaser)

    Public Sub New()
        _readerReleaser = Task.FromResult(New Releaser(Me, isWriter:=False))
        _writerReleaser = Task.FromResult(New Releaser(Me, isWriter:=True))
    End Sub

    Public Function ReaderLockAsync() As Task(Of Releaser)
        SyncLock _waitingWriters
            If _status >= 0 AndAlso _waitingWriters.Count = 0 Then
                _status += 1
                Return _readerReleaser
            Else
                _readersWaiting += 1
                Return _waitingReader.Task.ContinueWith(Function(t) t.Result)
            End If
        End SyncLock
    End Function

    Public Function WriterLockAsync() As Task(Of Releaser)
        SyncLock _waitingWriters
            If _status = 0 Then
                _status = -1
                Return _writerReleaser
            Else
                Dim waiter As New TaskCompletionSource(Of Releaser)()
                _waitingWriters.Enqueue(waiter)
                Return waiter.Task
            End If
        End SyncLock
    End Function

    Private Sub ReaderRelease()
        Dim toWake As TaskCompletionSource(Of Releaser) = Nothing

        SyncLock _waitingWriters
            _status -= 1
            If _status = 0 AndAlso _waitingWriters.Count > 0 Then
                _status = -1
                toWake = _waitingWriters.Dequeue()
            End If
        End SyncLock

        toWake?.SetResult(New Releaser(Me, isWriter:=True))
    End Sub

    Private Sub WriterRelease()
        Dim toWake As TaskCompletionSource(Of Releaser) = Nothing
        Dim toWakeIsWriter As Boolean = False

        SyncLock _waitingWriters
            If _waitingWriters.Count > 0 Then
                toWake = _waitingWriters.Dequeue()
                toWakeIsWriter = True
            ElseIf _readersWaiting > 0 Then
                toWake = _waitingReader
                _status = _readersWaiting
                _readersWaiting = 0
                _waitingReader = New TaskCompletionSource(Of Releaser)()
            Else
                _status = 0
            End If
        End SyncLock

        toWake?.SetResult(New Releaser(Me, toWakeIsWriter))
    End Sub

    Public Structure Releaser
        Implements IDisposable

        Private ReadOnly _lock As AsyncReaderWriterLock
        Private ReadOnly _isWriter As Boolean

        Friend Sub New(lockObj As AsyncReaderWriterLock, isWriter As Boolean)
            _lock = lockObj
            _isWriter = isWriter
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            If _lock IsNot Nothing Then
                If _isWriter Then
                    _lock.WriterRelease()
                Else
                    _lock.ReaderRelease()
                End If
            End If
        End Sub
    End Structure
End Class
' </AsyncReaderWriterLock>

' <AsyncReaderWriterLockUsage>
Public Module AsyncReaderWriterLockDemo
    Private ReadOnly s_rwLock As New AsyncReaderWriterLock()
    Private s_data As String = "initial"

    Public Async Function RunAsync() As Task
        Dim writer As Task = Task.Run(Async Function()
            Using Await s_rwLock.WriterLockAsync()
                Console.WriteLine("Writer: acquired exclusive lock")
                Await Task.Delay(50)
                s_data = "updated"
                Console.WriteLine("Writer: data updated")
            End Using
        End Function)

        Dim readers As Task() = Enumerable.Range(1, 3).Select(
            Function(id) Task.Run(Async Function()
                Await Task.Delay(10)
                Using Await s_rwLock.ReaderLockAsync()
                    Console.WriteLine($"Reader {id}: data = {s_data}")
                End Using
            End Function)).ToArray()

        Await writer
        Await Task.WhenAll(readers)
    End Function
End Module
' </AsyncReaderWriterLockUsage>

Module Program
    Sub Main()
        Console.WriteLine("--- SemaphoreSlim ---")
        SemaphoreSlimDemo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("--- SemaphoreSlim as lock ---")
        SemaphoreSlimAsLockDemo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("--- AsyncLock ---")
        AsyncLockDemo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("--- ConcurrentExclusiveSchedulerPair ---")
        ConcurrentExclusiveDemo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("--- AsyncReaderWriterLock ---")
        AsyncReaderWriterLockDemo.RunAsync().Wait()
    End Sub
End Module
