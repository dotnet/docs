Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected richTextBox1 As RichTextBox
    
' <Snippet1>
    Public Sub ChangeMySelectionColor()
        Dim colorDialog1 As New ColorDialog()
        
        ' Set the initial color of the dialog to the current text color.
        colorDialog1.Color = richTextBox1.SelectionColor
        
        ' Determine if the user clicked OK in the dialog and that the color has
        ' changed.
        If (colorDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) _
            And Not(colorDialog1.Color.Equals(richTextBox1.SelectionColor)) Then
            
            ' Change the selection color to the user specified color.
            richTextBox1.SelectionColor = colorDialog1.Color
        End If
    End Sub

' </Snippet1>
End Class

