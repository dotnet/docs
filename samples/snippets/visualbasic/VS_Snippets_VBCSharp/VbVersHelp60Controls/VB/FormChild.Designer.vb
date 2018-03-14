<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormChild
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
Me.Label1 = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(58, 80)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(31, 13)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Hello"
'
'FormChild
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(292, 266)
Me.Controls.Add(Me.Label1)
Me.Name = "FormChild"
Me.Text = "FormChild"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
