Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Public Sub CreateMyBorderlesWindow()
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        StartPosition = FormStartPosition.CenterScreen
        ' Remove the control box so the form will only display client area.
        ControlBox = False
    End Sub 'CreateMyBorderlesWindow
' </Snippet1>
End Class 'Form1 
