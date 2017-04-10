Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Location = New System.Drawing.Point(13, 23)
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        ' Me.MaskedTextBox1.Text = ""
        Me.MaskedTextBox1.Size = New System.Drawing.Size(262, 20)
        Me.MaskedTextBox1.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(399, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(696, 73)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MaskedTextBox1)
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
