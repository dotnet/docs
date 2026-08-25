Imports System.Diagnostics
Imports System.Threading

' <ActionPitfall>
Public Module TimingHelper
    Public Function Time(action As Action, Optional iterations As Integer = 10) As Double
        Dim sw = Stopwatch.StartNew()
        For i As Integer = 0 To iterations - 1
            action()
        Next
        Return sw.Elapsed.TotalSeconds / iterations
    End Function
End Module

Public Module ActionPitfallDemo
    Public Sub Run()
        ' Synchronous lambda — timing is accurate.
        Dim syncSeconds As Double = TimingHelper.Time(
            Sub() Thread.Sleep(100), iterations:=3)
        Console.WriteLine($"Sync: {syncSeconds:F4}s per iteration")

        ' Async lambda — becomes Async Sub, returns immediately.
        Dim asyncSeconds As Double = TimingHelper.Time(
            Async Sub() Await Task.Delay(100), iterations:=3)
        Console.WriteLine($"Async (buggy): {asyncSeconds:F4}s per iteration")
    End Sub
End Module
' </ActionPitfall>

' <ActionFix>
Public Module TimingHelperFixed
    Public Function Time(action As Action, Optional iterations As Integer = 10) As Double
        Dim sw = Stopwatch.StartNew()
        For i As Integer = 0 To iterations - 1
            action()
        Next
        Return sw.Elapsed.TotalSeconds / iterations
    End Function

    Public Async Function Time(func As Func(Of Task), Optional iterations As Integer = 10) As Task(Of Double)
        Dim sw = Stopwatch.StartNew()
        For i As Integer = 0 To iterations - 1
            Await func()
        Next
        Return sw.Elapsed.TotalSeconds / iterations
    End Function
End Module

Public Module ActionFixDemo
    Public Async Function Run() As Task
        ' Now the async lambda maps to Func(Of Task), and
        ' the timer waits for each iteration to complete.
        Dim seconds As Double = Await TimingHelperFixed.Time(
            Async Function()
                Await Task.Delay(100)
            End Function, iterations:=3)
        Console.WriteLine($"Async (fixed): {seconds:F4}s per iteration")
    End Function
End Module
' </ActionFix>

' <ParallelForEachBug>
Public Module ParallelForEachBugDemo
    Public Sub Run()
        Dim sw = Stopwatch.StartNew()
        Parallel.ForEach(Enumerable.Range(0, 10),
            Async Sub(i As Integer)
                Await Task.Delay(200)
            End Sub)
        ' Completes almost immediately — the async lambdas are fire-and-forget.
        Console.WriteLine($"Parallel.ForEach (buggy): {sw.Elapsed.TotalSeconds:F2}s")
    End Sub
End Module
' </ParallelForEachBug>

' <ParallelForEachFix>
Public Module ParallelForEachFixDemo
    Private Function ProcessItemAsync(i As Integer, ct As CancellationToken) As ValueTask
        Return New ValueTask(Task.Delay(200, ct))
    End Function

    Public Async Function RunAsync() As Task
        Dim sw = Stopwatch.StartNew()
        Await Parallel.ForEachAsync(
            Enumerable.Range(0, 10),
            New ParallelOptions With {.MaxDegreeOfParallelism = 4},
            AddressOf ProcessItemAsync)
        Console.WriteLine($"Parallel.ForEachAsync (fixed): {sw.Elapsed.TotalSeconds:F2}s")
    End Function
End Module
' </ParallelForEachFix>

' <WhenAllAlternative>
Public Module WhenAllAlternativeDemo
    Public Async Function RunAsync() As Task
        Dim sw = Stopwatch.StartNew()
        Dim tasks = Enumerable.Range(0, 10).
            Select(Async Function(i)
                       Await Task.Delay(200)
                   End Function)
        Await Task.WhenAll(tasks)
        Console.WriteLine($"Task.WhenAll: {sw.Elapsed.TotalSeconds:F2}s")
    End Function
End Module
' </WhenAllAlternative>

' <StartNewBug>
Public Module StartNewBugDemo
    Public Async Function RunAsync() As Task
        Dim sw = Stopwatch.StartNew()
        ' t is Task(Of Task) — the outer task completes at the first yielding Await.
        Dim t As Task(Of Task) = Task.Factory.StartNew(Async Function()
                                                           Await Task.Delay(1000)
                                                       End Function)
        Await t ' Awaits only the outer task.
        Console.WriteLine($"StartNew (buggy): {sw.Elapsed.TotalSeconds:F2}s")
    End Function
End Module
' </StartNewBug>

' <StartNewFix1>
Public Module StartNewFix1Demo
    Public Async Function RunAsync() As Task
        Dim sw = Stopwatch.StartNew()
        Await Task.Run(Async Function()
                           Await Task.Delay(1000)
                       End Function)
        Console.WriteLine($"Task.Run (fixed): {sw.Elapsed.TotalSeconds:F2}s")
    End Function
End Module
' </StartNewFix1>

' <StartNewFix2>
Public Module StartNewFix2Demo
    Public Async Function RunAsync() As Task
        Dim sw = Stopwatch.StartNew()
        Await Task.Factory.StartNew(Async Function()
                                        Await Task.Delay(1000)
                                    End Function).Unwrap()
        Console.WriteLine($"StartNew + Unwrap (fixed): {sw.Elapsed.TotalSeconds:F2}s")
    End Function
End Module
' </StartNewFix2>

Module Program
    Sub Main()
        Console.WriteLine("=== Action pitfall ===")
        ActionPitfallDemo.Run()

        Console.WriteLine()
        Console.WriteLine("=== Action fix ===")
        ActionFixDemo.Run()

        Console.WriteLine()
        Console.WriteLine("=== Parallel.ForEach bug ===")
        ParallelForEachBugDemo.Run()

        Console.WriteLine()
        Console.WriteLine("=== Parallel.ForEachAsync fix ===")
        ParallelForEachFixDemo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("=== Task.WhenAll alternative ===")
        WhenAllAlternativeDemo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("=== StartNew bug ===")
        StartNewBugDemo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("=== Task.Run fix ===")
        StartNewFix1Demo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("=== StartNew + Unwrap fix ===")
        StartNewFix2Demo.RunAsync().Wait()

        Console.WriteLine()
        Console.WriteLine("Done.")
    End Sub
End Module
