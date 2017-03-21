Imports System
Namespace SDKSample
	Partial Public Class SignatureDefinition
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		'''   Clean up any resources being used.</summary>
		''' <param name="disposing">true if managed resources should 
		'''   be disposed; otherwise, false.</param>
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
			Me.Ok = New System.Windows.Forms.Button()
			Me.Cancel = New System.Windows.Forms.Button()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.SigningLocale = New System.Windows.Forms.TextBox()
			Me.SignBy = New System.Windows.Forms.TextBox()
			Me.Intent = New System.Windows.Forms.TextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.RequestedSigner = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' Ok
			' 
			Me.Ok.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.Ok.Location = New System.Drawing.Point(185, 150)
			Me.Ok.Name = "Ok"
			Me.Ok.Size = New System.Drawing.Size(75, 23)
			Me.Ok.TabIndex = 14
			Me.Ok.Text = "Ok"
			Me.Ok.UseVisualStyleBackColor = True
			' 
			' Cancel
			' 
			Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.Cancel.Location = New System.Drawing.Point(266, 150)
			Me.Cancel.Name = "Cancel"
			Me.Cancel.Size = New System.Drawing.Size(75, 23)
			Me.Cancel.TabIndex = 15
			Me.Cancel.Text = "Cancel"
			Me.Cancel.UseVisualStyleBackColor = True
			' 
			' panel1
			' 
			Me.panel1.BackColor = System.Drawing.SystemColors.Window
			Me.panel1.Controls.Add(Me.SigningLocale)
			Me.panel1.Controls.Add(Me.SignBy)
			Me.panel1.Controls.Add(Me.Intent)
			Me.panel1.Controls.Add(Me.label4)
			Me.panel1.Controls.Add(Me.RequestedSigner)
			Me.panel1.Controls.Add(Me.label3)
			Me.panel1.Controls.Add(Me.label2)
			Me.panel1.Controls.Add(Me.label1)
			Me.panel1.Location = New System.Drawing.Point(18, 13)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(334, 117)
			Me.panel1.TabIndex = 13
			' 
			' SigningLocale
			' 
			Me.SigningLocale.Location = New System.Drawing.Point(112, 85)
			Me.SigningLocale.Name = "SigningLocale"
			Me.SigningLocale.Size = New System.Drawing.Size(209, 20)
			Me.SigningLocale.TabIndex = 4
			' 
			' SignBy
			' 
			Me.SignBy.Location = New System.Drawing.Point(112, 59)
			Me.SignBy.Name = "SignBy"
			Me.SignBy.Size = New System.Drawing.Size(209, 20)
			Me.SignBy.TabIndex = 3
			' 
			' Intent
			' 
			Me.Intent.Location = New System.Drawing.Point(112, 30)
			Me.Intent.Name = "Intent"
			Me.Intent.Size = New System.Drawing.Size(209, 20)
			Me.Intent.TabIndex = 2
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(13, 87)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(80, 13)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Signing Locale:"
			' 
			' RequestedSigner
			' 
			Me.RequestedSigner.Location = New System.Drawing.Point(112, 5)
			Me.RequestedSigner.Name = "RequestedSigner"
			Me.RequestedSigner.Size = New System.Drawing.Size(209, 20)
			Me.RequestedSigner.TabIndex = 1
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(13, 61)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(46, 13)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Sign By:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(13, 32)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(37, 13)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Intent:"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(13, 7)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(95, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Requested Signer:"
			' 
			' SignatureDefinition
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(371, 191)
			Me.Controls.Add(Me.Ok)
			Me.Controls.Add(Me.Cancel)
			Me.Controls.Add(Me.panel1)
			Me.Name = "SignatureDefinition"
			Me.Text = "SignatureDefinition"
			Me.panel1.ResumeLayout(False)
			Me.panel1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private Ok As System.Windows.Forms.Button
		Private Cancel As System.Windows.Forms.Button
		Private panel1 As System.Windows.Forms.Panel
		Public SigningLocale As System.Windows.Forms.TextBox
		Public SignBy As System.Windows.Forms.TextBox
		Public Intent As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
		Public RequestedSigner As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label

	End Class
End Namespace