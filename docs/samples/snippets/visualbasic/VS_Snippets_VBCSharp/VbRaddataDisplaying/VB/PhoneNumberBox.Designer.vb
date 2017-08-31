<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class PhoneNumberBox
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
Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox
Me.SuspendLayout()
'
'MaskedTextBox1
'
Me.MaskedTextBox1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
Me.MaskedTextBox1.HidePromptOnLeave = False
Me.MaskedTextBox1.Location = New System.Drawing.Point(14, 17)
Me.MaskedTextBox1.Mask = "(999) 000-0000"
Me.MaskedTextBox1.Name = "MaskedTextBox1"
Me.MaskedTextBox1.Size = New System.Drawing.Size(100, 20)
Me.MaskedTextBox1.TabIndex = 0
Me.MaskedTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
'
'PhoneNumberBox
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.Controls.Add(Me.MaskedTextBox1)
Me.Name = "PhoneNumberBox"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox

End Class
