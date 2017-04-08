 ' <Snippet0>
Imports System
Imports System.Text
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private toolStrip1 As ToolStrip
   Private toolStripTextBox1 As ToolStripTextBox
   
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
      toolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
      toolStrip1.SuspendLayout()
      SuspendLayout()
      ' 
      ' toolStrip1
      ' 
      toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {toolStripTextBox1})
      toolStrip1.Location = New System.Drawing.Point(0, 0)
      toolStrip1.Name = "toolStrip1"
      toolStrip1.Size = New System.Drawing.Size(292, 25)
      toolStrip1.TabIndex = 0
      toolStrip1.Text = "toolStrip1"
      ' <Snippet1>
      ' This code example demonstrates the syntax for setting
      ' various ToolStripTextBox properties.
      ' 
      toolStripTextBox1.AcceptsReturn = True
      toolStripTextBox1.AcceptsTab = True
      toolStripTextBox1.AutoCompleteCustomSource.AddRange(New String() {"This is line one.", "Second line.", "Another line."})
      toolStripTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      toolStripTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
      toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      toolStripTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      toolStripTextBox1.HideSelection = False
      toolStripTextBox1.MaxLength = 32000
      toolStripTextBox1.Name = "toolStripTextBox1"
      toolStripTextBox1.ShortcutsEnabled = False
      toolStripTextBox1.Size = New System.Drawing.Size(100, 25)
      toolStripTextBox1.Text = "STRING1" + ControlChars.Cr + ControlChars.Lf + "STRING2" + ControlChars.Cr + ControlChars.Lf + "STRING3" + ControlChars.Cr + ControlChars.Lf + "STRING4"
      toolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
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