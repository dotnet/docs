Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected textBox1 As TextBox    
    
' <Snippet1>
 Private Sub RemoveThirdBinding()
     If textBox1.DataBindings.Count < 3 Then
         Return
     End If
     textBox1.DataBindings.RemoveAt(2)
 End Sub
' </Snippet1>
End Class
