Imports System
Imports System.Text
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private toolStrip1 As ToolStrip
   Private toolStripButton1 As ToolStripButton
   
   Public Sub New()
      InitializeComponent()
   End Sub
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
   End Sub
   
   Private Sub InitializeComponent()
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
      toolStrip1 = New System.Windows.Forms.ToolStrip()
      toolStripButton1 = New System.Windows.Forms.ToolStripButton()
      toolStrip1.SuspendLayout()
      SuspendLayout()
      ' <Snippet1>
      ' This is an example of some common ToolStrip property settings.
      ' 
      toolStrip1.AllowDrop = False
      toolStrip1.AllowItemReorder = True
      toolStrip1.AllowMerge = False
      toolStrip1.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      toolStrip1.AutoSize = False
      toolStrip1.CanOverflow = False
      toolStrip1.Cursor = Cursors.Cross
      toolStrip1.Dock = System.Windows.Forms.DockStyle.None
      toolStrip1.DefaultDropDownDirection = ToolStripDropDownDirection.BelowRight
      toolStrip1.GripMargin = New System.Windows.Forms.Padding(3)
      toolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
      toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {toolStripButton1})
      toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
      toolStrip1.Location = New System.Drawing.Point(0, 0)
      toolStrip1.Margin = New System.Windows.Forms.Padding(1)
      toolStrip1.Name = "toolStrip1"
      toolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
      toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
      toolStrip1.ShowItemToolTips = False
      toolStrip1.Size = New System.Drawing.Size(109, 273)
      toolStrip1.Stretch = True
      toolStrip1.TabIndex = 0
      toolStrip1.TabStop = True
      toolStrip1.Text = "toolStrip1"
      toolStrip1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90
      ' </Snippet1>
      ' toolStripButton1
      ' 
      toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      toolStripButton1.Image = CType(resources.GetObject("toolStripButton1.Image"), System.Drawing.Image)
      toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
      toolStripButton1.Name = "toolStripButton1"
      toolStripButton1.Size = New System.Drawing.Size(23, 270)
      toolStripButton1.Text = "toolStripButton1"
      ' 
      ' Form1
      ' 
      ClientSize = New System.Drawing.Size(292, 273)
      Controls.Add(toolStrip1)
      Name = "Form1"
      toolStrip1.ResumeLayout(False)
      toolStrip1.PerformLayout()
      ResumeLayout(False)
   End Sub
End Class