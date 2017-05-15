Imports System.Collections
Imports System.Collections.Generic
'<snippet06>
Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
Module SchedulerDemo
    ' Demonstrated features:
    '   TaskScheduler
    '   BlockingCollection
    '   Parallel.For()
    '   ParallelOptions
    ' Expected results:
    '   An iteration for each argument value (0, 1, 2, 3, 4, 5, 6, 7, 8, 9) is executed.
    '   The TwoThreadTaskScheduler employs 2 threads on which iterations may be executed in a random order.
    '   A task is internally created for each thread of the task scheduler (plus an aditional internal task).
    '	Thus a scheduler thread may execute multiple iterations.
    ' Documentation:
    '   http://msdn.microsoft.com/en-us/library/system.threading.tasks.taskscheduler(VS.100).aspx
    '   http://msdn.microsoft.com/en-us/library/dd997413(VS.100).aspx
    ' More information:
    '   http://blogs.msdn.com/pfxteam/archive/2009/09/22/9898090.aspx
    Sub Main()
        Dim options As New ParallelOptions()

        ' Construct and associate a custom task scheduler
        options.TaskScheduler = New TwoThreadTaskScheduler()

        Try
            Parallel.For(0, 10, options, Sub(i, localState)
                                             Console.WriteLine("i={0}, Task={1}, Thread={2}", i, Task.CurrentId, Thread.CurrentThread.ManagedThreadId)

                                         End Sub)
        Catch e As AggregateException
            ' No exception is expected in this example, but if one is still thrown from a task,
            ' it will be wrapped in AggregateException and propagated to the main thread.
            Console.WriteLine("An iteration has thrown an exception. THIS WAS NOT EXPECTED." & vbLf & "{0}", e)
        End Try
    End Sub

    ' This scheduler schedules all tasks on (at most) two threads
    Private NotInheritable Class TwoThreadTaskScheduler
        Inherits TaskScheduler
        Implements IDisposable
        ' The runtime decides how many tasks to create for the given set of iterations, loop options, and scheduler's max concurrency level.
        ' Tasks will be queued in this collection
        Private _tasks As New BlockingCollection(Of Task)()

        ' Maintain an array of threads. (Feel free to bump up _n.)
        Private ReadOnly _n As Integer = 2
        Private _threads As Thread()

        Public Sub New()
            _threads = New Thread(_n - 1) {}

            ' Create unstarted threads based on the same inline delegate
            For i As Integer = 0 To _n - 1
                _threads(i) = New Thread(Sub()
                                             ' The following loop blocks until items become available in the blocking collection.
                                             ' Then one thread is unblocked to consume that item.
                                             For Each task In _tasks.GetConsumingEnumerable()
                                                 TryExecuteTask(task)
                                             Next
                                         End Sub)

                ' Start each thread
                _threads(i).IsBackground = True
                _threads(i).Start()
            Next
        End Sub

        ' This method is invoked by the runtime to schedule a task
        Protected Overloads Overrides Sub QueueTask(ByVal task As Task)
            _tasks.Add(task)
        End Sub

        ' The runtime will probe if a task can be executed in the current thread.
        ' By returning false, we direct all tasks to be queued up.
        Protected Overloads Overrides Function TryExecuteTaskInline(ByVal task As Task, ByVal taskWasPreviouslyQueued As Boolean) As Boolean
            Return False
        End Function

        Public Overloads Overrides ReadOnly Property MaximumConcurrencyLevel() As Integer
            Get
                Return _n
            End Get
        End Property

        Protected Overloads Overrides Function GetScheduledTasks() As IEnumerable(Of Task)
            Return _tasks.ToArray()
        End Function

        ' Dispose is not thread-safe with other members.
        ' It may only be used when no more tasks will be queued
        ' to the scheduler. This implementation will block
        ' until all previously queued tasks have completed.
        Public Sub Dispose() Implements IDisposable.Dispose
            If _threads IsNot Nothing Then
                _tasks.CompleteAdding()

                For i As Integer = 0 To _n - 1
                    _threads(i).Join()
                    _threads(i) = Nothing
                Next
                _threads = Nothing
                _tasks.Dispose()
                _tasks = Nothing
            End If
        End Sub
    End Class

End Module
'</snippet06>