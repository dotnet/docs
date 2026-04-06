' <SyncOverAsyncTAP>
Public Module TapWrapper
    ' Wrapping a TAP method with a synchronous method.
    ' Accessing .Result blocks until the task completes.
    Public Function Foo(fooAsync As Func(Of Task(Of Integer))) As Integer
        Return fooAsync().Result
    End Function
End Module
' </SyncOverAsyncTAP>

' <DeadlockExample>
Public Module DeadlockExample
    ' This method deadlocks when called from a UI thread
    ' or any thread with a single-threaded SynchronizationContext.
    Private Sub Delay(milliseconds As Integer)
        DelayAsync(milliseconds).Wait()
    End Sub

    Private Async Function DelayAsync(milliseconds As Integer) As Task
        Await Task.Delay(milliseconds)
    End Function
End Module
' </DeadlockExample>

' <ConfigureAwaitMitigation>
Public Module ConfigureAwaitMitigation
    Public Async Function LibraryMethodAsync() As Task(Of Integer)
        Await Task.Delay(100).ConfigureAwait(False)
        Return 42
    End Function

    ' Offload to the thread pool so there's no SynchronizationContext.
    Public Function Sync() As Integer
        Return Task.Run(Function() LibraryMethodAsync()).Result
    End Function
End Module
' </ConfigureAwaitMitigation>

Module Program
    Sub Main()
        Console.WriteLine("--- ConfigureAwait mitigation demo ---")
        Dim result As Integer = ConfigureAwaitMitigation.Sync()
        Console.WriteLine($"Result: {result}")
        Console.WriteLine("Done.")
    End Sub
End Module
