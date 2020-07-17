Namespace SDKSample
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
			Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
			Me.CirclesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.FillWithCirclesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.AddCircleChildToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.circleSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.SmallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.MediumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.LargeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.RandomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.numberofRingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.ThreeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.FiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.EightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.behaviorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.TopmostLayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.AllLayersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.menuStrip1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' menuStrip1
			' 
			Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.CirclesToolStripMenuItem, Me.SettingToolStripMenuItem, Me.behaviorToolStripMenuItem})
			Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip1.Name = "menuStrip1"
			Me.menuStrip1.Size = New System.Drawing.Size(634, 24)
			Me.menuStrip1.TabIndex = 0
			Me.menuStrip1.Text = "menuStrip1"
			' 
			' CirclesToolStripMenuItem
			' 
			Me.CirclesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.FillWithCirclesToolStripMenuItem, Me.AddCircleChildToolStripMenuItem})
			Me.CirclesToolStripMenuItem.Name = "CirclesToolStripMenuItem"
			Me.CirclesToolStripMenuItem.Text = "Circles"
			' 
			' FillWithCirclesToolStripMenuItem
			' 
			Me.FillWithCirclesToolStripMenuItem.Name = "FillWithCirclesToolStripMenuItem"
			Me.FillWithCirclesToolStripMenuItem.Text = "Fill with Circles"
'			Me.FillWithCirclesToolStripMenuItem.Click += New System.EventHandler(Me.FillWithCirclesToolStripMenuItem_Click)
			' 
			' AddCircleChildToolStripMenuItem
			' 
			Me.AddCircleChildToolStripMenuItem.Name = "AddCircleChildToolStripMenuItem"
			Me.AddCircleChildToolStripMenuItem.Text = "Add a Circle"
'			Me.AddCircleChildToolStripMenuItem.Click += New System.EventHandler(Me.AddChildToolStripMenuItem_Click)
			' 
			' SettingToolStripMenuItem
			' 
			Me.SettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.circleSizeToolStripMenuItem, Me.numberofRingsToolStripMenuItem})
			Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
			Me.SettingToolStripMenuItem.Text = "Setting"
			' 
			' circleSizeToolStripMenuItem
			' 
			Me.circleSizeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.SmallToolStripMenuItem, Me.MediumToolStripMenuItem, Me.LargeToolStripMenuItem, Me.RandomToolStripMenuItem})
			Me.circleSizeToolStripMenuItem.Name = "circleSizeToolStripMenuItem"
			Me.circleSizeToolStripMenuItem.Text = "Circle Size"
			' 
			' SmallToolStripMenuItem
			' 
			Me.SmallToolStripMenuItem.Name = "SmallToolStripMenuItem"
			Me.SmallToolStripMenuItem.Text = "Small"
'			Me.SmallToolStripMenuItem.Click += New System.EventHandler(Me.SmallToolStripMenuItem_Click)
			' 
			' MediumToolStripMenuItem
			' 
			Me.MediumToolStripMenuItem.Checked = True
			Me.MediumToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
			Me.MediumToolStripMenuItem.Name = "MediumToolStripMenuItem"
			Me.MediumToolStripMenuItem.Text = "Medium"
'			Me.MediumToolStripMenuItem.Click += New System.EventHandler(Me.MediumToolStripMenuItem_Click)
			' 
			' LargeToolStripMenuItem
			' 
			Me.LargeToolStripMenuItem.Name = "LargeToolStripMenuItem"
			Me.LargeToolStripMenuItem.Text = "Large"
'			Me.LargeToolStripMenuItem.Click += New System.EventHandler(Me.LargeToolStripMenuItem_Click)
			' 
			' RandomToolStripMenuItem
			' 
			Me.RandomToolStripMenuItem.Name = "RandomToolStripMenuItem"
			Me.RandomToolStripMenuItem.Text = "Random"
'			Me.RandomToolStripMenuItem.Click += New System.EventHandler(Me.RandomToolStripMenuItem_Click)
			' 
			' numberofRingsToolStripMenuItem
			' 
			Me.numberofRingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.ThreeToolStripMenuItem, Me.FiveToolStripMenuItem, Me.EightToolStripMenuItem})
			Me.numberofRingsToolStripMenuItem.Name = "numberofRingsToolStripMenuItem"
			Me.numberofRingsToolStripMenuItem.Text = "Number of Rings"
			' 
			' ThreeToolStripMenuItem
			' 
			Me.ThreeToolStripMenuItem.Name = "ThreeToolStripMenuItem"
			Me.ThreeToolStripMenuItem.Text = "3"
'			Me.ThreeToolStripMenuItem.Click += New System.EventHandler(Me.ThreeToolStripMenuItem_Click)
			' 
			' FiveToolStripMenuItem
			' 
			Me.FiveToolStripMenuItem.Checked = True
			Me.FiveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
			Me.FiveToolStripMenuItem.Name = "FiveToolStripMenuItem"
			Me.FiveToolStripMenuItem.Text = "5"
'			Me.FiveToolStripMenuItem.Click += New System.EventHandler(Me.FiveToolStripMenuItem_Click)
			' 
			' EightToolStripMenuItem
			' 
			Me.EightToolStripMenuItem.Name = "EightToolStripMenuItem"
			Me.EightToolStripMenuItem.Text = "8"
'			Me.EightToolStripMenuItem.Click += New System.EventHandler(Me.EightToolStripMenuItem_Click)
			' 
			' behaviorToolStripMenuItem
			' 
			Me.behaviorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.TopmostLayerToolStripMenuItem, Me.AllLayersToolStripMenuItem})
			Me.behaviorToolStripMenuItem.Name = "behaviorToolStripMenuItem"
			Me.behaviorToolStripMenuItem.Text = "Behavior"
			' 
			' TopmostLayerToolStripMenuItem
			' 
			Me.TopmostLayerToolStripMenuItem.Checked = True
			Me.TopmostLayerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
			Me.TopmostLayerToolStripMenuItem.Name = "TopmostLayerToolStripMenuItem"
			Me.TopmostLayerToolStripMenuItem.Text = "Top-most Layer"
'			Me.TopmostLayerToolStripMenuItem.Click += New System.EventHandler(Me.TopmostLayerToolStripMenuItem_Click)
			' 
			' AllLayersToolStripMenuItem
			' 
			Me.AllLayersToolStripMenuItem.Name = "AllLayersToolStripMenuItem"
			Me.AllLayersToolStripMenuItem.Text = "All Layers"
'			Me.AllLayersToolStripMenuItem.Click += New System.EventHandler(Me.AllLayersToolStripMenuItem_Click)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.OldLace
			Me.ClientSize = New System.Drawing.Size(634, 448)
			Me.Controls.Add(Me.menuStrip1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.MainMenuStrip = Me.menuStrip1
			Me.MaximizeBox = False
			Me.Name = "Form1"
			Me.Text = "Visual Hit Test"
			Me.menuStrip1.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private menuStrip1 As System.Windows.Forms.MenuStrip
		Private CirclesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents AddCircleChildToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents FillWithCirclesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private SettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private circleSizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents SmallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents MediumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents LargeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private numberofRingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents ThreeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents FiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents EightToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents RandomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private behaviorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents TopmostLayerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents AllLayersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	End Class
End Namespace

