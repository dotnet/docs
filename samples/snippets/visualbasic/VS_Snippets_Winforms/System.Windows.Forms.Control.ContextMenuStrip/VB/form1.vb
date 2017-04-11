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
   Private contextMenuStrip1 As ContextMenuStrip
   Private toolStripMenuItem1 As ToolStripMenuItem
   Private toolStripMenuItem2 As ToolStripMenuItem
   Private toolStripMenuItem3 As ToolStripMenuItem
   Private components As IContainer
   
   
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
      Me.components = New System.ComponentModel.Container()
      Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
      Me.contextMenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' contextMenuStrip1
      ' 
      Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3})
      Me.contextMenuStrip1.Name = "contextMenuStrip1"
      Me.contextMenuStrip1.Size = New System.Drawing.Size(180, 70)
      ' 
      ' toolStripMenuItem1
      ' 
      Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
      Me.toolStripMenuItem1.Size = New System.Drawing.Size(179, 22)
      Me.toolStripMenuItem1.Text = "toolStripMenuItem1"
      ' 
      ' toolStripMenuItem2
      ' 
      Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
      Me.toolStripMenuItem2.Size = New System.Drawing.Size(179, 22)
      Me.toolStripMenuItem2.Text = "toolStripMenuItem2"
      ' 
      ' toolStripMenuItem3
      ' 
      Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
      Me.toolStripMenuItem3.Size = New System.Drawing.Size(179, 22)
      Me.toolStripMenuItem3.Text = "toolStripMenuItem3"
      ' 
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.ContextMenuStrip = Me.contextMenuStrip1
      Me.Name = "Form1"
      Me.contextMenuStrip1.ResumeLayout(False)
      Me.ResumeLayout(False)
   End Sub
End Class
'</Snippet1>