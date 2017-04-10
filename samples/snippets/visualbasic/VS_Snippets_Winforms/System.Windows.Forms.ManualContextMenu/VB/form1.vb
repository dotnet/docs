' The following code example demonstrates using the 
' ContextMenu.Show() method.

Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(104, 80)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 80)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Click To See shortcut menu"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    <System.STAThreadAttribute()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub


    '<snippet1>

    ' Displays the shortcut menu, offsetting its location 
    ' from the upper-left corner of Button1 by 20 pixels in each direction. 
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        'Declare the menu items and the shortcut menu.
        Dim menuItems() As MenuItem = New MenuItem() _
            {New MenuItem("Some Button Info"), _
            New MenuItem("Some Other Button Info"), _
            New MenuItem("Exit")}

        Dim buttonMenu As New ContextMenu(menuItems)
        buttonMenu.Show(Button1, New System.Drawing.Point(20, 20))
    End Sub
    '</snippet1>

End Class
