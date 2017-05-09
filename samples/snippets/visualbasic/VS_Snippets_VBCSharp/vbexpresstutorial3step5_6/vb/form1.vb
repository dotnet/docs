' <snippet12>
Public Class Form1

    ' Create a Random object called randomizer 
    ' to generate random numbers.
    Private randomizer As New Random

    ' These integer variables store the numbers 
    ' for the addition problem. 
    Private addend1 As Integer
    Private addend2 As Integer

    ' These integer variables store the numbers 
    ' for the subtraction problem. 
    Private minuend As Integer
    Private subtrahend As Integer

    ' This integer variable keeps track of the 
    ' remaining time.
    Private timeLeft As Integer
    ' </snippet12>

    ' <snippet11>
    ''' <summary> 
    ''' Modify the behavior of the NumericUpDown control
    ''' to make it easier to enter numeric values for
    ''' the quiz.
    ''' </summary> 
    Private Sub answer_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sum.Enter

        ' Select the whole answer in the NumericUpDown control.
        Dim answerBox = TryCast(sender, NumericUpDown)

        If answerBox IsNot Nothing Then
            Dim lengthOfAnswer = answerBox.Value.ToString().Length
            answerBox.Select(0, lengthOfAnswer)
        End If

    End Sub
    ' </snippet11>

    ' <snippet13>
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

        ' Fill in the subtraction problem.
        minuend = randomizer.Next(1, 101)
        subtrahend = randomizer.Next(1, minuend)
        minusLeftLabel.Text = minuend.ToString()
        minusRightLabel.Text = subtrahend.ToString()
        difference.Value = 0

        ' Start the timer.
        timeLeft = 30
        timeLabel.Text = "30 seconds"
        Timer1.Start()

    End Sub
    ' </snippet13>

    ' <snippet14>
    ''' <summary>
    ''' Check the answers to see if the user got everything right.
    ''' </summary>
    ''' <returns>True if the answer's correct, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function CheckTheAnswer() As Boolean

        If addend1 + addend2 = sum.Value AndAlso 
           minuend - subtrahend = difference.Value Then

            Return True
        Else
            Return False
        End If

    End Function
    ' </snippet14>

    Public Sub Temp()

        ' <snippet21>
        minuend = randomizer.Next(1, 101)
        ' </snippet21>

    End Sub

    Private Sub Timer1_Tick() Handles Timer1.Tick

        If (timeLeft > 0) Then
            ' If CheckTheAnswer() return false, keep counting
            ' down. Decrease the time left by one second and 
            ' display the new time left by updating the 
            ' Time Left label.
            timeLeft -= 1
            timeLabel.Text = timeLeft & " seconds"

            ' <snippet22>
        Else
            ' If the user ran out of time, stop the timer, show 
            ' a MessageBox, and fill in the answers.
            Timer1.Stop()
            timeLabel.Text = "Time's up!"
            MessageBox.Show("You didn't finish in time.", "Sorry!")
            sum.Value = addend1 + addend2
            difference.Value = minuend - subtrahend
            startButton.Enabled = True
        End If
        ' </snippet22>
    End Sub

End Class