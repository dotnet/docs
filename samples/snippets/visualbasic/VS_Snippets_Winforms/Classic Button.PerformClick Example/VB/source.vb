Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected button2 As Button
    Protected myVar As Integer
    
    ' <Snippet1>
    Private Sub button1_Click(sender As Object, e As EventArgs)
        ' If myVar is an even number, click Button2.
        If myVar Mod 2 = 0 Then
            button2.PerformClick()
            ' Display the status of Button2's Click event.
            MessageBox.Show("button2 was clicked ")
        Else
            ' Display the status of Button2's Click event.
            MessageBox.Show("button2 was NOT clicked")
        End If
        ' Increment myVar.   
        myVar = myVar + 1
    End Sub 'button1_Click
    ' </Snippet1>
End Class 'Form1 
