Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected numericUpDown1 As NumericUpDown
    
    
' <Snippet1>
    Private Sub numericUpDown1_Leave(sender As Object, e As EventArgs)
        ' If the entered value is greater than Minimum or Maximum,
        ' select the text and open a message box. 
        If (System.Convert.ToInt32(numericUpDown1.Text) > numericUpDown1.Maximum) Or _
            (System.Convert.ToInt32(numericUpDown1.Text) < numericUpDown1.Minimum) Then
            MessageBox.Show("The value entered was not between the Minimum and " & _
                "Maximum allowable values." & Microsoft.VisualBasic.ControlChars.Cr & _
                "Please re-enter.")
            numericUpDown1.Focus()
            numericUpDown1.Select(0, numericUpDown1.Text.Length)
        End If
    End Sub    
    
    Private Sub button1_Click(sender As Object, e As EventArgs)
        Dim varPrefHeight1 As Integer
        
        ' Capture the PreferredHeight before and after the Font
        ' is changed, and display the results in a message box. 
        varPrefHeight1 = numericUpDown1.PreferredHeight
        numericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", _
            12F, System.Drawing.FontStyle.Bold)
        MessageBox.Show("Before Font Change: " & varPrefHeight1.ToString() & _
            Microsoft.VisualBasic.ControlChars.Cr & "After Font Change: " & _
            numericUpDown1.PreferredHeight.ToString())
    End Sub

' </Snippet1>
End Class

