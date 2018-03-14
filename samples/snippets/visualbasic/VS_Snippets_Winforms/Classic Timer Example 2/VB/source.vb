Imports System
Imports System.Windows.Forms

'<Snippet1>
Public Class Class1
    Private Shared WithEvents myTimer As New System.Windows.Forms.Timer()
    Private Shared alarmCounter As Integer = 1
    Private Shared exitFlag As Boolean = False    
    
    ' This is the method to run when the timer is raised.
    Private Shared Sub TimerEventProcessor(myObject As Object, _
                                           ByVal myEventArgs As EventArgs) _
                                       Handles myTimer.Tick
        myTimer.Stop()
        
        ' Displays a message box asking whether to continue running the timer.
        If MessageBox.Show("Continue running?", "Count is: " & alarmCounter, _
                            MessageBoxButtons.YesNo) = DialogResult.Yes Then
            ' Restarts the timer and increments the counter.
            alarmCounter += 1
            myTimer.Enabled = True
        Else
            ' Stops the timer.
            exitFlag = True
        End If
    End Sub
    
    Public Shared Sub Main()
        ' Adds the event and the event handler for the method that will
        ' process the timer event to the timer.
        
        ' Sets the timer interval to 5 seconds.
        myTimer.Interval = 5000
        myTimer.Start()
        
        ' Runs the timer, and raises the event.
        While exitFlag = False
            ' Processes all the events in the queue.
            Application.DoEvents()
        End While

    End Sub    

End Class

'</Snippet1>
