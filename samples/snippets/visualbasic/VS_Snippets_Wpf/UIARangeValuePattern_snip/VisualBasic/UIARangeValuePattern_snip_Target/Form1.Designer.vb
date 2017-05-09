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
        Me.snippetTrackBar = New System.Windows.Forms.TrackBar
        CType(Me.snippetTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'snippetTrackBar
        '
        Me.snippetTrackBar.AccessibleDescription = "RangeValuePattern snippet target slider"
        Me.snippetTrackBar.AccessibleName = "Target slider"
        Me.snippetTrackBar.Location = New System.Drawing.Point(12, 111)
        Me.snippetTrackBar.Minimum = -10
        Me.snippetTrackBar.Name = "snippetTrackBar"
        Me.snippetTrackBar.Size = New System.Drawing.Size(268, 45)
        Me.snippetTrackBar.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.snippetTrackBar)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.snippetTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents snippetTrackBar As System.Windows.Forms.TrackBar

End Class
