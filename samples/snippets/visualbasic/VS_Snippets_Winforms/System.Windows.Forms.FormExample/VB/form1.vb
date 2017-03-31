' The following code example demonstrates the result of setting 
' the desktop bounds and desktop location. It also demonstates
' the Form.MaximumSize property.

Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    '<snippet3>
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Set the maximum size, so if user maximizes form, it 
        'will not cover entire desktop.  
        Me.MaximumSize = New Size(500, 500)


    End Sub
    '</snippet3>

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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(96, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Click me to see the form move"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(96, 120)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 48)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Click me to see form shrink (and move)"

        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        For i = 0 To 25

            ' With each loop through the code, the form's desktop 
            ' location is adjusted right and down by 10 pixels. 
            Me.SetDesktopLocation(Me.Location.X + 10, Me.Location.Y + 10)

            ' Call Sleep to give the effect of the form walking 
            ' across the screen. 
            System.Threading.Thread.Sleep(250)
        Next

        ' Set the location back to the upper left-hand corner of 
        ' the screen.
        Me.SetDesktopLocation(10, 10)
    End Sub
    '</snippet1>

    '<snippet2>
    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer
        For i = 0 To 20
            ' With each loop through the code, the form's desktop location is 
            ' adjusted right and down by 10 pixels and its height and width 
            ' are each decreased by 10 pixels. 
            Me.SetDesktopBounds(Me.Location.X + 10, Me.Location.Y + 10, _
                Me.Width - 10, Me.Height - 10)

            ' Call Sleep to show the form gradually shrinking.
            System.Threading.Thread.Sleep(50)
        Next
    End Sub
    '</snippet2>

End Class
