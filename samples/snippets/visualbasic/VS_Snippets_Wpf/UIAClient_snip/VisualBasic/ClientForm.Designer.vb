

Partial Class Form1 '

    Private components As System.ComponentModel.IContainer = Nothing


    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>'
    ''' 
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso Not (components Is Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)

    End Sub 'Dispose

#Region "Windows Form Designer generated code"


    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.lblColor = New System.Windows.Forms.Label
        Me.lblProperties = New System.Windows.Forms.Label
        Me.button1 = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.btnMisc = New System.Windows.Forms.Button
        Me.treeView1 = New System.Windows.Forms.TreeView
        Me.SuspendLayout()
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(21, 57)
        Me.lblColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(0, 13)
        Me.lblColor.TabIndex = 1
        '
        'lblProperties
        '
        Me.lblProperties.AutoSize = True
        Me.lblProperties.Location = New System.Drawing.Point(22, 57)
        Me.lblProperties.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProperties.Name = "lblProperties"
        Me.lblProperties.Size = New System.Drawing.Size(0, 13)
        Me.lblProperties.TabIndex = 3
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(22, 12)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 5
        Me.button1.Text = "&Pick Daffodil"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(21, 57)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(0, 13)
        Me.label1.TabIndex = 6
        '
        'btnMisc
        '
        Me.btnMisc.Location = New System.Drawing.Point(58, 57)
        Me.btnMisc.Name = "btnMisc"
        Me.btnMisc.Size = New System.Drawing.Size(75, 23)
        Me.btnMisc.TabIndex = 7
        Me.btnMisc.Text = "Misc Calls"
        '
        'treeView1
        '
        Me.treeView1.Location = New System.Drawing.Point(224, 12)
        Me.treeView1.Name = "treeView1"
        Me.treeView1.Size = New System.Drawing.Size(175, 174)
        Me.treeView1.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 198)
        Me.Controls.Add(Me.treeView1)
        Me.Controls.Add(Me.btnMisc)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.lblProperties)
        Me.Controls.Add(Me.lblColor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "UI Automation Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub 'InitializeComponent 

#End Region

    Private lblColor As System.Windows.Forms.Label
    Private lblProperties As System.Windows.Forms.Label
    Private WithEvents button1 As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
    Private WithEvents btnMisc As System.Windows.Forms.Button
    Private treeView1 As System.Windows.Forms.TreeView
End Class 'Form1

