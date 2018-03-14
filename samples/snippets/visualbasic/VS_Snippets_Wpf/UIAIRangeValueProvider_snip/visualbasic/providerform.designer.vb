Imports System
Namespace UIAIRangeValueProvider_snip
	Partial Public Class ProviderForm
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
			Me.btnExit = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' btnExit
			' 
			Me.btnExit.Location = New System.Drawing.Point(182, 219)
			Me.btnExit.Name = "btnExit"
			Me.btnExit.Size = New System.Drawing.Size(75, 23)
			Me.btnExit.TabIndex = 0
			Me.btnExit.Text = "Exit"
			Me.btnExit.UseVisualStyleBackColor = True
'			Me.btnExit.Click += New System.EventHandler(Me.btnExit_Click)
			' 
			' ProviderForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(292, 266)
			Me.Controls.Add(Me.btnExit)
			Me.Name = "ProviderForm"
			Me.Text = "Form1"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents btnExit As System.Windows.Forms.Button
	End Class
End Namespace

