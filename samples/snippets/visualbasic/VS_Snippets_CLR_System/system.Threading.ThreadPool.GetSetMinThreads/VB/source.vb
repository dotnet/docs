' <Snippet1>
Imports System
Imports System.Threading

Public Class Test

    <MTAThread> _
    Public Shared Sub Main()
        Dim minWorker, minIOC As Integer
        ' Get the current settings.
        ThreadPool.GetMinThreads(minWorker, minIOC)
        ' Change the minimum number of worker threads to four, but
        ' keep the old setting for minimum asynchronous I/O 
        ' completion threads.
        If ThreadPool.SetMinThreads(4, minIOC) Then
            ' The minimum number of threads was set successfully.
        Else
            ' The minimum number of threads was not changed.
        End If
    End Sub
End Class
' </Snippet1>
