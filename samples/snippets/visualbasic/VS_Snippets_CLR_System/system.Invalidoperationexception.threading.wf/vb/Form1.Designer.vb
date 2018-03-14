<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.threadExampleBtn = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'threadExampleBtn
        '
        Me.threadExampleBtn.Location = New System.Drawing.Point(101, 184)
        Me.threadExampleBtn.Name = "threadExampleBtn"
        Me.threadExampleBtn.Size = New System.Drawing.Size(75, 23)
        Me.threadExampleBtn.TabIndex = 0
        Me.threadExampleBtn.Text = "Button1"
        Me.threadExampleBtn.UseVisualStyleBackColor = True
        '
        'textBox1
        '
        Me.textBox1.Location = New System.Drawing.Point(12, 36)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(260, 113)
        Me.textBox1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.threadExampleBtn)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents threadExampleBtn As Button
    Friend WithEvents textBox1 As TextBox
End Class
