Imports System
Imports System.Windows.Forms

Public Class Form1
 Inherits Form
 Protected textBox1 As TextBox
 
' <Snippet1>
 Private Sub PrintCompanyName()
    textBox1.Text = "The company name is: " & _
       Application.CompanyName
 End Sub
   
' </Snippet1>
End Class
