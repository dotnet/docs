' <snippet1>
Public Class Form1

    ' Create a Random object called randomizer 
    ' to generate random numbers.
    Private randomizer As New Random
    ' </snippet1>

    ' These integer variables store the numbers 
    ' for the addition problem. 
    Private addend1 As Integer
    Private addend2 As Integer

    ' <snippet4>
    ' Call the StartTheQuiz() method and enable
    ' the Start button. 
    Private Sub startButton_Click() Handles startButton.Click
        StartTheQuiz()
        startButton.Enabled = False
    End Sub
    ' </snippet4>

    Public Sub StartTheQuiz()

    End Sub

End Class

Public Class Form2

    ' <snippet2>
    ' Create a Random object called randomizer 
    ' to generate random numbers.
    Private randomizer As New Random

    ' These integer variables store the numbers 
    ' for the addition problem. 
    Private addend1 As Integer
    Private addend2 As Integer
    ' </snippet2>

    ' <snippet3>
    ''' <summary>
    ''' Start the quiz by filling in all of the problems
    ''' and starting the timer.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartTheQuiz()
        ' Fill in the addition problem.
        ' Generate two random numbers to add.
        ' Store the values in the variables 'addend1' and 'addend2'.
        addend1 = randomizer.Next(51)
        addend2 = randomizer.Next(51)

        ' <snippet18>
        ' Convert the two randomly generated numbers
        ' into strings so that they can be displayed
        ' in the label controls.
        plusLeftLabel.Text = addend1.ToString()
        plusRightLabel.Text = addend2.ToString()
        ' </snippet18>

        ' 'sum' is the name of the NumericUpDown control.
        ' This step makes sure its value is zero before
        ' adding any values to it.
        sum.Value = 0
    End Sub
    ' </snippet3>

End Class