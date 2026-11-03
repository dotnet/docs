' <SyncOverAsyncTAP>
Public Module TapWrapper
    Public Function Foo(fooAsync As Func(Of Task(Of Integer))) As Integer
        Return fooAsync().Result
    End Function
End Module
' </SyncOverAsyncTAP>

' <DeadlockExample>
Public Module DeadlockExample
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

    Public Function Sync() As Integer
        Return LibraryMethodAsync().Result
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
