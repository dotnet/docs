'<Snippet1>
' This example shows how to create an object containing task
' information, and pass that object to a task queued for
' execution by the thread pool.
Imports System
Imports System.Threading
' TaskInfo holds state information for a task that will be
' executed by a ThreadPool thread.
Public Class TaskInfo
    ' State information for the task.  These members
    ' can be implemented as read-only properties, read/write
    ' properties with validation, and so on, as required.
    Public Boilerplate As String
    Public Value As Integer

    ' Public constructor provides an easy way to supply all
    ' the information needed for the task.
    Public Sub New(text As String, number As Integer)
        Boilerplate = text
        Value = number
    End Sub
End Class

Public Class Example

    <MTAThread> _
    Public Shared Sub Main()
        ' Create an object containing the information needed
        ' for the task.
        Dim ti As New TaskInfo("This report displays the number {0}.", 42)

        ' Queue the task and data.
        ThreadPool.QueueUserWorkItem( _
                New WaitCallback(AddressOf ThreadProc), ti)
        
        Console.WriteLine("Main thread does some work, then sleeps.")

        ' If you comment out the Sleep, the main thread exits before
        ' the ThreadPool task has a chance to run.  ThreadPool uses 
        ' background threads, which do not keep the application 
        ' running.  (This is a simple example of a race condition.)
        Thread.Sleep(1000)

        Console.WriteLine("Main thread exits.")
    End Sub

    ' The thread procedure performs the independent task, in this case
    ' formatting and printing a very simple report.
    '
    Shared Sub ThreadProc(stateInfo As Object)
        Dim ti As TaskInfo = CType(stateInfo, TaskInfo)
        Console.WriteLine(ti.Boilerplate, ti.Value)
    End Sub
End Class
' The example displays output like the following:
'        Main thread does some work, then sleeps.
'        This report displays the number 42.
'        Main thread exits.
'</Snippet1>