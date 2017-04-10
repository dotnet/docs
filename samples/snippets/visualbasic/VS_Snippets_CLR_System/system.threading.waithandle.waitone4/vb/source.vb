'<snippet1>
Imports System
Imports System.Threading
Imports System.Runtime.Remoting.Contexts

<Synchronization(true)>
Public Class SyncingClass
    Inherits ContextBoundObject
    
    Private waitHandle As EventWaitHandle

    Public Sub New()
         waitHandle = New EventWaitHandle(false, EventResetMode.ManualReset)
    End Sub

    Public Sub Signal()
        Console.WriteLine("Thread[{0:d4}]: Signalling...", Thread.CurrentThread.GetHashCode())
        waitHandle.Set()
    End Sub

    Public Sub DoWait(leaveContext As Boolean)
        Dim signalled As Boolean

        waitHandle.Reset()
        Console.WriteLine("Thread[{0:d4}]: Waiting...", Thread.CurrentThread.GetHashCode())
        signalled = waitHandle.WaitOne(3000, leaveContext)
        If signalled Then
            Console.WriteLine("Thread[{0:d4}]: Wait released!!!", Thread.CurrentThread.GetHashCode())
        Else
            Console.WriteLine("Thread[{0:d4}]: Wait timeout!!!", Thread.CurrentThread.GetHashCode())
        End If
    End Sub
End Class

Public Class TestSyncDomainWait
    Public Shared Sub Main()
        Dim syncClass As New SyncingClass()

        Dim runWaiter As Thread

        Console.WriteLine(vbNewLine + "Wait and signal INSIDE synchronization domain:" + vbNewLine)
        runWaiter = New Thread(AddressOf RunWaitKeepContext)
        runWaiter.Start(syncClass)
        Thread.Sleep(1000)
        Console.WriteLine("Thread[{0:d4}]: Signal...", Thread.CurrentThread.GetHashCode())
        ' This call to Signal will block until the timeout in DoWait expires.
        syncClass.Signal()
        runWaiter.Join()

        Console.WriteLine(vbNewLine + "Wait and signal OUTSIDE synchronization domain:" + vbNewLine)
        runWaiter = New Thread(AddressOf RunWaitLeaveContext)
        runWaiter.Start(syncClass)
        Thread.Sleep(1000)
        Console.WriteLine("Thread[{0:d4}]: Signal...", Thread.CurrentThread.GetHashCode())
        ' This call to Signal is unblocked and will set the wait handle to
        ' release the waiting thread.
        syncClass.Signal()
        runWaiter.Join()
    End Sub

    Public Shared Sub RunWaitKeepContext(parm As Object)
        Dim syncClass As SyncingClass = CType(parm, SyncingClass)
        syncClass.DoWait(False)
    End Sub

    Public Shared Sub RunWaitLeaveContext(parm As Object)
        Dim syncClass As SyncingClass = CType(parm, SyncingClass)
        syncClass.DoWait(True)
    End Sub
End Class

' The output for the example program will be similar to the following:
'
' Wait and signal INSIDE synchronization domain:
'
' Thread[0004]: Waiting...
' Thread[0001]: Signal...
' Thread[0004]: Wait timeout!!!
' Thread[0001]: Signalling...
'
' Wait and signal OUTSIDE synchronization domain:
'
' Thread[0006]: Waiting...
' Thread[0001]: Signal...
' Thread[0001]: Signalling...
' Thread[0006]: Wait released!!!
'</snippet1>
