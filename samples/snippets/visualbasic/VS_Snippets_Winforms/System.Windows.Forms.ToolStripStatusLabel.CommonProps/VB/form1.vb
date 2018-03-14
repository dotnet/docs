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
      ' statusStrip1
      ' 
      statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {toolStripStatusLabel1})
      statusStrip1.Location = New System.Drawing.Point(0, 248)
      statusStrip1.Name = "statusStrip1"
      statusStrip1.Size = New System.Drawing.Size(292, 25)
      statusStrip1.TabIndex = 0
      statusStrip1.Text = "statusStrip1"
      
      ' 
      ' <Snippet1>
      ' 
      toolStripStatusLabel1.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
      toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
      toolStripStatusLabel1.IsLink = True
      toolStripStatusLabel1.Name = "toolStripStatusLabel1"
      toolStripStatusLabel1.Size = New System.Drawing.Size(246, 20)
      toolStripStatusLabel1.Spring = True
      toolStripStatusLabel1.Text = "toolStripStatusLabel1"
      toolStripStatusLabel1.Alignment = ToolStripItemAlignment.Left
      ' </Snippet1>
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