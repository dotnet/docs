Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected text1 As TextBox
    Protected panel1 As Panel
    
' <Snippet1>
    Private Sub MySub()
        ' If the text box is outside the panel's bounds,
        ' turn on auto-scrolling and set the margin. 
        If (text1.Location.X > panel1.Location.X) Or _
            (text1.Location.Y > panel1.Location.Y) Then
            
            panel1.AutoScroll = True            
            ' If the AutoScrollMargin is set to
            ' less than (5,5), set it to 5,5. 
            If (panel1.AutoScrollMargin.Width < 5) Or _
                (panel1.AutoScrollMargin.Height < 5) Then
                
                panel1.SetAutoScrollMargin(5, 5)
            End If
        End If
    End Sub

' </Snippet1>
End Class

