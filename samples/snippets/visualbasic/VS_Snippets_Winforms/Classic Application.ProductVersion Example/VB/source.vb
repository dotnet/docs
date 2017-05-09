Imports System
Imports System.Windows.Forms

Public Class Form1
 Inherits Form
 
 Protected textBox1 As TextBox
 
' <Snippet1>
 Private Sub PrintProductVersion()
    textBox1.Text = "The product version is: " & _
       Application.ProductVersion
 End Sub

' </Snippet1>
End Class

