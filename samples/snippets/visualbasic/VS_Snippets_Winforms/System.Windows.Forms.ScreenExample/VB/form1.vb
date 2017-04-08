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
        Me.Button1.Location = New System.Drawing.Point(112, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Resize form"
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
    '<snippet1>
    ' This method will adjust the size of the form to utilize 
    ' the working area of the screen.

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Retrieve the working rectangle from the Screen class
        ' using the PrimaryScreen and the WorkingArea properties. 
        Dim workingRectangle As System.Drawing.Rectangle = _
            Screen.PrimaryScreen.WorkingArea

        ' Set the size of the form slightly less than size of 
        ' working rectangle.
        Me.Size = New System.Drawing.Size(workingRectangle.Width - 10, _
            workingRectangle.Height - 10)

        ' Set the location so the entire form is visible.
        Me.Location = New System.Drawing.Point(5, 5)

    End Sub
    '</snippet1>

      <System.STAThreadAttribute()>Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class
