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
        Me.checkBox3 = New System.Windows.Forms.CheckBox
        Me.checkBox2 = New System.Windows.Forms.CheckBox
        Me.checkBox1 = New System.Windows.Forms.CheckBox
        Me.lblRichTextBox = New System.Windows.Forms.Label
        Me.lblMultilineTextBox = New System.Windows.Forms.Label
        Me.lblSingleLineTextBox = New System.Windows.Forms.Label
        Me.tbTargetMultiLine = New System.Windows.Forms.TextBox
        Me.rtbTarget = New System.Windows.Forms.RichTextBox
        Me.tbTarget = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'checkBox3
        '
        Me.checkBox3.AutoSize = True
        Me.checkBox3.Location = New System.Drawing.Point(15, 275)
        Me.checkBox3.Name = "checkBox3"
        Me.checkBox3.Size = New System.Drawing.Size(74, 17)
        Me.checkBox3.TabIndex = 19
        Me.checkBox3.Text = "Read-only"
        Me.checkBox3.UseVisualStyleBackColor = True
        '
        'checkBox2
        '
        Me.checkBox2.AutoSize = True
        Me.checkBox2.Location = New System.Drawing.Point(15, 141)
        Me.checkBox2.Name = "checkBox2"
        Me.checkBox2.Size = New System.Drawing.Size(74, 17)
        Me.checkBox2.TabIndex = 18
        Me.checkBox2.Text = "Read-only"
        Me.checkBox2.UseVisualStyleBackColor = True
        '
        'checkBox1
        '
        Me.checkBox1.AutoSize = True
        Me.checkBox1.Location = New System.Drawing.Point(15, 49)
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(74, 17)
        Me.checkBox1.TabIndex = 17
        Me.checkBox1.Text = "Read-only"
        Me.checkBox1.UseVisualStyleBackColor = True
        '
        'lblRichTextBox
        '
        Me.lblRichTextBox.AccessibleDescription = "Label for rich text TextBox"
        Me.lblRichTextBox.AccessibleName = "lblRichTextBox"
        Me.lblRichTextBox.Location = New System.Drawing.Point(12, 112)
        Me.lblRichTextBox.Name = "lblRichTextBox"
        Me.lblRichTextBox.Size = New System.Drawing.Size(94, 38)
        Me.lblRichTextBox.TabIndex = 16
        Me.lblRichTextBox.Text = "RichTextBox (rtbTarget)"
        '
        'lblMultilineTextBox
        '
        Me.lblMultilineTextBox.AccessibleDescription = "Label for multi-line TextBox"
        Me.lblMultilineTextBox.AccessibleName = "lblMultiLineTextBox"
        Me.lblMultilineTextBox.Location = New System.Drawing.Point(12, 21)
        Me.lblMultilineTextBox.Name = "lblMultilineTextBox"
        Me.lblMultilineTextBox.Size = New System.Drawing.Size(101, 50)
        Me.lblMultilineTextBox.TabIndex = 15
        Me.lblMultilineTextBox.Text = "Multi-Line TextBox (tbTargetMultiLine)"
        '
        'lblSingleLineTextBox
        '
        Me.lblSingleLineTextBox.AccessibleDescription = "Label for single line TextBox"
        Me.lblSingleLineTextBox.AccessibleName = "lblSingleLineTextBox"
        Me.lblSingleLineTextBox.Location = New System.Drawing.Point(12, 232)
        Me.lblSingleLineTextBox.Name = "lblSingleLineTextBox"
        Me.lblSingleLineTextBox.Size = New System.Drawing.Size(101, 53)
        Me.lblSingleLineTextBox.TabIndex = 14
        Me.lblSingleLineTextBox.Text = "Single Line TextBox (2 character limit) (tbTarget)"
        '
        'tbTargetMultiLine
        '
        Me.tbTargetMultiLine.AcceptsReturn = True
        Me.tbTargetMultiLine.AcceptsTab = True
        Me.tbTargetMultiLine.AccessibleDescription = "Target multi-line TextBox"
        Me.tbTargetMultiLine.AccessibleName = "mtbTarget"
        Me.tbTargetMultiLine.AllowDrop = True
        Me.tbTargetMultiLine.Location = New System.Drawing.Point(119, 21)
        Me.tbTargetMultiLine.Multiline = True
        Me.tbTargetMultiLine.Name = "tbTargetMultiLine"
        Me.tbTargetMultiLine.Size = New System.Drawing.Size(161, 73)
        Me.tbTargetMultiLine.TabIndex = 12
        Me.tbTargetMultiLine.Tag = "test"
        '
        'rtbTarget
        '
        Me.rtbTarget.AcceptsTab = True
        Me.rtbTarget.AccessibleDescription = "Target RichTextBox"
        Me.rtbTarget.AccessibleName = "rtbTarget"
        Me.rtbTarget.Location = New System.Drawing.Point(119, 112)
        Me.rtbTarget.Name = "rtbTarget"
        Me.rtbTarget.Size = New System.Drawing.Size(161, 96)
        Me.rtbTarget.TabIndex = 13
        Me.rtbTarget.Text = ""
        '
        'tbTarget
        '
        Me.tbTarget.AccessibleDescription = "Target TextBox"
        Me.tbTarget.AccessibleName = "tbTarget"
        Me.tbTarget.AllowDrop = True
        Me.tbTarget.Location = New System.Drawing.Point(119, 232)
        Me.tbTarget.MaxLength = 2
        Me.tbTarget.Name = "tbTarget"
        Me.tbTarget.Size = New System.Drawing.Size(161, 20)
        Me.tbTarget.TabIndex = 11
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 312)
        Me.Controls.Add(Me.checkBox3)
        Me.Controls.Add(Me.checkBox2)
        Me.Controls.Add(Me.checkBox1)
        Me.Controls.Add(Me.lblRichTextBox)
        Me.Controls.Add(Me.lblMultilineTextBox)
        Me.Controls.Add(Me.lblSingleLineTextBox)
        Me.Controls.Add(Me.tbTargetMultiLine)
        Me.Controls.Add(Me.rtbTarget)
        Me.Controls.Add(Me.tbTarget)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents checkBox3 As System.Windows.Forms.CheckBox
    Private WithEvents checkBox2 As System.Windows.Forms.CheckBox
    Private WithEvents checkBox1 As System.Windows.Forms.CheckBox
    Private WithEvents lblRichTextBox As System.Windows.Forms.Label
    Private WithEvents lblMultilineTextBox As System.Windows.Forms.Label
    Private WithEvents lblSingleLineTextBox As System.Windows.Forms.Label
    Private WithEvents tbTargetMultiLine As System.Windows.Forms.TextBox
    Private WithEvents rtbTarget As System.Windows.Forms.RichTextBox
    Private WithEvents tbTarget As System.Windows.Forms.TextBox

End Class
