Option Strict
Option Explicit

Imports System
Imports System.Data
Imports System.Web.UI

Public Class Form1
    Inherits Control
    Protected writer As HtmlTextWriter
    
    
    Protected Sub Method()
        ' <Snippet1>
        If HasControls() Then
            Dim i As Integer
            For i = 0 To Controls.Count - 1
                Controls(i).RenderControl(writer)
            Next i
        End If
         ' </Snippet1>
    End Sub 'Method
End Class 'Form1
