Namespace XpsApiSdk
	Partial Friend Class SignatureDialog
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
			Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
			Me.Sign = New System.Windows.Forms.Button()
			Me.Done = New System.Windows.Forms.Button()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.flowLayoutPanel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' flowLayoutPanel1
			' 
			Me.flowLayoutPanel1.Controls.Add(Me.Sign)
			Me.flowLayoutPanel1.Controls.Add(Me.Done)
			Me.flowLayoutPanel1.Location = New System.Drawing.Point(131, 225)
			Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
			Me.flowLayoutPanel1.Size = New System.Drawing.Size(168, 29)
			Me.flowLayoutPanel1.TabIndex = 0
			' 
			' Sign
			' 
			Me.Sign.Location = New System.Drawing.Point(3, 3)
			Me.Sign.Name = "Sign"
			Me.Sign.Size = New System.Drawing.Size(75, 23)
			Me.Sign.TabIndex = 0
			Me.Sign.Text = "Sign..."
			Me.Sign.UseVisualStyleBackColor = True
			' 
			' Done
			' 
			Me.Done.Location = New System.Drawing.Point(84, 3)
			Me.Done.Name = "Done"
			Me.Done.Size = New System.Drawing.Size(75, 23)
			Me.Done.TabIndex = 1
			Me.Done.Text = "Done"
			Me.Done.UseVisualStyleBackColor = True
			' 
			' panel1
			' 
			Me.panel1.Location = New System.Drawing.Point(12, 12)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(287, 196)
			Me.panel1.TabIndex = 1
			' 
			' SignatureDialog
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(311, 266)
			Me.Controls.Add(Me.panel1)
			Me.Controls.Add(Me.flowLayoutPanel1)
			Me.Name = "SignatureDialog"
			Me.Text = "SignatureDialog"
			Me.flowLayoutPanel1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private flowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
		Private Sign As System.Windows.Forms.Button
		Private Done As System.Windows.Forms.Button
		Private panel1 As System.Windows.Forms.Panel
	End Class
End Namespace