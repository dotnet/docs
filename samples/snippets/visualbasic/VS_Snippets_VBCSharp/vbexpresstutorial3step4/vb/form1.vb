Public Class Form1

    ' These Integers will store the numbers
    ' for the addition problem.
    Private addend1 As Integer
    Private addend2 As Integer


    'This will keep track of the time left
    Private timeLeft As Integer

    ' <snippet10>
    Private Sub Timer1_Tick() Handles Timer1.Tick

        If CheckTheAnswer() Then
            ' If CheckTheAnswer() returns true, then the user 
            ' got the answer right. Stop the timer  
            ' and show a MessageBox.
            Timer1.Stop()
            MessageBox.Show("You got all of the answers right!", "Congratulations!")
            startButton.Enabled = True
        ElseIf timeLeft > 0 Then
            ' If CheckTheAnswer() return false, keep counting
            ' down. Decrease the time left by one second and 
            ' display the new time left by updating the 
            ' Time Left label.
            timeLeft -= 1
            timeLabel.Text = timeLeft & " seconds"
        Else
            ' If the user ran out of time, stop the timer, show 
            ' a MessageBox, and fill in the answers.
            Timer1.Stop()
            timeLabel.Text = "Time's up!"
            MessageBox.Show("You didn't finish in time.", "Sorry!")
            sum.Value = addend1 + addend2
            startButton.Enabled = True
        End If

    End Sub
    ' </snippet10>
    Public Function CheckTheAnswer() As Boolean
	Return False
    End Function



End Class

Public Class Form2

    ' These Integers will store the numbers
    ' for the addition problem.
    Private addend1 As Integer
    Private addend2 As Integer

    ' <snippet8>
    ''' <summary>
    ''' Check the answer to see if the user got everything right.
    ''' </summary>
    ''' <returns>True if the answer's correct, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function CheckTheAnswer() As Boolean

        If addend1 + addend2 = sum.Value Then
            Return True
        Else
            Return False
        End If

    End Function
    ' </snippet8>

End Class



Public Class Form3

    'This will keep track of the time left
    Private timeLeft As Integer

    Private Sub Timer1_Tick() Handles Timer1.Tick
        ' <snippet9>
        If CheckTheAnswer() Then
            ' statements that will get executed
            ' if the answer is correct 
        ElseIf timeLeft > 0 Then
            ' statements that will get executed
            ' if there's still time left on the timer
        Else
            ' statements that will get executed if the timer ran out
        End If
        ' </snippet9>
    End Sub

    Public Function CheckTheAnswer() As Boolean
        Return False
    End Function

End Class






