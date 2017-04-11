 '<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
   Inherits Form
   Private toolStrip2 As ToolStrip
   Private toolStrip1 As ToolStrip
   Private newToolStripButton As ToolStripButton
   Private openToolStripButton As ToolStripButton
   Private saveToolStripButton As ToolStripButton
   Private printToolStripButton As ToolStripButton
   Private toolStripSeparator As ToolStripSeparator
   Private cutToolStripButton As ToolStripButton
   Private copyToolStripButton As ToolStripButton
   Private pasteToolStripButton As ToolStripButton
   Private toolStripSeparator1 As ToolStripSeparator
   Private helpToolStripButton As ToolStripButton
   Private toolStripButton1 As ToolStripButton
   Private toolStripButton2 As ToolStripButton
   Private toolStripContainer1 As ToolStripContainer
   
   
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
      Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
      Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.newToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me.openToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me.saveToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me.printToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me.cutToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me.copyToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me.pasteToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.helpToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me.toolStrip2 = New System.Windows.Forms.ToolStrip()
      Me.toolStripButton1 = New System.Windows.Forms.ToolStripButton()
      Me.toolStripButton2 = New System.Windows.Forms.ToolStripButton()
      Me.toolStripContainer1.LeftToolStripPanel.SuspendLayout()
      Me.toolStripContainer1.TopToolStripPanel.SuspendLayout()
      Me.toolStripContainer1.SuspendLayout()
      Me.toolStrip1.SuspendLayout()
      Me.toolStrip2.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' toolStripContainer1
      ' 
      Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      ' 
      ' LeftToolStripPanel
      ' 
      ' <snippet2>
      Me.toolStripContainer1.LeftToolStripPanel.Controls.Add(Me.toolStrip2)
      Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
      Me.toolStripContainer1.Name = "toolStripContainer1"
      Me.toolStripContainer1.Size = New System.Drawing.Size(292, 273)
      Me.toolStripContainer1.TabIndex = 0
      Me.toolStripContainer1.Text = "toolStripContainer1"
      ' 
      ' TopToolStripPanel
      ' 
      Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolStrip1)
      ' </snippet2>
      ' toolStrip1
      ' 
      Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
      ' <snippet3>
      Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripButton, Me.openToolStripButton, Me.saveToolStripButton, Me.printToolStripButton, Me.toolStripSeparator, Me.cutToolStripButton, Me.copyToolStripButton, Me.pasteToolStripButton, Me.toolStripSeparator1, Me.helpToolStripButton})
      ' </snippet3>
      Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.toolStrip1.Name = "toolStrip1"
      Me.toolStrip1.TabIndex = 0
      Me.toolStrip1.Text = "toolStrip1"
      ' 
      ' newToolStripButton
      ' 
      Me.newToolStripButton.Image = CType(resources.GetObject("newToolStripButton.Image"), System.Drawing.Image)
      Me.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.newToolStripButton.Name = "newToolStripButton"
      Me.newToolStripButton.Text = "&New"
      ' 
      ' openToolStripButton
      ' 
      Me.openToolStripButton.Image = CType(resources.GetObject("openToolStripButton.Image"), System.Drawing.Image)
      Me.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.openToolStripButton.Name = "openToolStripButton"
      Me.openToolStripButton.Text = "&Open"
      ' 
      ' saveToolStripButton
      ' 
      Me.saveToolStripButton.Image = CType(resources.GetObject("saveToolStripButton.Image"), System.Drawing.Image)
      Me.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.saveToolStripButton.Name = "saveToolStripButton"
      Me.saveToolStripButton.Text = "&Save"
      ' 
      ' printToolStripButton
      ' 
      Me.printToolStripButton.Image = CType(resources.GetObject("printToolStripButton.Image"), System.Drawing.Image)
      Me.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.printToolStripButton.Name = "printToolStripButton"
      Me.printToolStripButton.Text = "&Print"
      ' 
      ' toolStripSeparator
      ' 
      Me.toolStripSeparator.Name = "toolStripSeparator"
      ' 
      ' cutToolStripButton
      ' 
      Me.cutToolStripButton.Image = CType(resources.GetObject("cutToolStripButton.Image"), System.Drawing.Image)
      Me.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.cutToolStripButton.Name = "cutToolStripButton"
      Me.cutToolStripButton.Text = "Cu&t"
      ' 
      ' copyToolStripButton
      ' 
      Me.copyToolStripButton.Image = CType(resources.GetObject("copyToolStripButton.Image"), System.Drawing.Image)
      Me.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.copyToolStripButton.Name = "copyToolStripButton"
      Me.copyToolStripButton.Text = "&Copy"
      ' 
      ' pasteToolStripButton
      ' 
      Me.pasteToolStripButton.Image = CType(resources.GetObject("pasteToolStripButton.Image"), System.Drawing.Image)
      Me.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.pasteToolStripButton.Name = "pasteToolStripButton"
      Me.pasteToolStripButton.Text = "&Paste"
      ' 
      ' toolStripSeparator1
      ' 
      Me.toolStripSeparator1.Name = "toolStripSeparator1"
      ' 
      ' helpToolStripButton
      ' 
      Me.helpToolStripButton.Image = CType(resources.GetObject("helpToolStripButton.Image"), System.Drawing.Image)
      Me.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.helpToolStripButton.Name = "helpToolStripButton"
      Me.helpToolStripButton.Text = "&Help"
      ' 
      ' toolStrip2
      ' 
      Me.toolStrip2.Dock = System.Windows.Forms.DockStyle.None
      Me.toolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButton1, Me.toolStripButton2})
      Me.toolStrip2.Location = New System.Drawing.Point(0, 0)
      Me.toolStrip2.Name = "toolStrip2"
      Me.toolStrip2.TabIndex = 0
      Me.toolStrip2.Text = "toolStrip2"
      ' 
      ' toolStripButton1
      ' 
      Me.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.toolStripButton1.Name = "toolStripButton1"
      Me.toolStripButton1.Text = "toolStripButton1"
      ' 
      ' toolStripButton2
      ' 
      Me.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.toolStripButton2.Name = "toolStripButton2"
      Me.toolStripButton2.Text = "toolStripButton2"
      ' 
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.Add(toolStripContainer1)
      Me.Name = "Form1"
      Me.toolStripContainer1.LeftToolStripPanel.ResumeLayout(False)
      Me.toolStripContainer1.LeftToolStripPanel.PerformLayout()
      Me.toolStripContainer1.TopToolStripPanel.ResumeLayout(False)
      Me.toolStripContainer1.TopToolStripPanel.PerformLayout()
      Me.toolStripContainer1.ResumeLayout(False)
      Me.toolStripContainer1.PerformLayout()
      Me.toolStrip1.ResumeLayout(False)
      Me.toolStrip2.ResumeLayout(False)
      Me.ResumeLayout(False)
   End Sub
End Class
' </snippet1>