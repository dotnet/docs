'<snippet29>
' How to: Cancel a Parallel.For or ForEach Loop

Imports System.Threading
Imports System.Threading.Tasks

Module CancelParallelLoops
    Sub Main()
        Dim nums() As Integer = Enumerable.Range(0, 10000000).ToArray()
        Dim cts As New CancellationTokenSource

        ' Use ParallelOptions instance to store the CancellationToken
        Dim po As New ParallelOptions
        po.CancellationToken = cts.Token
        po.MaxDegreeOfParallelism = System.Environment.ProcessorCount
        Console.WriteLine("Press any key to start. Press 'c' to cancel.")
        Console.ReadKey()

        ' Run a task so that we can cancel from another thread.
        Dim t As Task = Task.Factory.StartNew(Sub()
                                                  If Console.ReadKey().KeyChar = "c"c Then
                                                      cts.Cancel()
                                                  End If
                                                  Console.WriteLine(vbCrLf & "Press any key to exit.")
                                              End Sub)

        Try

            ' The error "Exception is unhandled by user code" will appear if "Just My Code" 
            ' is enabled. This error is benign. You can press F5 to continue, or disable Just My Code.
            Parallel.ForEach(nums, po, Sub(num)
                                           Dim d As Double = Math.Sqrt(num)
                                           Console.CursorLeft = 0
                                           Console.Write("{0:##.##} on {1}", d, Thread.CurrentThread.ManagedThreadId)
                                       End Sub)

        Catch e As OperationCanceledException
            Console.WriteLine(e.Message)
        Finally
            cts.Dispose()
        End Try

        Console.ReadKey()

    End Sub
End Module
'</snippet29>
