' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.Threading

Public Class IsThreadPool

    <MTAThread> _
    Shared Sub Main()
        Dim autoEvent As New AutoResetEvent(False)

        Dim regularThread As New Thread(AddressOf ThreadMethod)
        regularThread.Start()
        ThreadPool.QueueUserWorkItem(AddressOf WorkMethod, autoEvent)

        ' Wait for foreground thread to end.
        regularThread.Join()

        ' Wait for background thread to end.
        autoEvent.WaitOne()
    End Sub

    ' <Snippet2>
    Shared Sub ThreadMethod()
        Console.WriteLine("ThreadOne, executing ThreadMethod, " & _
            "is from the thread pool? {0}", _
            Thread.CurrentThread.IsThreadPoolThread)
    End Sub
    ' </Snippet2>

    Shared Sub WorkMethod(stateInfo As Object)
        Console.WriteLine("ThreadTwo, executing WorkMethod, " & _
            "is from the thread pool? {0}", _
            Thread.CurrentThread.IsThreadPoolThread)

        ' Signal that this thread is finished.
        DirectCast(stateInfo, AutoResetEvent).Set()
    End Sub

End Class
' </Snippet1>