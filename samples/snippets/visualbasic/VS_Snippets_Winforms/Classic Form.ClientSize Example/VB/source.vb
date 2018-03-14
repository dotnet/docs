Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected button1 As Button
    
    ' <Snippet1>
    Private Sub MyForm_Resize(sender As Object, e As EventHandler)
        ' Set the size of button1 to the size of the client area of the form.
        button1.Size = Me.ClientSize
    End Sub 'MyForm_Resize
    ' </Snippet1>
End Class 'Form1 

