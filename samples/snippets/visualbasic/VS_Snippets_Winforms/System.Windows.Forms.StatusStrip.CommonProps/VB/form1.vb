 ' <Snippet0>
Imports System
Imports System.Text
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private statusStrip1 As StatusStrip
   Private toolStripStatusLabel1 As ToolStripStatusLabel
   
   Public Sub New()
      InitializeComponent()
   End Sub
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
   End Sub
   
   Private Sub InitializeComponent()
      statusStrip1 = New System.Windows.Forms.StatusStrip()
      toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
      statusStrip1.SuspendLayout()
      SuspendLayout()
      ' 
      ' The following code example demonstrates the syntax for setting
      ' various StatusStrip properties.
      ' <Snippet1>
      statusStrip1.Dock = System.Windows.Forms.DockStyle.Top
      statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
      statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {toolStripStatusLabel1})
      statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
      statusStrip1.Location = New System.Drawing.Point(0, 0)
      statusStrip1.Name = "statusStrip1"
      statusStrip1.ShowItemToolTips = True
      statusStrip1.Size = New System.Drawing.Size(292, 22)
      statusStrip1.SizingGrip = False
      statusStrip1.Stretch = False
      statusStrip1.TabIndex = 0
      statusStrip1.Text = "statusStrip1"
      ' </Snippet1>
      ' 
      ' toolStripStatusLabel1
      ' 
      toolStripStatusLabel1.Name = "toolStripStatusLabel1"
      toolStripStatusLabel1.Size = New System.Drawing.Size(109, 17)
      toolStripStatusLabel1.Text = "toolStripStatusLabel1"
      ' 
      ' Form1
      ' 
      ClientSize = New System.Drawing.Size(292, 273)
      Controls.Add(statusStrip1)
      Name = "Form1"
      statusStrip1.ResumeLayout(False)
      statusStrip1.PerformLayout()
      ResumeLayout(False)
      PerformLayout()
   End Sub 
End Class
' </Snippet0>