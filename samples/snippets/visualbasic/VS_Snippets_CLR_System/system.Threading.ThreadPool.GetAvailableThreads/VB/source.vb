' <Snippet1>
Imports System.IO
Imports System.Security.Permissions
Imports System.Threading

Public Class Example
    Shared Sub Main()
        Dim mainEvent As New AutoResetEvent(False)
        Dim workerThreads As Integer 
        Dim portThreads As Integer 

        ThreadPool.GetMaxThreads(workerThreads, portThreads)
        Console.WriteLine(vbCrLf & "Maximum worker threads: " & _
            vbTab & "{0}" & vbCrLf & "Maximum completion port " & _
            "threads: {1}", workerThreads, portThreads)

        ThreadPool.GetAvailableThreads(workerThreads, portThreads)
        Console.WriteLine(vbCrLf & "Available worker threads: " & _
            vbTab & "{0}" & vbCrLf & "Available completion port " & _
            "threads: {1}" & vbCrLf, workerThreads, portThreads)

        ThreadPool.QueueUserWorkItem(AddressOf _
            ThreadPoolTest.WorkItemMethod, mainEvent)
           
        ' Since ThreadPool threads are background threads, 
        ' wait for the work item to signal before ending Main.
        mainEvent.WaitOne(5000, False)
    End Sub

End Class

Public Class ThreadPoolTest

    ' Maintains state information to be passed to EndWriteCallback.
    ' This information allows the callback to end the asynchronous
    ' write operation and signal when it is finished.
    Class State
        Public fStream As FileStream
        Public autoEvent As AutoResetEvent

        Public Sub New(aFileStream As FileStream, anEvent As AutoResetEvent)
            fStream   = aFileStream
            autoEvent = anEvent
        End Sub
    End Class   
    
    Private Sub New
    End Sub

    Shared Sub WorkItemMethod(mainEvent As Object)
    
        Console.WriteLine(vbCrLf & "Starting WorkItem." & vbCrLf)
        Dim autoEvent As New AutoResetEvent(False)

        ' Create some data.
        Const ArraySize As Integer  = 10000
        Const BufferSize As Integer =  1000
        Dim byteArray As Byte() = New Byte(ArraySize){}
        Dim randomGenerator As New Random()
        randomGenerator.NextBytes(byteArray)

        ' Create two files and two State objects. 
        Dim fileWriter1 As FileStream = _
            New FileStream("C:\Test1111.dat", FileMode.Create, _
            FileAccess.ReadWrite, FileShare.ReadWrite, _
            BufferSize, True)
        Dim fileWriter2 As FileStream = _
            New FileStream("C:\Test2222.dat", FileMode.Create, _
            FileAccess.ReadWrite, FileShare.ReadWrite, _
            BufferSize, True)
        Dim stateInfo1 As New State(fileWriter1, autoEvent)
        Dim stateInfo2 As New State(fileWriter2, autoEvent)

        ' Asynchronously write to the files.
        fileWriter1.BeginWrite(byteArray, 0, byteArray.Length, _
            AddressOf EndWriteCallback, stateInfo1)
        fileWriter2.BeginWrite(byteArray, 0, byteArray.Length, _
            AddressOf EndWriteCallback, stateInfo2)

        ' Wait for the callbacks to signal.
        autoEvent.WaitOne()
        autoEvent.WaitOne()

        fileWriter1.Close()
        fileWriter2.Close()
        Console.WriteLine(vbCrLf & "Ending WorkItem." & vbCrLf)

        ' Signal Main that the work item is finished.
        DirectCast(mainEvent, AutoResetEvent).Set()
    
    End Sub

    Shared Sub EndWriteCallback(asyncResult As IAsyncResult)
        Console.WriteLine("Starting EndWriteCallback.")

        Dim stateInfo As State = _
            DirectCast(asyncResult.AsyncState, State)
        Dim workerThreads As Integer 
        Dim portThreads As Integer 
        Try
            ThreadPool.GetAvailableThreads(workerThreads, portThreads)
            Console.WriteLine(vbCrLf & "Available worker " & _
                "threads:" & vbTab & "{0}" & vbCrLf & "Available " & _
                "completion port threads: {1}" & vbCrLf, _
                workerThreads, portThreads)

            stateInfo.fStream.EndWrite(asyncResult)

            ' Sleep so the other thread has a chance to run
            ' before the current thread ends.
            Thread.Sleep(1500)
        Finally
        
            ' Signal that the current thread is finished.
            stateInfo.autoEvent.Set()
            Console.WriteLine("Ending EndWriteCallback.")
        End Try
    
    End Sub
End Class
' </Snippet1>