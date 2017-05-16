' <snippet5>
Public Class Form1

    ' Create a Random object called randomizer 
    ' to generate random numbers.
    Private randomizer As New Random

    ' These integer variables store the numbers 
    ' for the addition problem. 
    Private addend1 As Integer
    Private addend2 As Integer

    ' This integer variable keeps track of the 
    ' remaining time.
    Private timeLeft As Integer
    ' </snippet5>

    ' <snippet6>
    Private Sub Timer1_Tick() Handles Timer1.Tick

        If timeLeft > 0 Then
            ' Display the new time left
            ' by updating the Time Left label.
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
    ' </snippet6>

    ' <snippet7>
    ''' <summary>
    ''' Start the quiz by filling in all of the problem 
    ''' values and starting the timer. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartTheQuiz()

        ' Fill in the addition problem.
        ' Generate two random numbers to add.
        ' Store the values in the variables 'addend1' and 'addend2'.
        addend1 = randomizer.Next(51)
        addend2 = randomizer.Next(51)

        ' Convert the two randomly generated numbers
        ' into strings so that they can be displayed
        ' in the label controls.
        plusLeftLabel.Text = addend1.ToString()
        plusRightLabel.Text = addend2.ToString()

        ' 'sum' is the name of the NumericUpDown control.
        ' This step makes sure its value is zero before
        ' adding any values to it.
        sum.Value = 0

        ' Start the timer.
        timeLeft = 30
        timeLabel.Text = "30 seconds"
        Timer1.Start()

    End Sub
    ' </snippet7>


    Private Sub Temp()
        ' <snippet24>
        sum.Value = addend1 + addend2
        ' </snippet24>
    End Sub

End Class




