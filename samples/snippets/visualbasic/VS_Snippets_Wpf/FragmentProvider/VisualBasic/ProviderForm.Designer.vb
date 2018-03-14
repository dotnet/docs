

Partial Class SampleApplicationForm
    Inherits Form

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing


    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.radioOn = New System.Windows.Forms.RadioButton()
        Me.radioOff = New System.Windows.Forms.RadioButton()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        ' 
        ' btnExit
        ' 
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExit.Location = New System.Drawing.Point(179, 208)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(68, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "E&xit"
        ' 
        ' btnRemove
        ' 
        Me.btnRemove.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRemove.Location = New System.Drawing.Point(179, 179)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(68, 23)
        Me.btnRemove.TabIndex = 1
        Me.btnRemove.Text = "&Remove"
        ' 
        ' btnAdd
        ' 
        Me.btnAdd.Location = New System.Drawing.Point(32, 109)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(68, 23)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "&Add"
        ' 
        ' label1
        ' 
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(13, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(106, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "&Enter Contact Name:"
        ' 
        ' txtItem
        ' 
        Me.txtItem.Location = New System.Drawing.Point(16, 38)
        Me.txtItem.MaxLength = 15
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(100, 20)
        Me.txtItem.TabIndex = 1
        Me.txtItem.WordWrap = False
        ' 
        ' radioOn
        ' 
        Me.radioOn.AutoSize = True
        Me.radioOn.Checked = True
        Me.radioOn.Location = New System.Drawing.Point(32, 64)
        Me.radioOn.Name = "radioOn"
        Me.radioOn.Size = New System.Drawing.Size(55, 17)
        Me.radioOn.TabIndex = 2
        Me.radioOn.TabStop = True
        Me.radioOn.Text = "O&nline"
        Me.radioOn.UseVisualStyleBackColor = True
        ' 
        ' radioOff
        ' 
        Me.radioOff.AutoSize = True
        Me.radioOff.Location = New System.Drawing.Point(32, 86)
        Me.radioOff.Name = "radioOff"
        Me.radioOff.Size = New System.Drawing.Size(55, 17)
        Me.radioOff.TabIndex = 3
        Me.radioOff.TabStop = True
        Me.radioOff.Text = "O&ffline"
        Me.radioOff.UseVisualStyleBackColor = True
        ' 
        ' groupBox1
        ' 
        Me.groupBox1.Controls.Add(Me.radioOff)
        Me.groupBox1.Controls.Add(Me.radioOn)
        Me.groupBox1.Controls.Add(Me.txtItem)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.btnAdd)
        Me.groupBox1.Location = New System.Drawing.Point(147, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(132, 146)
        Me.groupBox1.TabIndex = 0
        Me.groupBox1.TabStop = False
        ' 
        ' SampleApplicationForm
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 254)
        Me.Controls.Add(groupBox1)
        Me.Controls.Add(btnRemove)
        Me.Controls.Add(btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "SampleApplicationForm"
        Me.Text = "UIAutomation Fragment Provider"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub 'InitializeComponent 

#End Region

    Private WithEvents btnExit As System.Windows.Forms.Button
    Private WithEvents btnRemove As System.Windows.Forms.Button
    Private WithEvents btnAdd As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
    Private txtItem As System.Windows.Forms.TextBox
    Private radioOff As System.Windows.Forms.RadioButton
    Private radioOn As System.Windows.Forms.RadioButton
    Private groupBox1 As System.Windows.Forms.GroupBox
End Class 'SampleApplicationForm 

