Namespace CancellationWinForms
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
		 Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		 Me.toolStrip1 = New ToolStrip()
		 Me.toolStripButton1 = New ToolStripButton()
		 Me.toolStripButton2 = New ToolStripButton()
		 Me.toolStripProgressBar1 = New ToolStripProgressBar()
		 Me.toolStripProgressBar2 = New ToolStripProgressBar()
		 Me.toolStripProgressBar3 = New ToolStripProgressBar()
		 Me.toolStripProgressBar4 = New ToolStripProgressBar()
		 Me.toolStrip1.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' toolStrip1
		 ' 
		 Me.toolStrip1.Items.AddRange(New ToolStripItem() { Me.toolStripButton1, Me.toolStripButton2, Me.toolStripProgressBar1, Me.toolStripProgressBar2, Me.toolStripProgressBar3, Me.toolStripProgressBar4})
		 Me.toolStrip1.Location = New Point(0, 0)
		 Me.toolStrip1.Name = "toolStrip1"
		 Me.toolStrip1.Size = New Size(579, 25)
		 Me.toolStrip1.TabIndex = 0
		 Me.toolStrip1.Text = "toolStrip1"
		 ' 
		 ' toolStripButton1
		 ' 
		 Me.toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text
		 Me.toolStripButton1.Image = (CType(resources.GetObject("toolStripButton1.Image"), Image))
		 Me.toolStripButton1.ImageTransparentColor = Color.Magenta
		 Me.toolStripButton1.Name = "toolStripButton1"
		 Me.toolStripButton1.Size = New Size(96, 22)
		 Me.toolStripButton1.Text = "Add Work Items"
'		 Me.toolStripButton1.Click += New System.EventHandler(Me.toolStripButton1_Click)
		 ' 
		 ' toolStripButton2
		 ' 
		 Me.toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text
		 Me.toolStripButton2.Enabled = False
		 Me.toolStripButton2.Image = (CType(resources.GetObject("toolStripButton2.Image"), Image))
		 Me.toolStripButton2.ImageTransparentColor = Color.Magenta
		 Me.toolStripButton2.Name = "toolStripButton2"
		 Me.toolStripButton2.Size = New Size(47, 22)
		 Me.toolStripButton2.Text = "Cancel"
'		 Me.toolStripButton2.Click += New System.EventHandler(Me.toolStripButton2_Click)
		 ' 
		 ' toolStripProgressBar1
		 ' 
		 Me.toolStripProgressBar1.Name = "toolStripProgressBar1"
		 Me.toolStripProgressBar1.Size = New Size(100, 22)
		 ' 
		 ' toolStripProgressBar2
		 ' 
		 Me.toolStripProgressBar2.Name = "toolStripProgressBar2"
		 Me.toolStripProgressBar2.Size = New Size(100, 22)
		 ' 
		 ' toolStripProgressBar3
		 ' 
		 Me.toolStripProgressBar3.Name = "toolStripProgressBar3"
		 Me.toolStripProgressBar3.Size = New Size(100, 22)
		 Me.toolStripProgressBar3.Step = 1
		 ' 
		 ' toolStripProgressBar4
		 ' 
		 Me.toolStripProgressBar4.Name = "toolStripProgressBar4"
		 Me.toolStripProgressBar4.Size = New Size(100, 22)
		 ' 
		 ' Form1
		 ' 
		 Me.AutoScaleDimensions = New SizeF(6F, 13F)
		 Me.AutoScaleMode = AutoScaleMode.Font
		 Me.ClientSize = New Size(579, 29)
		 Me.Controls.Add(Me.toolStrip1)
		 Me.Name = "Form1"
		 Me.Text = "Form1"
		 Me.toolStrip1.ResumeLayout(False)
		 Me.toolStrip1.PerformLayout()
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private toolStrip1 As ToolStrip
	  Private WithEvents toolStripButton1 As ToolStripButton
	  Private WithEvents toolStripButton2 As ToolStripButton
	  Private toolStripProgressBar1 As ToolStripProgressBar
	  Private toolStripProgressBar2 As ToolStripProgressBar
	  Private toolStripProgressBar3 As ToolStripProgressBar
	  Private toolStripProgressBar4 As ToolStripProgressBar
   End Class
End Namespace

