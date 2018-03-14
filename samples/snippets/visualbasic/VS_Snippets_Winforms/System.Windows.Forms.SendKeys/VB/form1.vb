'The following code example shows the use of the 
' SendKeys.Send method.
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(96, 72)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "&Click"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(80, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Double-clicking form, clicks the button"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region


    '<snippet1>

    ' Clicking Button1 causes a message box to appear.
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        MessageBox.Show("Click here!")
    End Sub


    ' Use the SendKeys.Send method to raise the Button1 click event 
    ' and display the message box.
    Private Sub Form1_DoubleClick(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.DoubleClick

        ' Send the enter key; since the tab stop of Button1 is 0, this
        ' will trigger the click event.
        SendKeys.Send("{ENTER}")
    End Sub
    '</snippet1>


    <System.STAThreadAttribute()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
