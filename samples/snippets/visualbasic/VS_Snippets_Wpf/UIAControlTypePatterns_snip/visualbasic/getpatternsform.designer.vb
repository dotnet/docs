Imports System
Namespace GetSupportedPatterns
	Partial Public Class Form1
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
			Me.btnBegin = New System.Windows.Forms.Button()
			Me.btnProps = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' btnBegin
			' 
			Me.btnBegin.Location = New System.Drawing.Point(82, 12)
			Me.btnBegin.Name = "btnBegin"
			Me.btnBegin.Size = New System.Drawing.Size(75, 23)
			Me.btnBegin.TabIndex = 0
			Me.btnBegin.Text = "&Patterns"
			Me.btnBegin.UseVisualStyleBackColor = True
'			Me.btnBegin.Click += New System.EventHandler(Me.btnBegin_Click)
			' 
			' btnProps
			' 
			Me.btnProps.Location = New System.Drawing.Point(270, 11)
			Me.btnProps.Name = "btnProps"
			Me.btnProps.Size = New System.Drawing.Size(75, 23)
			Me.btnProps.TabIndex = 1
			Me.btnProps.Text = "&Properties"
			Me.btnProps.UseVisualStyleBackColor = True
'			Me.btnProps.Click += New System.EventHandler(Me.btnProps_Click)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(398, 60)
			Me.Controls.Add(Me.btnProps)
			Me.Controls.Add(Me.btnBegin)
			Me.Name = "Form1"
			Me.Text = "Get Supported UI Automation Control Patterns"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents btnBegin As System.Windows.Forms.Button
		Private WithEvents btnProps As System.Windows.Forms.Button
	End Class
End Namespace

