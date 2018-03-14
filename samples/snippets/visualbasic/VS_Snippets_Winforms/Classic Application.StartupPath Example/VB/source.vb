Imports System
Imports System.Windows.Forms

Public Class Form1
 Inherits Form
 Protected textBox1 As TextBox
 
' <Snippet1>
 Private Sub PrintStartupPath()
    textBox1.Text = "The path for the executable file that " & _
       "started the application is: " & _
       Application.StartupPath
 End Sub

' </Snippet1>
End Class

