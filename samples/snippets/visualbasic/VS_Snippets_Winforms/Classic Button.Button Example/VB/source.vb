Option Explicit
Option Strict

Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    ' <Snippet1>
    Private Sub InitializeMyButton()
        ' Create and initialize a Button.
        Dim button1 As New Button()
        
        ' Set the button to return a value of OK when clicked.
        button1.DialogResult = DialogResult.OK
        
        ' Add the button to the form.
        Controls.Add(button1)
    End Sub 'InitializeMyButton
    ' </Snippet1>
End Class 'Form1 
