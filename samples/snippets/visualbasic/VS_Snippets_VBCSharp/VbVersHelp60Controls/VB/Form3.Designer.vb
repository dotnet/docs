<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form3
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
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
Me.Button1 = New System.Windows.Forms.Button
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.CheckBox3 = New System.Windows.Forms.CheckBox
Me.CheckBox2 = New System.Windows.Forms.CheckBox
Me.CheckBox1 = New System.Windows.Forms.CheckBox
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.CheckBox6 = New System.Windows.Forms.CheckBox
Me.CheckBox5 = New System.Windows.Forms.CheckBox
Me.CheckBox4 = New System.Windows.Forms.CheckBox
Me.Button2 = New System.Windows.Forms.Button
Me.TextBox1 = New System.Windows.Forms.TextBox
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.GroupBox1.SuspendLayout()
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'Button1
'
Me.Button1.Location = New System.Drawing.Point(13, 29)
Me.Button1.Name = "Button1"
Me.Button1.Size = New System.Drawing.Size(75, 23)
Me.Button1.TabIndex = 0
Me.Button1.Text = "Button1"
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.CheckBox3)
Me.GroupBox1.Controls.Add(Me.CheckBox2)
Me.GroupBox1.Controls.Add(Me.CheckBox1)
Me.GroupBox1.Controls.Add(Me.GroupBox2)
Me.GroupBox1.Location = New System.Drawing.Point(145, 46)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(270, 269)
Me.GroupBox1.TabIndex = 1
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "GroupBox1"
'
'CheckBox3
'
Me.CheckBox3.AutoSize = True
Me.CheckBox3.Checked = True
Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
Me.CheckBox3.Location = New System.Drawing.Point(26, 68)
Me.CheckBox3.Name = "CheckBox3"
Me.CheckBox3.Size = New System.Drawing.Size(81, 17)
Me.CheckBox3.TabIndex = 3
Me.CheckBox3.Text = "CheckBox3"
'
'CheckBox2
'
Me.CheckBox2.AutoSize = True
Me.CheckBox2.Checked = True
Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
Me.CheckBox2.Location = New System.Drawing.Point(26, 44)
Me.CheckBox2.Name = "CheckBox2"
Me.CheckBox2.Size = New System.Drawing.Size(81, 17)
Me.CheckBox2.TabIndex = 2
Me.CheckBox2.Text = "CheckBox2"
'
'CheckBox1
'
Me.CheckBox1.AutoSize = True
Me.CheckBox1.Checked = True
Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
Me.CheckBox1.Location = New System.Drawing.Point(26, 20)
Me.CheckBox1.Name = "CheckBox1"
Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
Me.CheckBox1.TabIndex = 1
Me.CheckBox1.Text = "CheckBox1"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.CheckBox6)
Me.GroupBox2.Controls.Add(Me.CheckBox5)
Me.GroupBox2.Controls.Add(Me.CheckBox4)
Me.GroupBox2.Location = New System.Drawing.Point(89, 136)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(134, 127)
Me.GroupBox2.TabIndex = 0
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "GroupBox2"
'
'CheckBox6
'
Me.CheckBox6.AutoSize = True
Me.CheckBox6.Checked = True
Me.CheckBox6.CheckState = System.Windows.Forms.CheckState.Checked
Me.CheckBox6.Location = New System.Drawing.Point(17, 76)
Me.CheckBox6.Name = "CheckBox6"
Me.CheckBox6.Size = New System.Drawing.Size(81, 17)
Me.CheckBox6.TabIndex = 2
Me.CheckBox6.Text = "CheckBox6"
'
'CheckBox5
'
Me.CheckBox5.AutoSize = True
Me.CheckBox5.Checked = True
Me.CheckBox5.CheckState = System.Windows.Forms.CheckState.Checked
Me.CheckBox5.Location = New System.Drawing.Point(17, 52)
Me.CheckBox5.Name = "CheckBox5"
Me.CheckBox5.Size = New System.Drawing.Size(81, 17)
Me.CheckBox5.TabIndex = 1
Me.CheckBox5.Text = "CheckBox5"
'
'CheckBox4
'
Me.CheckBox4.AutoSize = True
Me.CheckBox4.Checked = True
Me.CheckBox4.CheckState = System.Windows.Forms.CheckState.Checked
Me.CheckBox4.Location = New System.Drawing.Point(17, 29)
Me.CheckBox4.Name = "CheckBox4"
Me.CheckBox4.Size = New System.Drawing.Size(81, 17)
Me.CheckBox4.TabIndex = 0
Me.CheckBox4.Text = "CheckBox4"
'
'Button2
'
Me.Button2.Location = New System.Drawing.Point(13, 78)
Me.Button2.Name = "Button2"
Me.Button2.Size = New System.Drawing.Size(75, 23)
Me.Button2.TabIndex = 2
Me.Button2.Text = "Button2"
'
'TextBox1
'
Me.TextBox1.Location = New System.Drawing.Point(13, 133)
Me.TextBox1.Name = "TextBox1"
Me.TextBox1.Size = New System.Drawing.Size(100, 20)
Me.TextBox1.TabIndex = 3
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.Images.SetKeyName(0, "GenericClientEndpoint.bmp")
Me.ImageList1.Images.SetKeyName(1, "HttpServerPort.bmp")
Me.ImageList1.Images.SetKeyName(2, "GenericServerEndpoint.bmp")
'
'Form3
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(600, 348)
Me.Controls.Add(Me.TextBox1)
Me.Controls.Add(Me.Button2)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.Button1)
Me.Name = "Form3"
Me.Text = "Form3"
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.GroupBox2.ResumeLayout(False)
Me.GroupBox2.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
