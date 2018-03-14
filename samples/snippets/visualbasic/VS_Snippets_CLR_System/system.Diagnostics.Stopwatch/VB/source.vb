'<Snippet1>
Imports System
Imports System.Diagnostics
Imports System.Threading


Class Program

    Shared Sub Main(ByVal args() As String)
        Dim stopWatch As New Stopwatch()
        stopWatch.Start()
        Thread.Sleep(10000)
        stopWatch.Stop()
        ' Get the elapsed time as a TimeSpan value.
        Dim ts As TimeSpan = stopWatch.Elapsed

        ' Format and display the TimeSpan value.
        Dim elapsedTime As String = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10)
        Console.WriteLine( "RunTime " + elapsedTime)

    End Sub 'Main
End Class 'Program
'</Snippet1>