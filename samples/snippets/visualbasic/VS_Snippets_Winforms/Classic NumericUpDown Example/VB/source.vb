Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected numericUpDown1 As NumericUpDown
    
' <Snippet1>
    Public Sub InstantiateMyNumericUpDown()
        ' Create and initialize a NumericUpDown control.
        numericUpDown1 = New NumericUpDown()
        
        ' Dock the control to the top of the form.
        numericUpDown1.Dock = System.Windows.Forms.DockStyle.Top
        
        ' Set the Minimum, Maximum, and initial Value.
        numericUpDown1.Value = 5
        numericUpDown1.Maximum = 2500
        numericUpDown1.Minimum = - 100
        
        ' Add the NumericUpDown to the Form.
        Controls.Add(numericUpDown1)
    End Sub    
    
    ' Check box to toggle decimal places to be displayed.
    Private Sub checkBox1_Click(sender As Object, e As EventArgs)
        ' If DecimalPlaces is greater than 0, set them to 0 and round the
        ' current Value; otherwise, set DecimalPlaces to 2 and change the
        ' Increment to 0.25. 
        If numericUpDown1.DecimalPlaces > 0 Then
            numericUpDown1.DecimalPlaces = 0
            numericUpDown1.Value = Decimal.Round(numericUpDown1.Value, 0)
        Else
            numericUpDown1.DecimalPlaces = 2
            numericUpDown1.Increment = 0.25D
        End If
    End Sub    
    
    ' Check box to toggle thousands separators to be displayed.
    Private Sub checkBox2_Click(sender As Object, e As EventArgs)
        ' If ThousandsSeparator is true, set it to false;
        ' otherwise, set it to true. 
        If numericUpDown1.ThousandsSeparator Then
            numericUpDown1.ThousandsSeparator = False
        Else
            numericUpDown1.ThousandsSeparator = True
        End If
    End Sub    
    
    ' Check box to toggle hexadecimal to be displayed.
    Private Sub checkBox3_Click(sender As Object, e As EventArgs)
        ' If Hexadecimal is true, set it to false;
        ' otherwise, set it to true. 
        If numericUpDown1.Hexadecimal Then
            numericUpDown1.Hexadecimal = False
        Else
            numericUpDown1.Hexadecimal = True
        End If
    End Sub

' </Snippet1>
End Class

