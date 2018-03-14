Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    ' <Snippet1>
    Private Sub InitializeMyScrollBar()
        ' Create and initialize an HScrollBar.
        Dim hScrollBar1 As New HScrollBar()
        
        ' Dock the scroll bar to the bottom of the form.
        hScrollBar1.Dock = DockStyle.Bottom
        
        ' Add the scroll bar to the form.
        Controls.Add(hScrollBar1)
    End Sub 'InitializeMyScrollBar
    ' </Snippet1>
End Class 'Form1 

