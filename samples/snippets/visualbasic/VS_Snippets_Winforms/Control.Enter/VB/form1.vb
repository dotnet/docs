
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
    Private WithEvents button1 As System.Windows.Forms.Button
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
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub 'Dispose
   

    Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        ' 
        ' button1
        ' 
        Me.button1.Location = New System.Drawing.Point(176, 32)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(80, 32)
        Me.button1.TabIndex = 0
        Me.button1.Text = "button1"
        ' 
        ' textBox1
        ' 
        Me.textBox1.Location = New System.Drawing.Point(48, 104)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(176, 20)
        Me.textBox1.TabIndex = 1
        Me.textBox1.Text = "textBox1"
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1, Me.button1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub 'InitializeComponent
    

    <STAThread()>  _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main
   
   
    Private Sub button1_Enter(sender As Object, e As System.EventArgs) Handles button1.Enter
    End Sub 'button1_Enter
   
   
   
    '<Snippet1>
    Private Sub textBox1_Enter(sender As Object, e As System.EventArgs) Handles textBox1.Enter
        ' If the TextBox contains text, change its foreground and background colors.
        If textBox1.Text <> [String].Empty Then
            textBox1.ForeColor = Color.Red
            textBox1.BackColor = Color.Black
            ' Move the selection pointer to the end of the text of the control.
            textBox1.Select(textBox1.Text.Length, 0)
        End If
    End Sub 'textBox1_Enter
   
   
    Private Sub textBox1_Leave(sender As Object, e As System.EventArgs) Handles textBox1.Leave
        ' Reset the colors and selection of the TextBox after focus is lost.
        textBox1.ForeColor = Color.Black
        textBox1.BackColor = Color.White
        textBox1.Select(0, 0)
    End Sub 'textBox1_Leave
End Class 'Form1 
'</Snippet1>
