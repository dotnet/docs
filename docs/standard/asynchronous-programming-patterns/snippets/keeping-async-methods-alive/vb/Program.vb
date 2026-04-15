Imports System.Collections.Concurrent

' <FireAndForgetPitfall>
Public Module FireAndForgetPitfall
    Public Async Function RunAsync() As Task
        Dim discardedTask As Task = Task.Run(Async Function()
                                                 Await Task.Delay(100)
                                                 Throw New InvalidOperationException("Background operation failed.")
                                             End Function)

        Await Task.Delay(150)
        Console.WriteLine("Caller finished without observing background completion.")
    End Function
End Module
' </FireAndForgetPitfall>

Public NotInheritable Class BackgroundTaskTracker
    Private ReadOnly _inFlight As New ConcurrentDictionary(Of Integer, Task)()

    Public Sub Track(operationTask As Task, name As String)
        Dim id As Integer = operationTask.Id
        _inFlight(id) = operationTask

        Dim continuationTask As Task = operationTask.ContinueWith(Sub(completedTask)
                                                                      Dim removedTask As Task = Nothing
                                                                      _inFlight.TryRemove(id, removedTask)

                                                                      If completedTask.IsFaulted Then
                                                                          Console.WriteLine($"{name} failed: {completedTask.Exception.GetBaseException().Message}")
                                                                      End If
                                                                  End Sub,
                                                                  TaskScheduler.Default)
    End Sub

    Public Function DrainAsync() As Task
        Dim snapshot As Task() = _inFlight.Values.ToArray()

        If snapshot.Length = 0 Then
            Return Task.CompletedTask
        End If

        Return Task.WhenAll(snapshot)
    End Function
End Class

' <FireAndForgetFix>
Public Module FireAndForgetFix
    Public Async Function RunAsync(tracker As BackgroundTaskTracker) As Task
        Dim backgroundTask As Task = Task.Run(Async Function()
                                                  Await Task.Delay(100)
                                                  Throw New InvalidOperationException("Background operation failed.")
                                              End Function)

        tracker.Track(backgroundTask, "Cache refresh")

        Try
            Await tracker.DrainAsync()
        Catch ex As Exception
            Console.WriteLine($"Drain observed failure: {ex.GetBaseException().Message}")
        End Try
    End Function
End Module
' </FireAndForgetFix>

Module Program
    Sub Main()
        Console.WriteLine("--- Pitfall ---")
        FireAndForgetPitfall.RunAsync().Wait()

        Console.WriteLine("--- Fix ---")
        Dim tracker As New BackgroundTaskTracker()
        FireAndForgetFix.RunAsync(tracker).Wait()

        Console.WriteLine("Done.")
    End Sub
End Module
