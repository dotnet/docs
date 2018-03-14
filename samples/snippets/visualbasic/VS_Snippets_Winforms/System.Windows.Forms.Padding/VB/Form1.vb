 ' <snippet1>
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private panel1 As Panel
    Private richTextBox1 As RichTextBox

   '/ <summary>
   '/ Required designer variable.
   '/ </summary>
   Private components As System.ComponentModel.IContainer = Nothing
   
   ' <snippet2>
   ' This code example demonstrates using the Padding property to 
   ' create a border around a RichTextBox control.
   Public Sub New()
        InitializeComponent()

        Me.panel1.BackColor = System.Drawing.Color.Blue
        Me.panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill

        Me.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
    End Sub
    ' </snippet2>

   '/ <summary>
   '/ Clean up any resources being used.
   '/ </summary>
   '/ <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub
   
#Region "Windows Form Designer generated code"

    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' panel1
        ' 
        Me.panel1.Controls.Add(Me.richTextBox1)
        Me.panel1.Location = New System.Drawing.Point(20, 20)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(491, 313)
        Me.panel1.TabIndex = 0
        ' 
        ' richTextBox1
        ' 
        Me.richTextBox1.Location = New System.Drawing.Point(5, 5)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(481, 303)
        Me.richTextBox1.TabIndex = 0
        Me.richTextBox1.Text = ""
        ' 
        ' Form1
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 353)
        Me.Controls.Add(panel1)
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(20)
        Me.Text = "Form1"
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

#End Region

End Class



Public Class Program

    '/ <summary>
    '/ The main entry point for the application.
    '/ </summary>
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>