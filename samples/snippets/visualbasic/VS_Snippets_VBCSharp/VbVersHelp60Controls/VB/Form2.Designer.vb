<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
Me.ComboBox1 = New System.Windows.Forms.ComboBox
Me.Label1 = New System.Windows.Forms.Label
Me.Button1 = New System.Windows.Forms.Button
Me.TextBox1 = New System.Windows.Forms.TextBox
Me.SuspendLayout()
'
'ComboBox1
'
Me.ComboBox1.FormattingEnabled = True
Me.ComboBox1.Location = New System.Drawing.Point(32, 50)
Me.ComboBox1.Name = "ComboBox1"
Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
Me.ComboBox1.TabIndex = 0
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(32, 13)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(39, 13)
Me.Label1.TabIndex = 1
Me.Label1.Text = "Label1"
'
'Button1
'
Me.Button1.Location = New System.Drawing.Point(32, 110)
Me.Button1.Name = "Button1"
Me.Button1.Size = New System.Drawing.Size(75, 23)
Me.Button1.TabIndex = 2
Me.Button1.Text = "Button1"
'
'TextBox1
'
Me.TextBox1.Location = New System.Drawing.Point(35, 167)
Me.TextBox1.Name = "TextBox1"
Me.TextBox1.Size = New System.Drawing.Size(100, 20)
Me.TextBox1.TabIndex = 3
'
'Form2
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(292, 266)
Me.Controls.Add(Me.TextBox1)
Me.Controls.Add(Me.Button1)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.ComboBox1)
Me.Name = "Form2"
Me.Text = "Form2"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
