<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class LookupBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
Me.DisplayMemberBox = New System.Windows.Forms.TextBox
Me.ValueMemberBox = New System.Windows.Forms.TextBox
Me.SelectedValueBox = New System.Windows.Forms.TextBox
Me.ComboBox1 = New System.Windows.Forms.ComboBox
Me.SuspendLayout()
'
'DisplayMemberBox
'
Me.DisplayMemberBox.Location = New System.Drawing.Point(4, 4)
Me.DisplayMemberBox.Name = "DisplayMemberBox"
Me.DisplayMemberBox.Size = New System.Drawing.Size(100, 20)
Me.DisplayMemberBox.TabIndex = 0
'
'ValueMemberBox
'
Me.ValueMemberBox.AcceptsReturn = True
Me.ValueMemberBox.Location = New System.Drawing.Point(4, 31)
Me.ValueMemberBox.Name = "ValueMemberBox"
Me.ValueMemberBox.Size = New System.Drawing.Size(100, 20)
Me.ValueMemberBox.TabIndex = 1
'
'SelectedValueBox
'
Me.SelectedValueBox.Location = New System.Drawing.Point(4, 58)
Me.SelectedValueBox.Name = "SelectedValueBox"
Me.SelectedValueBox.Size = New System.Drawing.Size(100, 20)
Me.SelectedValueBox.TabIndex = 2
'
'ComboBox1
'
Me.ComboBox1.FormattingEnabled = True
Me.ComboBox1.Location = New System.Drawing.Point(4, 96)
Me.ComboBox1.Name = "ComboBox1"
Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
Me.ComboBox1.TabIndex = 3
'
'LookupBox
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.Controls.Add(Me.ComboBox1)
Me.Controls.Add(Me.SelectedValueBox)
Me.Controls.Add(Me.ValueMemberBox)
Me.Controls.Add(Me.DisplayMemberBox)
Me.Name = "LookupBox"
Me.Size = New System.Drawing.Size(176, 195)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents DisplayMemberBox As System.Windows.Forms.TextBox
    Friend WithEvents ValueMemberBox As System.Windows.Forms.TextBox
    Friend WithEvents SelectedValueBox As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox

End Class
