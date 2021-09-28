Namespace TreeWalkerTarget
	Partial Public Class myTestForm
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
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(myTestForm))
			Me.tabControl1 = New TabControl()
			Me.tabPage1 = New TabPage()
			Me.label3 = New Label()
			Me.label2 = New Label()
			Me.label1 = New Label()
			Me.richTextBox1 = New RichTextBox()
			Me.maskedTextBox1 = New MaskedTextBox()
			Me.textBox1 = New TextBox()
			Me.tabPage2 = New TabPage()
			Me.label6 = New Label()
			Me.label5 = New Label()
			Me.label4 = New Label()
			Me.comboBox1 = New ComboBox()
			Me.checkedListBox1 = New CheckedListBox()
			Me.listBox1 = New ListBox()
			Me.tabPage3 = New TabPage()
			Me.label9 = New Label()
			Me.label8 = New Label()
			Me.label7 = New Label()
			Me.radioButton1 = New RadioButton()
			Me.checkBox1 = New CheckBox()
			Me.button1 = New Button()
			Me.chkbxShowPatterns = New CheckBox()
			Me.tbListen = New TextBox()
			Me.tabControl1.SuspendLayout()
			Me.tabPage1.SuspendLayout()
			Me.tabPage2.SuspendLayout()
			Me.tabPage3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' tabControl1
			' 
			Me.tabControl1.Controls.Add(Me.tabPage1)
			Me.tabControl1.Controls.Add(Me.tabPage2)
			Me.tabControl1.Controls.Add(Me.tabPage3)
			Me.tabControl1.Location = New Point(15, 43)
			Me.tabControl1.Margin = New Padding(4)
			Me.tabControl1.Name = "tabControl1"
			Me.tabControl1.SelectedIndex = 0
			Me.tabControl1.Size = New Size(487, 302)
			Me.tabControl1.TabIndex = 2
			' 
			' tabPage1
			' 
			Me.tabPage1.Controls.Add(Me.label3)
			Me.tabPage1.Controls.Add(Me.label2)
			Me.tabPage1.Controls.Add(Me.label1)
			Me.tabPage1.Controls.Add(Me.richTextBox1)
			Me.tabPage1.Controls.Add(Me.maskedTextBox1)
			Me.tabPage1.Controls.Add(Me.textBox1)
			Me.tabPage1.Location = New Point(4, 25)
			Me.tabPage1.Margin = New Padding(4)
			Me.tabPage1.Name = "tabPage1"
			Me.tabPage1.Padding = New Padding(4)
			Me.tabPage1.Size = New Size(479, 273)
			Me.tabPage1.TabIndex = 0
			Me.tabPage1.Text = "Text Boxes"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New Point(235, 7)
			Me.label3.Margin = New Padding(4, 0, 4, 0)
			Me.label3.Name = "label3"
			Me.label3.Size = New Size(98, 16)
			Me.label3.TabIndex = 7
			Me.label3.Text = "A Rich Text Box"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New Point(8, 69)
			Me.label2.Margin = New Padding(4, 0, 4, 0)
			Me.label2.Name = "label2"
			Me.label2.Size = New Size(120, 16)
			Me.label2.TabIndex = 6
			Me.label2.Text = "A Masked Text Box"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New Point(8, 7)
			Me.label1.Margin = New Padding(4, 0, 4, 0)
			Me.label1.Name = "label1"
			Me.label1.Size = New Size(68, 16)
			Me.label1.TabIndex = 5
			Me.label1.Text = "A Text Box"
			' 
			' richTextBox1
			' 
			Me.richTextBox1.Location = New Point(235, 32)
			Me.richTextBox1.Margin = New Padding(4)
			Me.richTextBox1.Name = "richTextBox1"
			Me.richTextBox1.Size = New Size(132, 117)
			Me.richTextBox1.TabIndex = 4
			Me.richTextBox1.Text = ""
			' 
			' maskedTextBox1
			' 
			Me.maskedTextBox1.Location = New Point(8, 94)
			Me.maskedTextBox1.Margin = New Padding(4)
			Me.maskedTextBox1.Name = "maskedTextBox1"
			Me.maskedTextBox1.Size = New Size(132, 22)
			Me.maskedTextBox1.TabIndex = 3
			' 
			' textBox1
			' 
			Me.textBox1.Location = New Point(8, 32)
			Me.textBox1.Margin = New Padding(4)
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New Size(132, 22)
			Me.textBox1.TabIndex = 2
			' 
			' tabPage2
			' 
			Me.tabPage2.Controls.Add(Me.label6)
			Me.tabPage2.Controls.Add(Me.label5)
			Me.tabPage2.Controls.Add(Me.label4)
			Me.tabPage2.Controls.Add(Me.comboBox1)
			Me.tabPage2.Controls.Add(Me.checkedListBox1)
			Me.tabPage2.Controls.Add(Me.listBox1)
			Me.tabPage2.Location = New Point(4, 25)
			Me.tabPage2.Margin = New Padding(4)
			Me.tabPage2.Name = "tabPage2"
			Me.tabPage2.Padding = New Padding(4)
			Me.tabPage2.Size = New Size(479, 273)
			Me.tabPage2.TabIndex = 1
			Me.tabPage2.Text = "List Boxes"
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New Point(152, 175)
			Me.label6.Margin = New Padding(4, 0, 4, 0)
			Me.label6.Name = "label6"
			Me.label6.Size = New Size(86, 16)
			Me.label6.TabIndex = 6
			Me.label6.Text = "A Combo Box"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New Point(305, 7)
			Me.label5.Margin = New Padding(4, 0, 4, 0)
			Me.label5.Name = "label5"
			Me.label5.Size = New Size(119, 16)
			Me.label5.TabIndex = 5
			Me.label5.Text = "A Checked List Box"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New Point(8, 7)
			Me.label4.Margin = New Padding(4, 0, 4, 0)
			Me.label4.Name = "label4"
			Me.label4.Size = New Size(62, 16)
			Me.label4.TabIndex = 4
			Me.label4.Text = "A List Box"
			' 
			' comboBox1
			' 
			Me.comboBox1.FormattingEnabled = True
			Me.comboBox1.Location = New Point(152, 199)
			Me.comboBox1.Margin = New Padding(4)
			Me.comboBox1.Name = "comboBox1"
			Me.comboBox1.Size = New Size(160, 24)
			Me.comboBox1.TabIndex = 3
			' 
			' checkedListBox1
			' 
			Me.checkedListBox1.FormattingEnabled = True
			Me.checkedListBox1.Location = New Point(305, 30)
			Me.checkedListBox1.Margin = New Padding(4)
			Me.checkedListBox1.Name = "checkedListBox1"
			Me.checkedListBox1.Size = New Size(159, 99)
			Me.checkedListBox1.TabIndex = 2
			' 
			' listBox1
			' 
			Me.listBox1.FormattingEnabled = True
			Me.listBox1.ItemHeight = 16
			Me.listBox1.Location = New Point(8, 30)
			Me.listBox1.Margin = New Padding(4)
			Me.listBox1.Name = "listBox1"
			Me.listBox1.Size = New Size(159, 116)
			Me.listBox1.TabIndex = 1
			' 
			' tabPage3
			' 
			Me.tabPage3.Controls.Add(Me.label9)
			Me.tabPage3.Controls.Add(Me.label8)
			Me.tabPage3.Controls.Add(Me.label7)
			Me.tabPage3.Controls.Add(Me.radioButton1)
			Me.tabPage3.Controls.Add(Me.checkBox1)
			Me.tabPage3.Controls.Add(Me.button1)
			Me.tabPage3.Location = New Point(4, 25)
			Me.tabPage3.Margin = New Padding(4)
			Me.tabPage3.Name = "tabPage3"
			Me.tabPage3.Size = New Size(479, 273)
			Me.tabPage3.TabIndex = 2
			Me.tabPage3.Text = "Clicky Controls"
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Location = New Point(21, 145)
			Me.label9.Margin = New Padding(4, 0, 4, 0)
			Me.label9.Name = "label9"
			Me.label9.Size = New Size(93, 16)
			Me.label9.TabIndex = 5
			Me.label9.Text = "A Radio Button"
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New Point(21, 85)
			Me.label8.Margin = New Padding(4, 0, 4, 0)
			Me.label8.Name = "label8"
			Me.label8.Size = New Size(80, 16)
			Me.label8.TabIndex = 4
			Me.label8.Text = "A Check Box"
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New Point(21, 12)
			Me.label7.Margin = New Padding(4, 0, 4, 0)
			Me.label7.Name = "label7"
			Me.label7.Size = New Size(53, 16)
			Me.label7.TabIndex = 3
			Me.label7.Text = "A Button"
			' 
			' radioButton1
			' 
			Me.radioButton1.AutoSize = True
			Me.radioButton1.Location = New Point(23, 170)
			Me.radioButton1.Margin = New Padding(4)
			Me.radioButton1.Name = "radioButton1"
			Me.radioButton1.Size = New Size(97, 20)
			Me.radioButton1.TabIndex = 2
			Me.radioButton1.Text = "radioButton1"
			' 
			' checkBox1
			' 
			Me.checkBox1.AutoSize = True
			Me.checkBox1.Location = New Point(21, 110)
			Me.checkBox1.Margin = New Padding(4)
			Me.checkBox1.Name = "checkBox1"
			Me.checkBox1.Size = New Size(89, 20)
			Me.checkBox1.TabIndex = 1
			Me.checkBox1.Text = "checkBox1"
			' 
			' button1
			' 
			Me.button1.Location = New Point(21, 37)
			Me.button1.Margin = New Padding(4)
			Me.button1.Name = "button1"
			Me.button1.Size = New Size(100, 28)
			Me.button1.TabIndex = 0
			Me.button1.Text = "button1"
			' 
			' chkbxShowPatterns
			' 
			Me.chkbxShowPatterns.AutoSize = True
			Me.chkbxShowPatterns.Location = New Point(16, 15)
			Me.chkbxShowPatterns.Margin = New Padding(4)
			Me.chkbxShowPatterns.Name = "chkbxShowPatterns"
			Me.chkbxShowPatterns.Size = New Size(171, 20)
			Me.chkbxShowPatterns.TabIndex = 6
			Me.chkbxShowPatterns.Text = "Show supported patterns"
			' 
			' tbListen
			' 
			Me.tbListen.Location = New Point(251, 14)
			Me.tbListen.Name = "tbListen"
			Me.tbListen.Size = New Size(247, 22)
			Me.tbListen.TabIndex = 7
			Me.tbListen.Text = "UIAutomation is not listening."
			' 
			' myTestForm
			' 
			Me.AutoScaleDimensions = New SizeF(8F, 16F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(522, 368)
			Me.Controls.Add(Me.tbListen)
			Me.Controls.Add(Me.chkbxShowPatterns)
			Me.Controls.Add(Me.tabControl1)
			Me.Icon = (CType(resources.GetObject("$this.Icon"), Icon))
			Me.Margin = New Padding(4)
			Me.Name = "myTestForm"
			Me.Text = "TreeWalker Navigation Target"
			Me.tabControl1.ResumeLayout(False)
			Me.tabPage1.ResumeLayout(False)
			Me.tabPage1.PerformLayout()
			Me.tabPage2.ResumeLayout(False)
			Me.tabPage2.PerformLayout()
			Me.tabPage3.ResumeLayout(False)
			Me.tabPage3.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private tabControl1 As TabControl
		Private tabPage1 As TabPage
		Private textBox1 As TextBox
		Private tabPage2 As TabPage
		Private listBox1 As ListBox
		Private comboBox1 As ComboBox
		Private checkedListBox1 As CheckedListBox
		Private maskedTextBox1 As MaskedTextBox
		Private tabPage3 As TabPage
		Private richTextBox1 As RichTextBox
		Private radioButton1 As RadioButton
		Private checkBox1 As CheckBox
		Private button1 As Button
		Private label3 As Label
		Private label2 As Label
		Private label1 As Label
		Private label6 As Label
		Private label5 As Label
		Private label4 As Label
		Private label9 As Label
		Private label8 As Label
		Private label7 As Label
		Private chkbxShowPatterns As CheckBox
		Private tbListen As TextBox

	End Class
End Namespace

