Imports System
Imports System.Windows.Forms

Public Class Form1
 Inherits Form
 Protected textBox1 As TextBox
' <Snippet1>
 Private Sub PrintCurrentInputLanguage()
    textBox1.Text = "The current input language is: " & _
       Application.CurrentInputLanguage.Culture.EnglishName
 End Sub
   
' </Snippet1>
End Class
