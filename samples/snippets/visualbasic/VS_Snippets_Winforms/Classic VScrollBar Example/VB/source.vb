Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
    Private Sub InitializeMyScrollBar()
        ' Create and initialize a VScrollBar.
        Dim vScrollBar1 As New VScrollBar()
        
        ' Dock the scroll bar to the right side of the form.
        vScrollBar1.Dock = DockStyle.Right
        
        ' Add the scroll bar to the form.
        Controls.Add(vScrollBar1)
    End Sub

' </Snippet1>    
End Class 'Form1 

