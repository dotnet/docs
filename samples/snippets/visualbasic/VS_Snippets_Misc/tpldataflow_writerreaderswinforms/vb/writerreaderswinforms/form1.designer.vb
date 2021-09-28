Namespace WriterReadersWinForms
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
		 Me.components = New System.ComponentModel.Container()
		 Me.timer1 = New Timer(Me.components)
		 Me.checkBox1 = New CheckBox()
		 Me.checkBox2 = New CheckBox()
		 Me.checkBox3 = New CheckBox()
		 Me.checkBox4 = New CheckBox()
		 Me.SuspendLayout()
		 ' 
		 ' timer1
		 ' 
		 Me.timer1.Interval = 2500
'		 Me.timer1.Tick += New System.EventHandler(Me.timer1_Tick)
		 ' 
		 ' checkBox1
		 ' 
		 Me.checkBox1.AutoSize = True
		 Me.checkBox1.Enabled = False
		 Me.checkBox1.Location = New Point(12, 9)
		 Me.checkBox1.Name = "checkBox1"
		 Me.checkBox1.Size = New Size(70, 17)
		 Me.checkBox1.TabIndex = 4
		 Me.checkBox1.Text = "Reader 1"
		 ' 
		 ' checkBox2
		 ' 
		 Me.checkBox2.AutoSize = True
		 Me.checkBox2.Enabled = False
		 Me.checkBox2.Location = New Point(12, 32)
		 Me.checkBox2.Name = "checkBox2"
		 Me.checkBox2.Size = New Size(70, 17)
		 Me.checkBox2.TabIndex = 5
		 Me.checkBox2.Text = "Reader 2"
		 Me.checkBox2.UseVisualStyleBackColor = True
		 ' 
		 ' checkBox3
		 ' 
		 Me.checkBox3.AutoSize = True
		 Me.checkBox3.Enabled = False
		 Me.checkBox3.Location = New Point(12, 55)
		 Me.checkBox3.Name = "checkBox3"
		 Me.checkBox3.Size = New Size(70, 17)
		 Me.checkBox3.TabIndex = 6
		 Me.checkBox3.Text = "Reader 3"
		 Me.checkBox3.UseVisualStyleBackColor = True
		 ' 
		 ' checkBox4
		 ' 
		 Me.checkBox4.AutoSize = True
		 Me.checkBox4.Enabled = False
		 Me.checkBox4.Location = New Point(12, 78)
		 Me.checkBox4.Name = "checkBox4"
		 Me.checkBox4.Size = New Size(54, 17)
		 Me.checkBox4.TabIndex = 7
		 Me.checkBox4.Text = "Writer"
		 Me.checkBox4.UseVisualStyleBackColor = True
		 ' 
		 ' Form1
		 ' 
		 Me.AutoScaleDimensions = New SizeF(6F, 13F)
		 Me.AutoScaleMode = AutoScaleMode.Font
		 Me.ClientSize = New Size(172, 102)
		 Me.Controls.Add(Me.checkBox4)
		 Me.Controls.Add(Me.checkBox3)
		 Me.Controls.Add(Me.checkBox2)
		 Me.Controls.Add(Me.checkBox1)
		 Me.Name = "Form1"
		 Me.Text = "Form1"
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private WithEvents timer1 As Timer
	  Private checkBox1 As CheckBox
	  Private checkBox2 As CheckBox
	  Private checkBox3 As CheckBox
	  Private checkBox4 As CheckBox

   End Class
End Namespace

