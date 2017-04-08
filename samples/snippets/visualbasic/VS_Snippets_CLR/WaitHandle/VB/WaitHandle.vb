 'Types:System.Threading.WaitHandle Vendor: Richter (converted to VB by GlennHa)
'<snippet1>
Imports System
Imports System.Threading

NotInheritable Public Class App
    ' Define an array with two AutoResetEvent WaitHandles.
    Private Shared waitHandles() As WaitHandle = _
        {New AutoResetEvent(False), New AutoResetEvent(False)}
    
    ' Define a random number generator for testing.
    Private Shared r As New Random()
    
    '<snippet2>
    <MTAThreadAttribute> _
    Public Shared Sub Main() 
        ' Queue two tasks on two different threads; 
        ' wait until all tasks are completed.
        Dim dt As DateTime = DateTime.Now
        Console.WriteLine("Main thread is waiting for BOTH tasks to complete.")
        ThreadPool.QueueUserWorkItem(AddressOf DoTask, waitHandles(0))
        ThreadPool.QueueUserWorkItem(AddressOf DoTask, waitHandles(1))
        WaitHandle.WaitAll(waitHandles)
        ' The time shown below should match the longest task.
        Console.WriteLine("Both tasks are completed (time waited={0})", _
            (DateTime.Now - dt).TotalMilliseconds)
        
        ' Queue up two tasks on two different threads; 
        ' wait until any tasks are completed.
        dt = DateTime.Now
        Console.WriteLine()
        Console.WriteLine("The main thread is waiting for either task to complete.")
        ThreadPool.QueueUserWorkItem(AddressOf DoTask, waitHandles(0))
        ThreadPool.QueueUserWorkItem(AddressOf DoTask, waitHandles(1))
        Dim index As Integer = WaitHandle.WaitAny(waitHandles)
        ' The time shown below should match the shortest task.
        Console.WriteLine("Task {0} finished first (time waited={1}).", _
            index + 1,(DateTime.Now - dt).TotalMilliseconds)
    
    End Sub 'Main
    
    '</snippet2>
    Shared Sub DoTask(ByVal state As [Object]) 
        Dim are As AutoResetEvent = CType(state, AutoResetEvent)
        Dim time As Integer = 1000 * r.Next(2, 10)
        Console.WriteLine("Performing a task for {0} milliseconds.", time)
        Thread.Sleep(time)
        are.Set()
    
    End Sub 'DoTask
End Class 'App

' This code produces output similar to the following:
'
'  Main thread is waiting for BOTH tasks to complete.
'  Performing a task for 7000 milliseconds.
'  Performing a task for 4000 milliseconds.
'  Both tasks are completed (time waited=7064.8052)
' 
'  The main thread is waiting for either task to complete.
'  Performing a task for 2000 milliseconds.
'  Performing a task for 2000 milliseconds.
'  Task 1 finished first (time waited=2000.6528).
'</snippet1>