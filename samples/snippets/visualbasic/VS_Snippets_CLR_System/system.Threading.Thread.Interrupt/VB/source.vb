' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.Security.Permissions
Imports System.Threading

Public Class ThreadInterrupt

    <MTAThread> _
    Shared Sub Main()
        Dim stayAwake As New StayAwake()
        Dim newThread As New Thread(AddressOf stayAwake.ThreadMethod)
        newThread.Start()

        ' The following line causes an exception to be thrown 
        ' in ThreadMethod if newThread is currently blocked
        ' or becomes blocked in the future.
        newThread.Interrupt()
        Console.WriteLine("Main thread calls Interrupt on newThread.")

        ' Tell newThread to go to sleep.
        stayAwake.SleepSwitch = True

        ' Wait for newThread to end.
        newThread.Join()
    End Sub

End Class

Public Class StayAwake

    Dim sleepSwitchValue As Boolean = False

    WriteOnly Property SleepSwitch As Boolean
        Set
            sleepSwitchValue = Value
        End Set
    End Property 

    Sub New()
    End Sub

    Sub ThreadMethod()
        Console.WriteLine("newThread is executing ThreadMethod.")
        While Not sleepSwitchValue

            ' Use SpinWait instead of Sleep to demonstrate the 
            ' effect of calling Interrupt on a running thread.
            Thread.SpinWait(10000000)
        End While
        Try
            Console.WriteLine("newThread going to sleep.")

            ' When newThread goes to sleep, it is immediately 
            ' woken up by a ThreadInterruptedException.
            Thread.Sleep(Timeout.Infinite)
        Catch ex As ThreadInterruptedException
            Console.WriteLine("newThread cannot go to " & _
                "sleep - interrupted by main thread.")
        End Try
    End Sub

End Class
' </Snippet1>