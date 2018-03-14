Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected toolBar1 As ToolBar
    
' <Snippet1>
    Public Sub ClearMyToolBar()
        Dim btns As Integer
        ' Get the count before the Clear method is called.
        btns = toolBar1.Buttons.Count
        toolBar1.Buttons.Clear()
        MessageBox.Show("Count Before Clear: " + btns.ToString() & _
            Microsoft.VisualBasic.ControlChars.Cr & "Count After Clear: " & _
            toolBar1.Buttons.Count.ToString())
    End Sub

' </Snippet1>
End Class

