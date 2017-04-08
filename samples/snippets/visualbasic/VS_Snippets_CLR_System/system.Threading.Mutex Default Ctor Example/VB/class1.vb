'<Snippet1>
' This example shows how a Mutex is used to synchronize access
' to a protected resource. Unlike Monitor, Mutex can be used with
' WaitHandle.WaitAll and WaitAny, and can be passed across
' AppDomain boundaries.
 
Imports System
Imports System.Threading
Imports Microsoft.VisualBasic

Class Test
    ' Create a new Mutex. The creating thread does not own the
    ' Mutex.
    Private Shared mut As New Mutex()
    Private Const numIterations As Integer = 1
    Private Const numThreads As Integer = 3

    <MTAThread> _
    Shared Sub Main()
        ' Create the threads that will use the protected resource.
        Dim i As Integer
        For i = 1 To numThreads
            Dim myThread As New Thread(AddressOf MyThreadProc)
            myThread.Name = [String].Format("Thread{0}", i)
            myThread.Start()
        Next i

        ' The main thread exits, but the application continues to
        ' run until all foreground threads have exited.

    End Sub 'Main

    Private Shared Sub MyThreadProc()
        Dim i As Integer
        For i = 1 To numIterations
            UseResource()
        Next i
    End Sub 'MyThreadProc

    ' This method represents a resource that must be synchronized
    ' so that only one thread at a time can enter.
    Private Shared Sub UseResource()
        ' Wait until it is safe to enter.
        mut.WaitOne()

        Console.WriteLine("{0} has entered protected area", _
            Thread.CurrentThread.Name)

        ' Place code to access non-reentrant resources here.

        ' Simulate some work
        Thread.Sleep(500)

        Console.WriteLine("{0} is leaving protected area" & vbCrLf, _
            Thread.CurrentThread.Name)

        ' Release Mutex.
        mut.ReleaseMutex()
    End Sub 'UseResource
End Class 'MyMainClass
'</Snippet1>