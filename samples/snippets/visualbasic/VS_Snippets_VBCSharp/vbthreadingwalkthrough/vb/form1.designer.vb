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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LinesCounted = New System.Windows.Forms.TextBox
        Me.WordsCounted = New System.Windows.Forms.TextBox
        Me.CompareString = New System.Windows.Forms.TextBox
        Me.SourceFile = New System.Windows.Forms.TextBox
        Me.Cancel = New System.Windows.Forms.Button
        Me.Start = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Lines Counted"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Matching Words"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Compare String"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Source File"
        '
        'LinesCounted
        '
        Me.LinesCounted.Location = New System.Drawing.Point(114, 160)
        Me.LinesCounted.Name = "LinesCounted"
        Me.LinesCounted.Size = New System.Drawing.Size(100, 20)
        Me.LinesCounted.TabIndex = 15
        Me.LinesCounted.Text = "0"
        '
        'WordsCounted
        '
        Me.WordsCounted.Location = New System.Drawing.Point(114, 134)
        Me.WordsCounted.Name = "WordsCounted"
        Me.WordsCounted.Size = New System.Drawing.Size(100, 20)
        Me.WordsCounted.TabIndex = 14
        Me.WordsCounted.Text = "0"
        '
        'CompareString
        '
        Me.CompareString.Location = New System.Drawing.Point(114, 108)
        Me.CompareString.Name = "CompareString"
        Me.CompareString.Size = New System.Drawing.Size(100, 20)
        Me.CompareString.TabIndex = 13
        '
        'SourceFile
        '
        Me.SourceFile.Location = New System.Drawing.Point(114, 82)
        Me.SourceFile.Name = "SourceFile"
        Me.SourceFile.Size = New System.Drawing.Size(100, 20)
        Me.SourceFile.TabIndex = 12
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(114, 53)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 11
        Me.Cancel.Text = "Cancel"
        '
        'Start
        '
        Me.Start.Location = New System.Drawing.Point(114, 23)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(75, 23)
        Me.Start.TabIndex = 10
        Me.Start.Text = "Start"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 217)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LinesCounted)
        Me.Controls.Add(Me.WordsCounted)
        Me.Controls.Add(Me.CompareString)
        Me.Controls.Add(Me.SourceFile)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Start)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LinesCounted As System.Windows.Forms.TextBox
    Friend WithEvents WordsCounted As System.Windows.Forms.TextBox
    Friend WithEvents CompareString As System.Windows.Forms.TextBox
    Friend WithEvents SourceFile As System.Windows.Forms.TextBox
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Start As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker

End Class
