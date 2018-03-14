Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    ' <Snippet1>
    Private Sub Command_Button_Click(sender As Object, e As CommandEventArgs)
        Dim args2 As New CommandEventArgs("Sort", "Descending")
    End Sub 'Command_Button_Click
    ' </Snippet1>
End Class 'Form1 
