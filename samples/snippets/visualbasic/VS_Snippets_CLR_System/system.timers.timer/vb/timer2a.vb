' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Timers

Public Module Example
    Private aTimer As System.Timers.Timer

    Public Sub Main()
        SetTimer()

      Console.WriteLine("{0}Press the Enter key to exit the application...{0}",
                        vbCrLf)
      Console.WriteLine("The application started at {0:HH:mm:ss.fff}",
                        DateTime.Now)
      Console.ReadLine()
      aTimer.Stop()
      aTimer.Dispose()

      Console.WriteLine("Terminating the application...")
    End Sub

    Private Sub SetTimer()
        ' Create a timer with a two second interval.
        aTimer = New System.Timers.Timer(2000)
        ' Hook up the Elapsed event for the timer. 
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
        aTimer.AutoReset = True
        aTimer.Enabled = True
    End Sub

    ' The event handler for the Timer.Elapsed event. 
    Private Sub OnTimedEvent(source As Object, e As ElapsedEventArgs)
        Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                          e.SignalTime)
    End Sub 
End Module
' The example displays output like the following:
'       Press the Enter key to exit the application...
'
'       The application started at 09:40:29.068
'       The Elapsed event was raised at 09:40:31.084
'       The Elapsed event was raised at 09:40:33.100
'       The Elapsed event was raised at 09:40:35.100
'       The Elapsed event was raised at 09:40:37.116
'       The Elapsed event was raised at 09:40:39.116
'       The Elapsed event was raised at 09:40:41.117
'       The Elapsed event was raised at 09:40:43.132
'       The Elapsed event was raised at 09:40:45.133
'       The Elapsed event was raised at 09:40:47.148
'
'       Terminating the application...
' </Snippet2>