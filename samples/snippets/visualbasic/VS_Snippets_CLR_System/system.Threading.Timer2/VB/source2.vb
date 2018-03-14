' <Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.Threading

Public Class TimerExample

    <MTAThread> _
    Shared Sub Main()
    
        Dim autoEvent As New AutoResetEvent(False)
        Dim statusChecker As New StatusChecker(10)

        ' Create the delegate that invokes methods for the timer.
        Dim timerDelegate As TimerCallback = _
            AddressOf statusChecker.CheckStatus

        Dim delayTime As New TimeSpan(0, 0, 1)
        Dim intervalTime As New TimeSpan(0, 0, 0, 0, 250)

        ' Create a timer that signals the delegate to invoke 
        ' CheckStatus after one second, and every 1/4 second 
        ' thereafter.
        Console.WriteLine("{0} Creating timer." & vbCrLf, _
            DateTime.Now.ToString("h:mm:ss.fff"))
        Dim stateTimer As Timer = New Timer( _
            timerDelegate, autoEvent, delayTime, intervalTime)

        ' When autoEvent signals, change the period to every 
        ' 1/2 second.
        autoEvent.WaitOne(5000, False)
        stateTimer.Change( _
            new TimeSpan(0), intervalTime.Add(intervalTime))
        Console.WriteLine(vbCrLf & "Changing period." & vbCrLf)

        ' When autoEvent signals the second time, dispose of 
        ' the timer.
        autoEvent.WaitOne(5000, False)
        stateTimer.Dispose()
        Console.WriteLine(vbCrLf & "Destroying timer.")
    
    End Sub
End Class

Public Class StatusChecker

    Dim invokeCount, maxCount As Integer 

    Sub New(count As Integer)
        invokeCount  = 0
        maxCount = count
    End Sub

    ' This method is called by the timer delegate.
    Sub CheckStatus(stateInfo As Object)
        Dim autoEvent As AutoResetEvent = _
            DirectCast(stateInfo, AutoResetEvent)
        invokeCount += 1
        Console.WriteLine("{0} Checking status {1,2}.", _
            DateTime.Now.ToString("h:mm:ss.fff"), _
            invokeCount.ToString())

        If invokeCount = maxCount Then
        
            ' Reset the counter and signal to stop the timer.
            invokeCount  = 0
            autoEvent.Set()
        End If
    End Sub

End Class
' </Snippet1>