'<Snippet1>
Imports System.Threading

Class Test
    ' Create a new Mutex. The creating thread owns the
    ' Mutex.
    Private Shared mut As New Mutex(True)
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

        ' Wait one second before allowing other threads to
        ' acquire the Mutex.
        Console.WriteLine("Creating thread owns the Mutex.")
        Thread.Sleep(1000)

        Console.WriteLine("Creating thread releases the Mutex." & vbCrLf)
        mut.ReleaseMutex()
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
' The example displays output like the following:
'       Creating thread owns the Mutex.
'       Creating thread releases the Mutex.
'       
'       Thread1 has entered the protected area
'       Thread1 is leaving the protected area
'       
'       Thread2 has entered the protected area
'       Thread2 is leaving the protected area
'       
'       Thread3 has entered the protected area
'       Thread3 is leaving the protected area
'</Snippet1>