' The following code example demonstrates another use of the 
' Form.SetDesktopLocation and Form.Activate members, 
' and demonstrates handling the Form.Load and Form.Activate 
' events.

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(104, 80)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 56)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Click me for an new inactivated form."
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(104, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(104, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 40)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Label2"
        Me.Label2.AutoSize = True
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    ' <snippet1>
    Shared x As Integer = 200
    Shared y As Integer = 200

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Create a new Form1 and set its Visible property to true.
        Dim form2 As New Form1
        form2.Visible = True

        ' Set the new form's desktop location so it appears below and 
        ' to the right of the current form.
        form2.SetDesktopLocation(x, y)
        x += 30
        y += 30

        ' Keep the current form active by calling the Activate method.
        Me.Activate()
        Me.Button1.Enabled = False
    End Sub



    ' Updates the label text to reflect the current values of x and y, 
    ' which was were incremented in the Button1 control's click event.
    Private Sub Form1_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated
        Label1.Text = "x: " & x & " y: " & y
        Label2.Text = "Number of forms currently open: " & count
    End Sub

    Shared count As Integer = 0

    Private Sub Form1_Closed(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.Closed
        count -= 1
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load
        count += 1
    End Sub
    '</snippet1>

End Class
