 '<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private WithEvents toolStripLabel1 As ToolStripLabel
   Private toolStrip1 As ToolStrip
   
   Public Sub New()
      InitializeComponent()
   End Sub
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New Form1())
   End Sub
   
   
   Private Sub InitializeComponent()
      Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.toolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
      Me.toolStrip1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' toolStrip1
      ' 
      Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripLabel1})
      Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.toolStrip1.Name = "toolStrip1"
      Me.toolStrip1.Size = New System.Drawing.Size(292, 25)
      Me.toolStrip1.TabIndex = 0
      Me.toolStrip1.Text = "toolStrip1"
      ' 
      ' toolStripLabel1
      ' 
      Me.toolStripLabel1.IsLink = True
      Me.toolStripLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline
      Me.toolStripLabel1.Name = "toolStripLabel1"
      Me.toolStripLabel1.Size = New System.Drawing.Size(71, 22)
      Me.toolStripLabel1.Tag = "http://search.microsoft.com/search/search.aspx?"
      Me.toolStripLabel1.Text = "Search MSDN"
      ' 
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.Add(toolStrip1)
      Me.Name = "Form1"
      Me.toolStrip1.ResumeLayout(False)
      Me.toolStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub
    
   
   Private Sub toolStripLabel1_Click(sender As Object, e As EventArgs) Handles toolStripLabel1.Click
      Dim toolStripLabel1 As ToolStripLabel = CType(sender, ToolStripLabel)
      
      ' Start Internet Explorer and navigate to the URL in the
      ' tag property.
      System.Diagnostics.Process.Start("IEXPLORE.EXE", toolStripLabel1.Tag.ToString())
      
      ' Set the LinkVisited property to true to change the color.
      toolStripLabel1.LinkVisited = True
   End Sub
End Class
'</Snippet1>