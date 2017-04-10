Option Explicit On

' <Snippet1>
Imports System.Threading
Imports Timers = System.Timers

Public Module Example
   Dim t As Timers.Timer
   Private priorityTest As New PriorityTest()

    Public Sub Main()
        Dim thread1 As New Thread(AddressOf priorityTest.ThreadMethod)
        thread1.Name = "ThreadOne"
        Dim thread2 As New Thread(AddressOf priorityTest.ThreadMethod)
        thread2.Name = "ThreadTwo"
        thread2.Priority = ThreadPriority.BelowNormal
        Dim thread3 As New Thread(AddressOf priorityTest.ThreadMethod)
        thread3.Name = "ThreadThree"
        thread3.Priority = ThreadPriority.AboveNormal
        thread1.Start()
        thread2.Start()
        thread3.Start()
        
        ' Allow threads to execute for about 10 seconds.
        t = New Timers.Timer()
        t.AutoReset = False
        t.Interval = 10000
        AddHandler t.Elapsed, AddressOf Elapsed
        t.Start()
    End Sub
    
    Private Sub Elapsed(sender As Object, e As Timers.ElapsedEventArgs)
       priorityTest.LoopSwitch = False
    End Sub
End Module

Public Class PriorityTest
    Private Shared loopSwitchValue As Boolean
    <ThreadStatic> Shared threadCount As Long

    Sub New()
        loopSwitchValue = True
    End Sub

    WriteOnly Property LoopSwitch As Boolean
        Set
            loopSwitchValue = Value
        End Set
    End Property

    Sub ThreadMethod()
        Do While True
            threadCount += 1
            If Not loopSwitchValue Then Exit Do
        Loop

        Console.WriteLine("{0,-11} with {1,11} priority " &
            "has a count = {2,13}", Thread.CurrentThread.Name,
            Thread.CurrentThread.Priority.ToString(),
            threadCount.ToString("N0")) 
    End Sub
End Class
' The example displays output like the following:
'    ThreadTwo   with BelowNormal priority has a count =   835,095,262
'    ThreadThree with AboveNormal priority has a count =   943,086,669
'    ThreadOne   with      Normal priority has a count =   876,020,100
' </Snippet1>