Public Class Form1

'<Snippet1>
  Public Sub waitFiveSeconds()
      '<Snippet2>
      If TimeOfDay >= #11:59:55 PM# Then
          MsgBox("The current time is within 5 seconds of midnight" & 
              vbCrLf & "The timer returns to 0.0 at midnight")
          Return
      End If
      '</Snippet2>
      Dim start, finish, totalTime As Double
      If (MsgBox("Press Yes to pause for 5 seconds", MsgBoxStyle.YesNo)) =
           MsgBoxResult.Yes Then

          start = Microsoft.VisualBasic.DateAndTime.Timer
          ' Set end time for 5-second duration.
          finish = start + 5.0
          '<Snippet3>
          Do While Microsoft.VisualBasic.DateAndTime.Timer < finish
          ' Do other processing while waiting for 5 seconds to elapse.
          Loop
          '</Snippet3>
          totalTime = Microsoft.VisualBasic.DateAndTime.Timer - start
          MsgBox("Paused for " & totalTime & " seconds")
      End If
  End Sub
'</Snippet1>

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    waitFiveSeconds()
  End Sub

End Class
