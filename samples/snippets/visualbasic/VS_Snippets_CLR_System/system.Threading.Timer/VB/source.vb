' <Snippet1>
Imports System.Threading

Public Module Example
    Public Sub Main()
        ' Use an AutoResetEvent to signal the timeout threshold in the
        ' timer callback has been reached.
        Dim autoEvent As New AutoResetEvent(False)

        Dim statusChecker As New StatusChecker(10)

        ' Create a timer that invokes CheckStatus after one second, 
        ' and every 1/4 second thereafter.
        Console.WriteLine("{0:h:mm:ss.fff} Creating timer." & vbCrLf, 
                          DateTime.Now)
        Dim stateTimer As New Timer(AddressOf statusChecker.CheckStatus, 
                                    autoEvent, 1000, 250)

        ' When autoEvent signals, change the period to every half second.
        autoEvent.WaitOne()
        stateTimer.Change(0, 500)
        Console.WriteLine(vbCrLf & "Changing period to .5 seconds." & vbCrLf)

        ' When autoEvent signals the second time, dispose of the timer.
        autoEvent.WaitOne()
        stateTimer.Dispose()
        Console.WriteLine(vbCrLf & "Destroying timer.")
    End Sub
End Module

Public Class StatusChecker
    Dim invokeCount, maxCount As Integer 

    Sub New(count As Integer)
        invokeCount  = 0
        maxCount = count
    End Sub

    ' The timer callback method.
    Sub CheckStatus(stateInfo As Object)
        Dim autoEvent As AutoResetEvent = DirectCast(stateInfo, AutoResetEvent)
        invokeCount += 1
        Console.WriteLine("{0:h:mm:ss.fff} Checking status {1,2}.", 
                          DateTime.Now, invokeCount)
        If invokeCount = maxCount Then
            ' Reset the counter and signal the waiting thread.
            invokeCount = 0
            autoEvent.Set()
        End If
    End Sub
End Class
' The example displays output like the following:
'       11:59:54.202 Creating timer.
'       
'       11:59:55.217 Checking status  1.
'       11:59:55.466 Checking status  2.
'       11:59:55.716 Checking status  3.
'       11:59:55.968 Checking status  4.
'       11:59:56.218 Checking status  5.
'       11:59:56.470 Checking status  6.
'       11:59:56.722 Checking status  7.
'       11:59:56.972 Checking status  8.
'       11:59:57.223 Checking status  9.
'       11:59:57.473 Checking status 10.
'       
'       Changing period to .5 seconds.
'       
'       11:59:57.474 Checking status  1.
'       11:59:57.976 Checking status  2.
'       11:59:58.476 Checking status  3.
'       11:59:58.977 Checking status  4.
'       11:59:59.477 Checking status  5.
'       11:59:59.977 Checking status  6.
'       12:00:00.478 Checking status  7.
'       12:00:00.980 Checking status  8.
'       12:00:01.481 Checking status  9.
'       12:00:01.981 Checking status 10.
'       
'       Destroying timer.
' </Snippet1>