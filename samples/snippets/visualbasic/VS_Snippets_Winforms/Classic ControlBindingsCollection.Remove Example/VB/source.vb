Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected textBox1 As TextBox    
    
' <Snippet1>
 Private Sub RemoveBackColorBinding()
     Dim colorBinding As Binding = textBox1.DataBindings("BackColor")
     textBox1.DataBindings.Remove(colorBinding)
 End Sub
' </Snippet1>
End Class
