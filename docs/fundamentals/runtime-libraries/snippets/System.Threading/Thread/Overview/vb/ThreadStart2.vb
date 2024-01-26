' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Diagnostics
Imports System.Threading

Module Example4
    Public Sub Main()
        Dim th As New Thread(AddressOf ExecuteInForeground)
        th.Start(4500)
        Thread.Sleep(1000)
        Console.WriteLine("Main thread ({0}) exiting...", Thread.CurrentThread.ManagedThreadId)
    End Sub

    Private Sub ExecuteInForeground(obj As Object)
        Dim interval As Integer
        If IsNumeric(obj) Then
            interval = CInt(obj)
        Else
            interval = 5000
        End If
        Dim start As DateTime = DateTime.Now
        Dim sw As Stopwatch = Stopwatch.StartNew()
        Console.WriteLine("Thread {0}: {1}, Priority {2}",
                        Thread.CurrentThread.ManagedThreadId,
                        Thread.CurrentThread.ThreadState,
                        Thread.CurrentThread.Priority)
        Do
            Console.WriteLine("Thread {0}: Elapsed {1:N2} seconds",
                           Thread.CurrentThread.ManagedThreadId,
                           sw.ElapsedMilliseconds / 1000)
            Thread.Sleep(500)
        Loop While sw.ElapsedMilliseconds <= interval
        sw.Stop()
    End Sub
End Module
' The example displays output like the following:
'       Thread 3: Running, Priority Normal
'       Thread 3: Elapsed 0.00 seconds
'       Thread 3: Elapsed 0.52 seconds
'       Main thread (1) exiting...
'       Thread 3: Elapsed 1.03 seconds
'       Thread 3: Elapsed 1.55 seconds
'       Thread 3: Elapsed 2.06 seconds
'       Thread 3: Elapsed 2.58 seconds
'       Thread 3: Elapsed 3.09 seconds
'       Thread 3: Elapsed 3.61 seconds
'       Thread 3: Elapsed 4.12 seconds
' </Snippet2>

