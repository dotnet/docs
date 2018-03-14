Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected comboBox1 As ComboBox
    Protected comboBox2 As ComboBox
    Protected numericUpDown1 As NumericUpDown
    
' <Snippet1>
    Private Sub comboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Set the BorderStyle property.
        Select Case comboBox1.Text
            Case "Fixed3D"
                numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Case "None"
                numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None
            Case "FixedSingle"
                numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        End Select
    End Sub    
    
    Private Sub comboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Set the TextAlign property.    
        Select Case comboBox2.Text
            Case "Right"
                numericUpDown1.TextAlign = HorizontalAlignment.Right
            Case "Left"
                numericUpDown1.TextAlign = HorizontalAlignment.Left
            Case "Center"
                numericUpDown1.TextAlign = HorizontalAlignment.Center
        End Select
    End Sub    
    
    Private Sub checkBox1_Click(sender As Object, e As EventArgs)
        ' Evaluate and toggle the ReadOnly property.
        If numericUpDown1.ReadOnly Then
            numericUpDown1.ReadOnly = False
        Else
            numericUpDown1.ReadOnly = True
        End If
    End Sub    
    
    Private Sub checkBox2_Click(sender As Object, e As EventArgs)
        ' Evaluate and toggle the InterceptArrowKeys property.
        If numericUpDown1.InterceptArrowKeys Then
            numericUpDown1.InterceptArrowKeys = False
        Else
            numericUpDown1.InterceptArrowKeys = True
        End If
    End Sub    
    
    Private Sub checkBox3_Click(sender As Object, e As EventArgs)
        ' Evaluate and toggle the UpDownAlign property.
        If numericUpDown1.UpDownAlign = LeftRightAlignment.Left Then
            numericUpDown1.UpDownAlign = LeftRightAlignment.Right
        Else
            numericUpDown1.UpDownAlign = LeftRightAlignment.Left
        End If
    End Sub

' </Snippet1>
End Class

