Imports System.Threading

' <ScalabilityWrong>
Public Module TimerExampleWrong
    Public Function SleepAsync(millisecondsTimeout As Integer) As Task
        Return Task.Run(Sub() Thread.Sleep(millisecondsTimeout))
    End Function
End Module
' </ScalabilityWrong>

' <ScalabilityRight>
Public Module TimerExampleRight
    Public Function SleepAsync(millisecondsTimeout As Integer) As Task
        Dim tcs As New TaskCompletionSource(Of Boolean)()
        Dim tmr As New Timer(
            Sub(state) tcs.TrySetResult(True), Nothing, millisecondsTimeout, Timeout.Infinite)

        tcs.Task.ContinueWith(
            Sub(t) tmr.Dispose(), TaskScheduler.Default)

        Return tcs.Task
    End Function
End Module
' </ScalabilityRight>

' <OffloadFromUI>
Public Module UIOffloadExample
    Public Function ComputeIntensive(input As Integer) As Integer
        Dim result As Integer = 0
        For i As Integer = 0 To input - 1
            result += i
        Next
        Return result
    End Function

    Public Async Function ConsumeFromUIThreadAsync() As Task
        Dim result As Integer = Await Task.Run(Function() ComputeIntensive(10_000))
        Console.WriteLine($"Result: {result}")
    End Function
End Module
' </OffloadFromUI>

Module Program
    Sub Main()
        Console.WriteLine("--- ScalabilityRight demo ---")
        TimerExampleRight.SleepAsync(100).Wait()
        Console.WriteLine("SleepAsync completed (100ms).")

        Console.WriteLine("--- OffloadFromUI demo ---")
        UIOffloadExample.ConsumeFromUIThreadAsync().Wait()

        Console.WriteLine("Done.")
    End Sub
End Module
