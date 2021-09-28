﻿'<snippet05>
Imports System.Threading
Imports System.Threading.Tasks

Module LoopCancellation
    ' Demonstrated features:
    '   CancellationTokenSource
    '   Parallel.For()
    '   ParallelOptions
    '   ParallelLoopResult
    ' Expected results:
    '   An iteration for each argument value (0, 1, 2, 3, 4, 5, 6, 7, 8, 9) is executed.
    '   The order of execution of the iterations is undefined.
    '   The iteration when i=2 cancels the loop.
    '   Some iterations may bail out or not start at all; because they are temporally executed in unpredictable order, 
    '      it is impossible to say which will start/complete and which won't.
    '   At the end, an OperationCancelledException is surfaced.
    ' Documentation:
    '   http://msdn.microsoft.com/library/system.threading.cancellationtokensource(VS.100).aspx
    Private Sub Main()
        Dim cancellationSource As New CancellationTokenSource()
        Dim options As New ParallelOptions()
        options.CancellationToken = cancellationSource.Token

        Try
            Dim loopResult As ParallelLoopResult = _
                Parallel.For(0, 10, options, Sub(i, loopState)
                                                 Console.WriteLine("Start Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i)

                                                 ' Simulate a cancellation of the loop when i=2
                                                 If i = 2 Then
                                                     cancellationSource.Cancel()
                                                 End If

                                                 ' Simulates a long execution
                                                 For j As Integer = 0 To 9
                                                     Thread.Sleep(1 * 200)

                                                     ' check to see whether or not to continue
                                                     If loopState.ShouldExitCurrentIteration Then
                                                         Exit Sub
                                                     End If
                                                 Next

                                                 Console.WriteLine("Finish Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i)
                                             End Sub)

            If loopResult.IsCompleted Then
                Console.WriteLine("All iterations completed successfully. THIS WAS NOT EXPECTED.")
            End If
        Catch e As AggregateException
            ' No exception is expected in this example, but if one is still thrown from a task,
            ' it will be wrapped in AggregateException and propagated to the main thread.
            Console.WriteLine("An action has thrown an AggregateException. THIS WAS NOT EXPECTED." & vbLf & "{0}", e)
        Catch e As OperationCanceledException
            ' Catching the cancellation exception
            Console.WriteLine("An iteration has triggered a cancellation. THIS WAS EXPECTED." & vbLf & "{0}", e)
        Finally
            cancellationSource.Dispose()
        End Try
    End Sub
End Module
'</snippet05>
