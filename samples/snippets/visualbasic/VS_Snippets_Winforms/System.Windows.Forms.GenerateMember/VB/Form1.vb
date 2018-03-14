 ' <snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
   
   Public Sub New()
      InitializeComponent()
    End Sub
   
   ' <snippet2>
    ' The Modifiers property for button1 is "Private".
    Private button1 As Button
   
    ' The Modifiers property for button2 is "Protected".
    Protected button2 As Button
   
   ' button3 is not a member, because 
   ' its GenerateMember property is false.
    ' </snippet2>

    ' <summary>
    ' Required designer variable.
    ' </summary>
    Private components As System.ComponentModel.IContainer = Nothing
   
   
    ' <summary>
    ' Clean up any resources being used.
    ' </summary>
    ' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
   
#Region "Windows Form Designer generated code"

    ' <snippet3>
    Private Sub InitializeComponent()

        ' button3 is declared in a local scope, because 
        ' its GenerateMember property is false.
        Dim button3 As System.Windows.Forms.Button
        Me.button1 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        button3 = New System.Windows.Forms.Button()
        ' </snippet3>
        Me.SuspendLayout()
        ' 
        ' button1
        ' 
        Me.button1.Location = New System.Drawing.Point(12, 12)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 0
        Me.button1.Text = "button1"
        ' 
        ' button2
        ' 
        Me.button2.Location = New System.Drawing.Point(12, 41)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(75, 23)
        Me.button2.TabIndex = 1
        Me.button2.Text = "button2"
        ' 
        ' button3
        ' 
        button3.Location = New System.Drawing.Point(12, 70)
        button3.Name = "button3"
        button3.Size = New System.Drawing.Size(75, 23)
        button3.TabIndex = 2
        button3.Text = "button3"
        ' 
        ' Form1
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(104, 109)
        Me.Controls.Add(button3)
        Me.Controls.Add(button2)
        Me.Controls.Add(button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub

#End Region

End Class


Class Program

    ' <summary>
    ' The main entry point for the application.
    ' </summary>
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>