' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic
Imports System.IO
Imports System.Timers

Module Example
   Private WithEvents aTimer As Timer
   Private eventlog As List(Of String)
   Private nEventsFired As Integer = 0
   Private previousTime As Date

   Public Sub Main()
        eventlog = New List(Of String)()
        
        Dim sr As New StreamWriter(".\Interval.txt")
        ' Create a timer with a five millisecond interval.
        aTimer = New Timer(5)
        aTimer.AutoReset = True
        sr.WriteLine("The timer should fire every {0} milliseconds.", 
                     aTimer.Interval)
        aTimer.Enabled = True

        
        Console.WriteLine("Press the Enter key to exit the program... ")
        Console.ReadLine()
        For Each item In eventlog
           sr.WriteLine(item)
        Next
        sr.Close()
        Console.WriteLine("Terminating the application...")
   End Sub

    Private Sub OnTimedEvent(source As Object, e As ElapsedEventArgs) _
                             Handles aTimer.Elapsed
        eventlog.Add(String.Format("Elapsed event at {0:HH':'mm':'ss.ffffff} ({1})", 
                                   e.SignalTime, 
                                   If(nEventsFired = 0, 
                                      0.0, (e.SignalTime - previousTime).TotalMilliseconds)))
        nEventsFired += 1
        previousTime = e.SignalTime
        if nEventsFired = 20 Then
           Console.WriteLine("No more events will fire...")
           aTimer.Enabled = False
        End If
   End Sub
End Module
' The example displays the following output:
'       The timer should fire every 5 milliseconds.
'       Elapsed event at 08:42:49.370344 (0)
'       Elapsed event at 08:42:49.385345 (15.0015)
'       Elapsed event at 08:42:49.400347 (15.0015)
'       Elapsed event at 08:42:49.415348 (15.0015)
'       Elapsed event at 08:42:49.430350 (15.0015)
'       Elapsed event at 08:42:49.445351 (15.0015)
'       Elapsed event at 08:42:49.465353 (20.002)
'       Elapsed event at 08:42:49.480355 (15.0015)
'       Elapsed event at 08:42:49.495356 (15.0015)
'       Elapsed event at 08:42:49.510358 (15.0015)
'       Elapsed event at 08:42:49.525359 (15.0015)
'       Elapsed event at 08:42:49.540361 (15.0015)
'       Elapsed event at 08:42:49.555362 (15.0015)
'       Elapsed event at 08:42:49.570364 (15.0015)
'       Elapsed event at 08:42:49.585365 (15.0015)
'       Elapsed event at 08:42:49.605367 (20.002)
'       Elapsed event at 08:42:49.620369 (15.0015)
'       Elapsed event at 08:42:49.635370 (15.0015)
'       Elapsed event at 08:42:49.650372 (15.0015)
'       Elapsed event at 08:42:49.665373 (15.0015)
' </Snippet1>
