Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form    
    
' <Snippet1>
 Public Sub CreateMyPasswordTextBox()
     ' Create an instance of the TextBox control.
     Dim textBox1 As New TextBox()
     ' Set the maximum length of text in the control to eight.
     textBox1.MaxLength = 8
     ' Assign the asterisk to be the password character.
     textBox1.PasswordChar = "*"c
     ' Change all text entered to be uppercase.
     textBox1.CharacterCasing = CharacterCasing.Upper
     ' Align the text in the center of the TextBox control.
     textBox1.TextAlign = HorizontalAlignment.Center
 End Sub
' </Snippet1>
End Class
