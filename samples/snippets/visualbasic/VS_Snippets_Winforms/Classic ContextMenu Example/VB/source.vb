Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected pictureBox1 As TextBox
    
    Protected contextMenu1 As ContextMenu
    
    ' <Snippet1>
    Private Sub MyPopupEventHandler(sender As System.Object, e As System.EventArgs)
        ' Define the MenuItem objects to display for the TextBox.
        Dim menuItem1 As New MenuItem("&Copy")
        Dim menuItem2 As New MenuItem("&Find and Replace")
        ' Define the MenuItem object to display for the PictureBox.
        Dim menuItem3 As New MenuItem("C&hange Picture")
        
        ' Clear all previously added MenuItems.
        contextMenu1.MenuItems.Clear()
        
        If contextMenu1.SourceControl Is textBox1 Then
            ' Add MenuItems to display for the TextBox.
            contextMenu1.MenuItems.Add(menuItem1)
            contextMenu1.MenuItems.Add(menuItem2)
        ElseIf contextMenu1.SourceControl Is pictureBox1 Then
            ' Add the MenuItem to display for the PictureBox.
            contextMenu1.MenuItems.Add(menuItem3)
        End If
    End Sub 'MyPopupEventHandler '
    ' </Snippet1>
End Class 'Form1