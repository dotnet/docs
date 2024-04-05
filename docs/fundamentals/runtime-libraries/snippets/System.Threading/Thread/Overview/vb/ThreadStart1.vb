' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Diagnostics
Imports System.Threading

Module Example3
    Public Sub Main()
        Dim th As New Thread(AddressOf ExecuteInForeground)
        th.Start()
        Thread.Sleep(1000)
        Console.WriteLine("Main thread ({0}) exiting...", Thread.CurrentThread.ManagedThreadId)
    End Sub

    Private Sub ExecuteInForeground()
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
        Loop While sw.ElapsedMilliseconds <= 5000
        sw.Stop()
    End Sub
End Module
' The example displays output like the following:
'       Thread 3: Running, Priority Normal
'       Thread 3: Elapsed 0.00 seconds
'       Thread 3: Elapsed 0.51 seconds
'       Main thread (1) exiting...
'       Thread 3: Elapsed 1.02 seconds
'       Thread 3: Elapsed 1.53 seconds
'       Thread 3: Elapsed 2.05 seconds
'       Thread 3: Elapsed 2.55 seconds
'       Thread 3: Elapsed 3.07 seconds
'       Thread 3: Elapsed 3.57 seconds
'       Thread 3: Elapsed 4.07 seconds
'       Thread 3: Elapsed 4.58 seconds
' </Snippet1>

