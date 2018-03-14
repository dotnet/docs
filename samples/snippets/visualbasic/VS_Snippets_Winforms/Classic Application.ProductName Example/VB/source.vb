Imports System
Imports System.Windows.Forms

Public Class Form1
 Inherits Form
 
 Protected textBox1 As TextBox
 
' <Snippet1>
 Private Sub PrintProductName()
    textBox1.Text = "The product name is: " & _
       Application.ProductName
 End Sub

' </Snippet1>
End Class

