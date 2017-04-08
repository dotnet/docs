
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
        Me.textBox1.Location = New System.Drawing.Point(120, 80)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.TabIndex = 0
        Me.textBox1.Text = ""
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(464, 326)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1})
        Me.KeyPreview = True
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


    Private Sub textBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles textBox1.MouseUp
    End Sub 'textBox1_MouseUp



    '<Snippet1>
    ' This example demonstrates how to use the KeyUp event with the Help class to display
    ' pop-up style help to the user of the application. When the user presses F1, the Help
    ' class displays a pop-up window, similar to a ToolTip, near the control. This example assumes
    ' that a TextBox control, named textBox1, has been added to the form and its KeyUp
    ' event has been contected to this event handler method.
    Private Sub textBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles textBox1.KeyUp
        ' Determine whether the key entered is the F1 key. Display help if it is.
        If e.KeyCode = Keys.F1 Then
            ' Display a pop-up help topic to assist the user.
            Help.ShowPopup(textBox1, "Enter your first name", New Point(textBox1.Right, Me.textBox1.Bottom))
        End If
    End Sub 'textBox1_KeyUp
    '</Snippet1>
End Class