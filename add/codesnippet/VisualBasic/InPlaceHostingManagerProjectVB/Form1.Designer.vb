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
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.deployManifestTextBox = New System.Windows.Forms.TextBox()
        Me.installButton = New System.Windows.Forms.Button()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripProgressBar1})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 85)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(543, 22)
        Me.statusStrip1.TabIndex = 8
        Me.statusStrip1.Text = "statusStrip1"
        '
        'toolStripProgressBar1
        '
        Me.toolStripProgressBar1.Name = "toolStripProgressBar1"
        Me.toolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.toolStripProgressBar1.Step = 1
        Me.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'deployManifestTextBox
        '
        Me.deployManifestTextBox.Location = New System.Drawing.Point(12, 3)
        Me.deployManifestTextBox.Name = "deployManifestTextBox"
        Me.deployManifestTextBox.Size = New System.Drawing.Size(370, 20)
        Me.deployManifestTextBox.TabIndex = 7
        Me.deployManifestTextBox.Text = "http://clientue/clickoncehelloworld/ClickOnceHelloWorld.application"
        '
        'installButton
        '
        Me.installButton.Location = New System.Drawing.Point(399, 3)
        Me.installButton.Name = "installButton"
        Me.installButton.Size = New System.Drawing.Size(75, 23)
        Me.installButton.TabIndex = 6
        Me.installButton.Text = "button1"
        Me.installButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 107)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.deployManifestTextBox)
        Me.Controls.Add(Me.installButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Private WithEvents deployManifestTextBox As System.Windows.Forms.TextBox
    Private WithEvents installButton As System.Windows.Forms.Button

End Class
