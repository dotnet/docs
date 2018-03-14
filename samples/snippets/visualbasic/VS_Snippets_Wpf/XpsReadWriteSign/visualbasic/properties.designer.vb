Imports System
Namespace SDKSample
	Partial Public Class PropertiesDialog
		''' <summary>
		'''   Required designer variable.</summary>
		Private components As System.ComponentModel.IContainer = Nothing

		' ----------------------------- Dispose ------------------------------
		''' <summary>
		'''   Cleans up any resources being used.</summary>
		''' <param name="disposing">
		'''   true if managed resources should be disposed; otherwise, false.</param>
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.Creator = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.Identifier = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.ContentType = New System.Windows.Forms.TextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.Title = New System.Windows.Forms.TextBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.Subject = New System.Windows.Forms.TextBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.Description = New System.Windows.Forms.TextBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.Keywords = New System.Windows.Forms.TextBox()
			Me.label8 = New System.Windows.Forms.Label()
			Me.Language = New System.Windows.Forms.TextBox()
			Me.label9 = New System.Windows.Forms.Label()
			Me.Category = New System.Windows.Forms.TextBox()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.Cancel = New System.Windows.Forms.Button()
			Me.Ok = New System.Windows.Forms.Button()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(13, 7)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(44, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Creator:"
			' 
			' Creator
			' 
			Me.Creator.Location = New System.Drawing.Point(100, 4)
			Me.Creator.Name = "Creator"
			Me.Creator.Size = New System.Drawing.Size(209, 20)
			Me.Creator.TabIndex = 1
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(13, 32)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(50, 13)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Identifier:"
			' 
			' Identifier
			' 
			Me.Identifier.Location = New System.Drawing.Point(100, 29)
			Me.Identifier.Name = "Identifier"
			Me.Identifier.Size = New System.Drawing.Size(209, 20)
			Me.Identifier.TabIndex = 2
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(13, 61)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(71, 13)
			Me.label3.TabIndex = 0
			Me.label3.Text = "ContentType:"
			' 
			' ContentType
			' 
			Me.ContentType.Location = New System.Drawing.Point(100, 58)
			Me.ContentType.Name = "ContentType"
			Me.ContentType.Size = New System.Drawing.Size(209, 20)
			Me.ContentType.TabIndex = 3
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(13, 87)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(30, 13)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Title:"
			' 
			' Title
			' 
			Me.Title.Location = New System.Drawing.Point(100, 84)
			Me.Title.Name = "Title"
			Me.Title.Size = New System.Drawing.Size(209, 20)
			Me.Title.TabIndex = 4
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(13, 113)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(46, 13)
			Me.label5.TabIndex = 0
			Me.label5.Text = "Subject:"
			' 
			' Subject
			' 
			Me.Subject.Location = New System.Drawing.Point(100, 110)
			Me.Subject.Name = "Subject"
			Me.Subject.Size = New System.Drawing.Size(209, 20)
			Me.Subject.TabIndex = 5
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(13, 139)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(63, 13)
			Me.label6.TabIndex = 0
			Me.label6.Text = "Description:"
			' 
			' Description
			' 
			Me.Description.Location = New System.Drawing.Point(100, 136)
			Me.Description.Name = "Description"
			Me.Description.Size = New System.Drawing.Size(209, 20)
			Me.Description.TabIndex = 6
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(13, 165)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(56, 13)
			Me.label7.TabIndex = 0
			Me.label7.Text = "Keywords:"
			' 
			' Keywords
			' 
			Me.Keywords.Location = New System.Drawing.Point(100, 162)
			Me.Keywords.Name = "Keywords"
			Me.Keywords.Size = New System.Drawing.Size(209, 20)
			Me.Keywords.TabIndex = 7
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(13, 191)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(58, 13)
			Me.label8.TabIndex = 0
			Me.label8.Text = "Language:"
			' 
			' Language
			' 
			Me.Language.Location = New System.Drawing.Point(100, 188)
			Me.Language.Name = "Language"
			Me.Language.Size = New System.Drawing.Size(209, 20)
			Me.Language.TabIndex = 9
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Location = New System.Drawing.Point(13, 217)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(52, 13)
			Me.label9.TabIndex = 0
			Me.label9.Text = "Category:"
			' 
			' Category
			' 
			Me.Category.Location = New System.Drawing.Point(100, 214)
			Me.Category.Name = "Category"
			Me.Category.Size = New System.Drawing.Size(209, 20)
			Me.Category.TabIndex = 10
			' 
			' panel1
			' 
			Me.panel1.BackColor = System.Drawing.SystemColors.Window
			Me.panel1.Controls.Add(Me.Category)
			Me.panel1.Controls.Add(Me.Language)
			Me.panel1.Controls.Add(Me.Keywords)
			Me.panel1.Controls.Add(Me.label9)
			Me.panel1.Controls.Add(Me.Description)
			Me.panel1.Controls.Add(Me.label8)
			Me.panel1.Controls.Add(Me.Subject)
			Me.panel1.Controls.Add(Me.label7)
			Me.panel1.Controls.Add(Me.Title)
			Me.panel1.Controls.Add(Me.label6)
			Me.panel1.Controls.Add(Me.ContentType)
			Me.panel1.Controls.Add(Me.label5)
			Me.panel1.Controls.Add(Me.Identifier)
			Me.panel1.Controls.Add(Me.label4)
			Me.panel1.Controls.Add(Me.Creator)
			Me.panel1.Controls.Add(Me.label3)
			Me.panel1.Controls.Add(Me.label2)
			Me.panel1.Controls.Add(Me.label1)
			Me.panel1.Location = New System.Drawing.Point(12, 11)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(334, 255)
			Me.panel1.TabIndex = 2
			' 
			' Cancel
			' 
			Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.Cancel.Location = New System.Drawing.Point(260, 305)
			Me.Cancel.Name = "Cancel"
			Me.Cancel.Size = New System.Drawing.Size(75, 23)
			Me.Cancel.TabIndex = 12
			Me.Cancel.Text = "Cancel"
			Me.Cancel.UseVisualStyleBackColor = True
			' 
			' Ok
			' 
			Me.Ok.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.Ok.Location = New System.Drawing.Point(179, 305)
			Me.Ok.Name = "Ok"
			Me.Ok.Size = New System.Drawing.Size(75, 23)
			Me.Ok.TabIndex = 11
			Me.Ok.Text = "Ok"
			Me.Ok.UseVisualStyleBackColor = True
'			Me.Ok.Click += New System.EventHandler(Me.Ok_Click)
			' 
			' Properties
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(381, 353)
			Me.Controls.Add(Me.Ok)
			Me.Controls.Add(Me.Cancel)
			Me.Controls.Add(Me.panel1)
			Me.Name = "Properties"
			Me.Text = "Properties"
			Me.panel1.ResumeLayout(False)
			Me.panel1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Public Creator As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Public Identifier As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Public ContentType As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
		Public Title As System.Windows.Forms.TextBox
		Private label5 As System.Windows.Forms.Label
		Public Subject As System.Windows.Forms.TextBox
		Private label6 As System.Windows.Forms.Label
		Public Description As System.Windows.Forms.TextBox
		Private label7 As System.Windows.Forms.Label
		Public Keywords As System.Windows.Forms.TextBox
		Private label8 As System.Windows.Forms.Label
		Public Language As System.Windows.Forms.TextBox
		Private label9 As System.Windows.Forms.Label
		Public Category As System.Windows.Forms.TextBox
		Private panel1 As System.Windows.Forms.Panel
		Private Cancel As System.Windows.Forms.Button
		Private WithEvents Ok As System.Windows.Forms.Button
	End Class
End Namespace