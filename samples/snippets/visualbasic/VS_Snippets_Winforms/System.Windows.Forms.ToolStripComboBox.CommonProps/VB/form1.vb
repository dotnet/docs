' <Snippet0>
Imports System
Imports System.Text
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private toolStrip1 As ToolStrip
   Private toolStripComboBox1 As ToolStripComboBox
   
   Public Sub New()
      InitializeComponent()
   End Sub
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
   End Sub
   
   
   Private Sub InitializeComponent()
      toolStrip1 = New System.Windows.Forms.ToolStrip()
      toolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
      toolStrip1.SuspendLayout()
      SuspendLayout()
      ' 
      ' toolStrip1
      ' 
      toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {toolStripComboBox1})
      toolStrip1.Location = New System.Drawing.Point(0, 0)
      toolStrip1.Name = "toolStrip1"
      toolStrip1.Size = New System.Drawing.Size(292, 25)
      toolStrip1.TabIndex = 0
      toolStrip1.Text = "toolStrip1"
      ' <Snippet1>
      ' The following code example demonstrates the syntax for setting
      ' various ToolStripComboBox properties.
      ' 
      toolStripComboBox1.AutoCompleteCustomSource.AddRange(New String() {"aaa", "bbb", "ccc"})
      toolStripComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      toolStripComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
      toolStripComboBox1.DropDownHeight = 110
      toolStripComboBox1.DropDownWidth = 122
      toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
      toolStripComboBox1.IntegralHeight = False
      toolStripComboBox1.Items.AddRange(New Object() {"xxx", "yyy", "zzz"})
      toolStripComboBox1.MaxDropDownItems = 9
      toolStripComboBox1.MergeAction = System.Windows.Forms.MergeAction.Insert
      toolStripComboBox1.Name = "toolStripComboBox1"
      toolStripComboBox1.Size = New System.Drawing.Size(121, 25)
      toolStripComboBox1.Sorted = True
      ' </Snippet1>
      ' 
      ' Form1
      ' 
      ClientSize = New System.Drawing.Size(292, 273)
      Controls.Add(toolStrip1)
      Name = "Form1"
      toolStrip1.ResumeLayout(False)
      toolStrip1.PerformLayout()
      ResumeLayout(False)
      PerformLayout()
   End Sub
End Class
' </Snippet0>