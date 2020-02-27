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
        Me.resultLabel = New System.Windows.Forms.Label()
        Me.startAsyncButton = New System.Windows.Forms.Button()
        Me.cancelAsyncButton = New System.Windows.Forms.Button()
        Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'resultLabel
        '
        Me.resultLabel.AutoSize = True
        Me.resultLabel.Location = New System.Drawing.Point(27, 20)
        Me.resultLabel.Name = "resultLabel"
        Me.resultLabel.Size = New System.Drawing.Size(58, 13)
        Me.resultLabel.TabIndex = 0
        Me.resultLabel.Text = "resultLabel"
        '
        'startAsyncButton
        '
        Me.startAsyncButton.Location = New System.Drawing.Point(26, 51)
        Me.startAsyncButton.Name = "startAsyncButton"
        Me.startAsyncButton.Size = New System.Drawing.Size(75, 23)
        Me.startAsyncButton.TabIndex = 1
        Me.startAsyncButton.Text = "Start"
        Me.startAsyncButton.UseVisualStyleBackColor = True
        '
        'cancelAsyncButton
        '
        Me.cancelAsyncButton.Location = New System.Drawing.Point(126, 51)
        Me.cancelAsyncButton.Name = "cancelAsyncButton"
        Me.cancelAsyncButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelAsyncButton.TabIndex = 2
        Me.cancelAsyncButton.Text = "Cancel"
        Me.cancelAsyncButton.UseVisualStyleBackColor = True
        '
        'backgroundWorker1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(231, 93)
        Me.Controls.Add(Me.cancelAsyncButton)
        Me.Controls.Add(Me.startAsyncButton)
        Me.Controls.Add(Me.resultLabel)
        Me.Name = "Form1"
        Me.Text = "BackgroundWorker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents resultLabel As System.Windows.Forms.Label
    Friend WithEvents startAsyncButton As System.Windows.Forms.Button
    Friend WithEvents cancelAsyncButton As System.Windows.Forms.Button
    Friend WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker

End Class
