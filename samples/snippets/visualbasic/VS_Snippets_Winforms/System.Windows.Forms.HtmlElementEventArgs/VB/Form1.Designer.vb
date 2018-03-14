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
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.button1 = New System.Windows.Forms.Button
        Me.button2 = New System.Windows.Forms.Button
        Me.webBrowser1 = New System.Windows.Forms.WebBrowser
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.flowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.flowLayoutPanel1)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.webBrowser1)
        Me.splitContainer1.Size = New System.Drawing.Size(779, 570)
        Me.splitContainer1.SplitterDistance = 75
        Me.splitContainer1.TabIndex = 3
        '
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel1.Controls.Add(Me.button1)
        Me.flowLayoutPanel1.Controls.Add(Me.button2)
        Me.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(779, 75)
        Me.flowLayoutPanel1.TabIndex = 1
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(3, 3)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(151, 23)
        Me.button1.TabIndex = 0
        Me.button1.Text = "Load FromElement Test File"
        Me.button1.UseVisualStyleBackColor = True
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(160, 3)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(189, 23)
        Me.button2.TabIndex = 1
        Me.button2.Text = "Load MousePosition Test"
        Me.button2.UseVisualStyleBackColor = True
        '
        'webBrowser1
        '
        Me.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.webBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webBrowser1.Name = "webBrowser1"
        Me.webBrowser1.Size = New System.Drawing.Size(779, 491)
        Me.webBrowser1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 570)
        Me.Controls.Add(Me.splitContainer1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        Me.flowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents flowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents webBrowser1 As System.Windows.Forms.WebBrowser

End Class
