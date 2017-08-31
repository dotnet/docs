<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form4
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
Me.TreeView1 = New System.Windows.Forms.TreeView
Me.ListView1 = New System.Windows.Forms.ListView
Me.Button1 = New System.Windows.Forms.Button
Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
Me.SuspendLayout()
'
'TreeView1
'
Me.TreeView1.Location = New System.Drawing.Point(13, 23)
Me.TreeView1.Name = "TreeView1"
Me.TreeView1.Size = New System.Drawing.Size(121, 97)
Me.TreeView1.TabIndex = 0
'
'ListView1
'
Me.ListView1.Location = New System.Drawing.Point(13, 136)
Me.ListView1.Name = "ListView1"
Me.ListView1.Size = New System.Drawing.Size(121, 97)
Me.ListView1.TabIndex = 1
'
'Button1
'
Me.Button1.Location = New System.Drawing.Point(158, 97)
Me.Button1.Name = "Button1"
Me.Button1.Size = New System.Drawing.Size(75, 23)
Me.Button1.TabIndex = 2
Me.Button1.Text = "Button1"
'
'RichTextBox1
'
Me.RichTextBox1.Location = New System.Drawing.Point(158, 137)
Me.RichTextBox1.Name = "RichTextBox1"
Me.RichTextBox1.Size = New System.Drawing.Size(100, 96)
Me.RichTextBox1.TabIndex = 3
Me.RichTextBox1.Text = ""
'
'Form4
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(463, 320)
Me.Controls.Add(Me.RichTextBox1)
Me.Controls.Add(Me.Button1)
Me.Controls.Add(Me.ListView1)
Me.Controls.Add(Me.TreeView1)
Me.Name = "Form4"
Me.Text = "Form4"
Me.ResumeLayout(False)

End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
End Class
