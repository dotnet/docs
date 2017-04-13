Imports System
Imports System.Windows.Forms

Public Class Form1
 Inherits Form
 
 Protected textBox1 As TextBox
 
' <Snippet1>
 Private Sub PrintCurrentCulture()
    textBox1.Text = "The current culture is: " & _
       Application.CurrentCulture.EnglishName
 End Sub
   
' </Snippet1>
End Class
