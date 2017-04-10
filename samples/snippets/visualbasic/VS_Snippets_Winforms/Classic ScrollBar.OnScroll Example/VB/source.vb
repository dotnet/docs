Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected label1 As Label
    Protected vScrollBar1, hScrollBar1 As ScrollBar
    
' <Snippet1>
    Private Sub AddMyScrollEventHandlers()
        ' Create and initialize a VScrollBar.
        Dim vScrollBar1 As New VScrollBar()
        
        ' Add event handlers for the OnScroll and OnValueChanged events.
        AddHandler vScrollBar1.Scroll, AddressOf Me.vScrollBar1_Scroll
        AddHandler vScrollBar1.ValueChanged, AddressOf Me.vScrollBar1_ValueChanged
    End Sub    
    
    ' Create the ValueChanged event handler.
    Private Sub vScrollBar1_ValueChanged(sender As Object, e As EventArgs)
        ' Display the new value in the label.
        label1.Text = "vScrollBar Value:(OnValueChanged Event) " & _
            vScrollBar1.Value.ToString()
    End Sub    
    
    ' Create the Scroll event handler.
    Private Sub vScrollBar1_Scroll(sender As Object, e As ScrollEventArgs)
        ' Display the new value in the label.
        label1.Text = "VScrollBar Value:(OnScroll Event) " & _
            e.NewValue.ToString()
    End Sub    
    
    Private Sub button1_Click(sender As Object, e As EventArgs)
        ' Add 40 to the Value property if it will not exceed the Maximum value.
        If vScrollBar1.Value + 40 < vScrollBar1.Maximum Then
            vScrollBar1.Value = vScrollBar1.Value + 40
        End If
    End Sub

' </Snippet1>
End Class

