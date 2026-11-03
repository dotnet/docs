' <SingleException>
Public Module SingleExceptionExample
    Public Function FaultAsync() As Task(Of Integer)
        Return Task.FromException(Of Integer)(New InvalidOperationException("Single failure"))
    End Function

    Public Sub ShowBlockingDifferences()
        Try
            Dim ignored = FaultAsync().GetAwaiter().GetResult()
        Catch ex As Exception
            Console.WriteLine($"GetAwaiter().GetResult() threw {ex.GetType().Name}")
        End Try
    End Sub
End Module
' </SingleException>

' <SingleExceptionBad>
' ⚠️ DON'T copy this snippet. It demonstrates a problem where exceptions get wrapped unnecessarily.
Public Module SingleExceptionBadExample
    Public Function FaultAsync() As Task(Of Integer)
        Return Task.FromException(Of Integer)(New InvalidOperationException("Single failure"))
    End Function

    Public Sub ShowBlockingDifferences()
        Try
            Dim ignored = FaultAsync().Result
        Catch ex As AggregateException
            Console.WriteLine($".Result threw {ex.GetType().Name} with inner {ex.InnerException?.GetType().Name}")
        End Try
    End Sub
End Module
' </SingleExceptionBad>

' <MultiException>
Public Module MultiExceptionExample
    Public Async Function FaultAfterDelayAsync(name As String, milliseconds As Integer) As Task
        Await Task.Delay(milliseconds)
        Throw New InvalidOperationException($"{name} failed")
    End Function

    Public Sub ShowMultipleExceptions()
        Dim combined As Task = Task.WhenAll(
            FaultAfterDelayAsync("First", 10),
            FaultAfterDelayAsync("Second", 20))

        Try
            combined.GetAwaiter().GetResult()
        Catch ex As Exception
            Console.WriteLine($"GetAwaiter().GetResult() surfaced: {ex.Message}")
        End Try

        If combined.IsFaulted AndAlso combined.Exception IsNot Nothing Then
            Dim allErrors As AggregateException = combined.Exception.Flatten()
            Console.WriteLine($"Task.Exception contains {allErrors.InnerExceptions.Count} exceptions.")
        Else
            Console.WriteLine("Task.Exception was not available because the task did not fault.")
        End If
    End Sub
End Module
' </MultiException>

' <UnobservedTaskException>
Public Module UnobservedTaskExceptionExample
    Public Sub ShowEventBehavior()
        Dim eventRaised As Boolean = False

        AddHandler TaskScheduler.UnobservedTaskException,
            Sub(sender, args)
                eventRaised = True
                Console.WriteLine($"UnobservedTaskException raised with {args.Exception.InnerExceptions.Count} exception(s).")
                args.SetObserved()
            End Sub

        Task.Run(Sub() Throw New ApplicationException("Background failure"))

        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()

        If eventRaised Then
            Console.WriteLine("Event was raised. The process continued.")
        Else
            Console.WriteLine("Event was not observed in this short run. The process still continued.")
        End If
    End Sub
End Module
' </UnobservedTaskException>

Module Program
    Sub Main()
        Console.WriteLine("--- SingleException ---")
        SingleExceptionExample.ShowBlockingDifferences()

        Console.WriteLine("--- SingleExceptionBad ---")
        SingleExceptionBadExample.ShowBlockingDifferences()

        Console.WriteLine("--- MultiException ---")
        MultiExceptionExample.ShowMultipleExceptions()

        Console.WriteLine("--- UnobservedTaskException ---")
        UnobservedTaskExceptionExample.ShowEventBehavior()
    End Sub
End Module
