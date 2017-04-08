 '<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
   Inherits Form
   Private WithEvents toolStripButton1 As ToolStripButton
   Private WithEvents toolStripButton2 As ToolStripButton
   Private toolStrip1 As ToolStrip
   
   
   Public Sub New()
      InitializeComponent()
   End Sub
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
   End Sub
   
   
   Private Sub InitializeComponent()
      Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.toolStripButton1 = New System.Windows.Forms.ToolStripButton()
      Me.toolStripButton2 = New System.Windows.Forms.ToolStripButton()
      Me.toolStrip1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' toolStrip1
      ' 
      Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButton1, Me.toolStripButton2})
      Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.toolStrip1.Name = "toolStrip1"
      Me.toolStrip1.TabIndex = 0
      Me.toolStrip1.Text = "toolStrip1"
      ' 
      ' toolStripButton1
      ' <snippet2>
      Me.toolStripButton1.Image = Bitmap.FromFile("c:\NewItem.bmp")
      Me.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
      Me.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.toolStripButton1.Name = "toolStripButton1"
      Me.toolStripButton1.Text = "&New"
      Me.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      ' </snippet2>
      ' toolStripButton2
      ' 
      Me.toolStripButton2.Image = Bitmap.FromFile("c:\OpenItem.bmp")
      Me.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
      Me.toolStripButton2.Name = "toolStripButton2"
      Me.toolStripButton2.Text = "&Open"
      ' 
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.Add(toolStrip1)
      Me.Name = "Form1"
      Me.toolStrip1.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub
    
   
   Private Sub toolStripButton1_Click(sender As Object, e As EventArgs) Handles toolStripButton1.Click
      MessageBox.Show("You have mail.")
   End Sub
   
   
   Private Sub toolStripButton2_Click(sender As Object, e As EventArgs) Handles toolStripButton2.Click
   ' Add the response to the Click event here.
   End Sub
End Class
'</snippet1>