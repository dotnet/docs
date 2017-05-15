<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.btnReload = New System.Windows.Forms.Button
        Me.tbStatus = New System.Windows.Forms.TextBox
        Me.btnReset = New System.Windows.Forms.Button
        Me.colorDialog1 = New System.Windows.Forms.ColorDialog
        Me.btnBackColor = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnReload
        '
        Me.btnReload.Location = New System.Drawing.Point(12, 42)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(75, 23)
        Me.btnReload.TabIndex = 0
        Me.btnReload.Text = "Reload"
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'tbStatus
        '
        Me.tbStatus.Location = New System.Drawing.Point(12, 83)
        Me.tbStatus.Name = "tbStatus"
        Me.tbStatus.Size = New System.Drawing.Size(266, 20)
        Me.tbStatus.TabIndex = 1
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(108, 42)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 2
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnBackColor
        '
        Me.btnBackColor.Location = New System.Drawing.Point(203, 42)
        Me.btnBackColor.Name = "btnBackColor"
        Me.btnBackColor.Size = New System.Drawing.Size(75, 23)
        Me.btnBackColor.TabIndex = 3
        Me.btnBackColor.Text = "Back Color"
        Me.btnBackColor.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 151)
        Me.Controls.Add(Me.btnBackColor)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.tbStatus)
        Me.Controls.Add(Me.btnReload)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnReload As System.Windows.Forms.Button
    Friend WithEvents tbStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents colorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents btnBackColor As System.Windows.Forms.Button

End Class
