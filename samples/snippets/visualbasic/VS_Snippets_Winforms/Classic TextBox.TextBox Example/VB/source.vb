Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
    Public Sub CreateMyTextBoxControl()
        ' Create a new TextBox control using this constructor.
        Dim textBox1 As New TextBox()
        ' Assign a string of text to the new TextBox control.
        textBox1.Text = "Hello World!"

        ' Code goes here to add the control to the form's control collection.
    End Sub

' </Snippet1>
End Class
