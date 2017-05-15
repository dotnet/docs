 '<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
   Inherits Form
   Private toolStripButton1 As ToolStripButton
   Private toolStrip1 As ToolStrip
   
   
   Public Sub New()
      InitializeComponent()
   End Sub 'New
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
   End Sub 'Main
   
   
   Private Sub InitializeComponent()
      Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.toolStripButton1 = New System.Windows.Forms.ToolStripButton()
      Me.toolStrip1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' toolStrip1
      ' 
      Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButton1})
      Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.toolStrip1.Name = "toolStrip1"
      Me.toolStrip1.TabIndex = 0
      Me.toolStrip1.Text = "toolStrip1"
      ' 
      ' toolStripButton1
      ' <snippet2>
      Me.toolStripButton1.AutoToolTip = False
      Me.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.toolStripButton1.Name = "toolStripButton1"
      Me.toolStripButton1.Text = "Button1"
      Me.toolStripButton1.ToolTipText = "ToolTip for Button1."
      ' </snippet2>
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.Add(toolStrip1)
      Me.Name = "Form1"
      Me.toolStrip1.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub 'InitializeComponent 
End Class 'Form1
'</snippet1>