Namespace NavigateWithTreeWalker
	Partial Public Class NavigationWithTreeWalker
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
			Me.label11 = New Label()
			Me.btnStartAutomation = New Button()
			Me.tbStructure = New TextBox()
			Me.SuspendLayout()
			' 
			' label11
			' 
			Me.label11.AutoSize = True
			Me.label11.Location = New Point(13, 47)
			Me.label11.Margin = New Padding(4, 0, 4, 0)
			Me.label11.Name = "label11"
			Me.label11.Size = New Size(480, 16)
			Me.label11.TabIndex = 10
			Me.label11.Text = "After you have started, click the tab control tabs to see how the structure chang" & "es."
			' 
			' btnStartAutomation
			' 
			Me.btnStartAutomation.Location = New Point(12, 13)
			Me.btnStartAutomation.Margin = New Padding(4)
			Me.btnStartAutomation.Name = "btnStartAutomation"
			Me.btnStartAutomation.Size = New Size(177, 28)
			Me.btnStartAutomation.TabIndex = 11
			Me.btnStartAutomation.Text = "Start Automation"
'			Me.btnStartAutomation.Click += New System.EventHandler(Me.btnStartAutomation_Click)
			' 
			' tbStructure
			' 
			Me.tbStructure.Location = New Point(12, 79)
			Me.tbStructure.Multiline = True
			Me.tbStructure.Name = "tbStructure"
			Me.tbStructure.ScrollBars = ScrollBars.Vertical
			Me.tbStructure.Size = New Size(572, 485)
			Me.tbStructure.TabIndex = 12
			' 
			' NavigationWithTreeWalker
			' 
			Me.AutoScaleDimensions = New SizeF(8F, 16F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(596, 576)
			Me.Controls.Add(Me.tbStructure)
			Me.Controls.Add(Me.btnStartAutomation)
			Me.Controls.Add(Me.label11)
			Me.Margin = New Padding(4)
			Me.Name = "NavigationWithTreeWalker"
			Me.Text = "Navigate With TreeWalker"
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.NavigationWithTreeWalker_FormClosing)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label11 As Label
		Private WithEvents btnStartAutomation As Button
		Public tbStructure As TextBox
	End Class
End Namespace

