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
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
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
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        ' 
        ' textBox1
        ' 
        Me.textBox1.Location = New System.Drawing.Point(48, 48)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(176, 20)
        Me.textBox1.TabIndex = 0
        Me.textBox1.Text = "textBox1"
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub 'InitializeComponent


    '/ <summary>
    '/ The main entry point for the application.
    '/ </summary>
    <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main


    '<Snippet1>
    Private Sub textBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles textBox1.KeyDown
        ' Determine whether the key entered is the F1 key. If it is, display Help.
        If e.KeyCode = Keys.F1 AndAlso (e.Alt OrElse e.Control OrElse e.Shift) Then
            ' Display a pop-up Help topic to assist the user.
            Help.ShowPopup(textBox1, "Enter your name.", New Point(textBox1.Bottom, textBox1.Right))
        ElseIf e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
            ' Display a pop-up Help topic to provide additional assistance to the user.
            Help.ShowPopup(textBox1, "Enter your first name followed by your last name. Middle name is optional.", _
                 New Point(textBox1.Top, Me.textBox1.Left))
        End If
    End Sub 'textBox1_KeyDown
    '</Snippet1>
End Class 'Form1 