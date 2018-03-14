Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected button1 As Button
    Protected panel1 As Panel
    
    Protected myCounter As Integer   
    
' <Snippet1>
    Private Sub SetDockPadding()
        ' Dock the button in the panel.
        button1.Dock = System.Windows.Forms.DockStyle.Fill
        
        ' Reset the counter if it is greater than 5.
        If myCounter > 5 Then
            myCounter = 0
        End If
        
        ' Set the appropriate DockPadding and display
        ' which one was set on the button face.
        Select Case myCounter
            Case 0
                panel1.DockPadding.All = 0
                button1.Text = "Start"
            Case 1
                panel1.DockPadding.Top = 10
                button1.Text = "Top"
            Case 2
                panel1.DockPadding.Bottom = 10
                button1.Text = "Bottom"
            Case 3
                panel1.DockPadding.Left = 10
                button1.Text = "Left"
            Case 4
                panel1.DockPadding.Right = 10
                button1.Text = "Right"
            Case 5
                panel1.DockPadding.All = 20
                button1.Text = "All"
        End Select
        
        ' Increment the counter.
        myCounter += 1
    End Sub

' </Snippet1>
End Class

