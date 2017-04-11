
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


'/ <summary>
'/ Summary description for Form1.
'/ </summary>

Public Class Form1
    Inherits System.Windows.Forms.Form
    '/ <summary>
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.Container = Nothing
   
   
    Public Sub New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()
    End Sub 'New
    
   
    '/ <summary>
    '/ Clean up any resources being used.
    '/ </summary>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub 'Dispose
   
   
    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent()
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(344, 270)
        Me.Name = "Form1"
        Me.Text = "Form1"
    End Sub 'InitializeComponent
   
   
    '/ <summary>
    '/ The main entry point for the application.
    '/ </summary>
    <STAThread()>  _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main
   
   
    Private Sub Form1_Resize(sender As Object, e As System.EventArgs) Handles MyBase.Resize
    End Sub 'Form1_Resize
   
   
    '<Snippet1>
    ' The following example displays the location of the form in screen coordinates
    ' on the caption bar of the form.
    Private Sub Form1_Move(sender As Object, e As System.EventArgs) Handles MyBase.Move
        Me.Text = "Form screen position = " + Me.Location.ToString()
    End Sub
   '</Snippet1>
End Class 'Form1 
