'<snippet01>
Imports System.Threading
Imports System.Threading.Tasks

Module SpinWaitDemo
    ' Demonstrates:
    ' SpinWait construction
    ' SpinWait.SpinOnce()
    ' SpinWait.NextSpinWillYield
    ' SpinWait.Count
    Private Sub SpinWaitSample()
        Dim someBoolean As Boolean = False
        Dim numYields As Integer = 0

        ' First task: SpinWait until someBoolean is set to true
        Dim t1 As Task = Task.Factory.StartNew(
            Sub()
                Dim sw As New SpinWait()
                While Not someBoolean
                    ' The NextSpinWillYield property returns true if
                    ' calling sw.SpinOnce() will result in yielding the
                    ' processor instead of simply spinning.
                    If sw.NextSpinWillYield Then
                        numYields += 1
                    End If
                    sw.SpinOnce()
                End While

                ' As of .NET Framework 4: After some initial spinning, SpinWait.SpinOnce() will yield every time.
                Console.WriteLine("SpinWait called {0} times, yielded {1} times", sw.Count, numYields)
            End Sub)

        ' Second task: Wait 100ms, then set someBoolean to true
        Dim t2 As Task = Task.Factory.StartNew(
            Sub()
                Thread.Sleep(100)
                someBoolean = True
            End Sub)

        ' Wait for tasks to complete
        Task.WaitAll(t1, t2)
    End Sub

End Module
'</snippet01>