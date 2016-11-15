        Private Sub Form1_Load() Handles MyBase.Load
            Button1.Text = "Start"
            mText = New TimerState
        End Sub
        Private Sub Button1_Click() Handles Button1.Click
            mText.StartCountdown(10.0, 0.1)
        End Sub

        Private Sub mText_ChangeText() Handles mText.Finished
            TextBox1.Text = "Done"
        End Sub

        Private Sub mText_UpdateTime(ByVal Countdown As Double
          ) Handles mText.UpdateTime

            TextBox1.Text = Format(Countdown, "##0.0")
            ' Use DoEvents to allow the display to refresh.
            My.Application.DoEvents()
        End Sub

        Class TimerState
            Public Event UpdateTime(ByVal Countdown As Double)
            Public Event Finished()
            Public Sub StartCountdown(ByVal Duration As Double, 
                                      ByVal Increment As Double)
                Dim Start As Double = DateAndTime.Timer
                Dim ElapsedTime As Double = 0

                Dim SoFar As Double = 0
                Do While ElapsedTime < Duration
                    If ElapsedTime > SoFar + Increment Then
                        SoFar += Increment
                        RaiseEvent UpdateTime(Duration - SoFar)
                    End If
                    ElapsedTime = DateAndTime.Timer - Start
                Loop
                RaiseEvent Finished()
            End Sub
        End Class