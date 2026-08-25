Imports System.Diagnostics

' <SyncExecution>
Public Module SyncExecutionExample
    Public Function ComputeAsync() As Task(Of Integer)
        ' No Await in this method — it runs entirely synchronously.
        Return Task.FromResult(42)
    End Function
End Module
' </SyncExecution>

' <OffloadCorrectly>
Public Module OffloadExample
    Public Function ComputeIntensive() As Integer
        Dim sum As Integer = 0
        For i As Integer = 0 To 999
            sum += i
        Next
        Return sum
    End Function

    Public Function ComputeOnThreadPoolAsync() As Task(Of Integer)
        Return Task.Run(Function() ComputeIntensive())
    End Function
End Module
' </OffloadCorrectly>

' <AsyncVoid>
Public Module AsyncVoidExample
    ' BAD: Async Sub — can't be awaited.
    Public Async Sub DoWorkBadAsync()
        Await Task.Delay(100)
    End Sub

    ' GOOD: Async Function returning Task — callers can await this.
    Public Async Function DoWorkGoodAsync() As Task
        Await Task.Delay(100)
    End Function
End Module
' </AsyncVoid>

' <Deadlock>
Public Module DeadlockExample
    Public Async Function GetDataAsync() As Task(Of String)
        ' Without ConfigureAwait(False), this continuation
        ' posts back to the original SynchronizationContext.
        Await Task.Delay(100)
        Return "data"
    End Function

    Public Sub CallerThatDeadlocks()
        ' On a single-threaded SynchronizationContext (e.g. UI thread),
        ' the following line deadlocks because the continuation needs
        ' the same thread that .Result is blocking.
        Dim result As String = GetDataAsync().Result
    End Sub
End Module
' </Deadlock>

' <DeadlockFix1>
Public Module DeadlockFix1
    Public Async Function CallerFixedAsync() As Task
        ' Use Await instead of .Result
        Dim result As String = Await DeadlockExample.GetDataAsync()
        Console.WriteLine(result)
    End Function
End Module
' </DeadlockFix1>

' <DeadlockFix2>
Public Module DeadlockFix2
    Public Async Function GetDataSafeAsync() As Task(Of String)
        Await Task.Delay(100).ConfigureAwait(False)
        Return "data"
    End Function
End Module
' </DeadlockFix2>

' <TaskTaskBug>
Public Module TaskTaskBugExample
    Public Async Function DemoAsync() As Task
        Dim sw = Stopwatch.StartNew()
        ' StartNew returns Task(Of Task), not Task.
        ' The outer task completes immediately when the lambda yields.
        Await Task.Factory.StartNew(Async Function()
                                        Await Task.Delay(1000)
                                    End Function)
        ' Elapsed shows ~0 seconds, not ~1 second.
        Console.WriteLine($"Elapsed: {sw.Elapsed.TotalSeconds:F2}s")
    End Function
End Module
' </TaskTaskBug>

' <TaskTaskFix1>
Public Module TaskTaskFix1
    Public Async Function DemoAsync() As Task
        Dim sw = Stopwatch.StartNew()
        Await Task.Run(Async Function()
                           Await Task.Delay(1000)
                       End Function)
        Console.WriteLine($"Elapsed: {sw.Elapsed.TotalSeconds:F2}s")
    End Function
End Module
' </TaskTaskFix1>

' <TaskTaskFix2>
Public Module TaskTaskFix2
    Public Async Function DemoAsync() As Task
        Dim sw = Stopwatch.StartNew()
        Await Task.Factory.StartNew(Async Function()
                                        Await Task.Delay(1000)
                                    End Function).Unwrap()
        Console.WriteLine($"Elapsed: {sw.Elapsed.TotalSeconds:F2}s")
    End Function
End Module
' </TaskTaskFix2>

' <TaskTaskFix3>
Public Module TaskTaskFix3
    Public Async Function DemoAsync() As Task
        Dim sw = Stopwatch.StartNew()
        Dim outerTask As Task(Of Task) = Task.Factory.StartNew(Async Function()
                                                                   Await Task.Delay(1000)
                                                               End Function)
        Dim innerTask As Task = Await outerTask
        Await innerTask
        Console.WriteLine($"Elapsed: {sw.Elapsed.TotalSeconds:F2}s")
    End Function
End Module
' </TaskTaskFix3>

' <MissingAwait>
Public Module MissingAwaitExample
    ' BAD: Task.Delay is started but never awaited.
    Public Async Function PauseOneSecondBuggyAsync() As Task
        Task.Delay(1000) ' Warning BC42358
    End Function

    ' GOOD: Await the task.
    Public Async Function PauseOneSecondAsync() As Task
        Await Task.Delay(1000)
    End Function
End Module
' </MissingAwait>

Module Program
    Sub Main()
        Console.WriteLine("--- SyncExecution demo ---")
        Dim result1 As Integer = SyncExecutionExample.ComputeAsync().Result
        Console.WriteLine($"Result: {result1}")

        Console.WriteLine("--- OffloadCorrectly demo ---")
        Dim result2 As Integer = OffloadExample.ComputeOnThreadPoolAsync().Result
        Console.WriteLine($"Result: {result2}")

        Console.WriteLine("--- AsyncVoid demo ---")
        AsyncVoidExample.DoWorkGoodAsync().Wait()
        Console.WriteLine("DoWorkGoodAsync completed.")

        Console.WriteLine("--- DeadlockFix1 demo ---")
        DeadlockFix1.CallerFixedAsync().Wait()

        Console.WriteLine("--- DeadlockFix2 demo ---")
        Dim safe As String = DeadlockFix2.GetDataSafeAsync().Result
        Console.WriteLine($"Safe result: {safe}")

        Console.WriteLine("--- TaskTaskBug demo (outer task only) ---")
        TaskTaskBugExample.DemoAsync().Wait()

        Console.WriteLine("--- TaskTaskFix1 (Task.Run) ---")
        TaskTaskFix1.DemoAsync().Wait()

        Console.WriteLine("--- TaskTaskFix2 (Unwrap) ---")
        TaskTaskFix2.DemoAsync().Wait()

        Console.WriteLine("--- TaskTaskFix3 (double await) ---")
        TaskTaskFix3.DemoAsync().Wait()

        Console.WriteLine("--- MissingAwait demo ---")
        MissingAwaitExample.PauseOneSecondAsync().Wait()
        Console.WriteLine("PauseOneSecondAsync completed.")

        Console.WriteLine("Done.")
    End Sub
End Module
