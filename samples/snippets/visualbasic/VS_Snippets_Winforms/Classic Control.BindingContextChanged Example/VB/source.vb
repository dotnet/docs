Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected textBox1 As TextBox    
    
' <Snippet1>
 Private Sub AddEventHandler()
     AddHandler textBox1.BindingContextChanged, _
        AddressOf BindingContext_Changed
 End Sub    
    
 Private Sub BindingContext_Changed(sender As Object, e As EventArgs)
     Console.WriteLine("BindingContext changed")
 End Sub
' </Snippet1>
End Class
