'<snippet01>
Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks

Module TCSDemo
    ' Demonstrated features:
    '   TaskCompletionSource ctor()
    '   TaskCompletionSource.SetResult()
    '   TaskCompletionSource.SetException()
    '   Task.Result
    ' Expected results:
    '   The attempt to get t1.Result blocks for ~1000ms until tcs1 gets signaled. 15 is printed out.
    '   The attempt to get t2.Result blocks for ~1000ms until tcs2 gets signaled. An exception is printed out.

    Private Sub Main()
        Dim tcs1 As New TaskCompletionSource(Of Integer)()
        Dim t1 As Task(Of Integer) = tcs1.Task

        ' Start a background task that will complete tcs1.Task
        Task.Factory.StartNew(Sub()
                                  Thread.Sleep(1000)
                                  tcs1.SetResult(15)
                              End Sub)

        ' The attempt to get the result of t1 blocks the current thread until the completion source gets signaled.
        ' It should be a wait of ~1000 ms.
        Dim sw As Stopwatch = Stopwatch.StartNew()
        Dim result As Integer = t1.Result
        sw.Stop()

        Console.WriteLine("(ElapsedTime={0}): t1.Result={1} (expected 15) ", sw.ElapsedMilliseconds, result)

        ' ------------------------------------------------------------------

        ' Alternatively, an exception can be manually set on a TaskCompletionSource.Task
        Dim tcs2 As New TaskCompletionSource(Of Integer)()
        Dim t2 As Task(Of Integer) = tcs2.Task

        ' Start a background Task that will complete tcs2.Task with an exception
        Task.Factory.StartNew(Sub()
                                  Thread.Sleep(1000)
                                  tcs2.SetException(New InvalidOperationException("SIMULATED EXCEPTION"))
                              End Sub)

        ' The attempt to get the result of t2 blocks the current thread until the completion source gets signaled with either a result or an exception.
        ' In either case it should be a wait of ~1000 ms.
        sw = Stopwatch.StartNew()
        Try
            result = t2.Result

            Console.WriteLine("t2.Result succeeded. THIS WAS NOT EXPECTED.")
        Catch e As AggregateException
            Console.Write("(ElapsedTime={0}): ", sw.ElapsedMilliseconds)
            Console.WriteLine("The following exceptions have been thrown by t2.Result: (THIS WAS EXPECTED)")
            For j As Integer = 0 To e.InnerExceptions.Count - 1
                Console.WriteLine(vbLf & "-------------------------------------------------" & vbLf & "{0}", e.InnerExceptions(j).ToString())
            Next
        End Try
    End Sub

End Module
'</snippet01>