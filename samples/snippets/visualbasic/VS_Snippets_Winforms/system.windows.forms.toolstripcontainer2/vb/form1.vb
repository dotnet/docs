 ' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms




Public Class Form1
   Inherits Form
   Private toolStripContainer1 As ToolStripContainer
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
      toolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
      toolStrip1 = New System.Windows.Forms.ToolStrip()
      ' Add items to the ToolStrip.
      toolStrip1.Items.Add("One")
      toolStrip1.Items.Add("Two")
      toolStrip1.Items.Add("Three")
      ' Add the ToolStrip to the top panel of the ToolStripContainer.
      toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1)
      ' Add the ToolStripContainer to the form.
      Controls.Add(toolStripContainer1)
   End Sub 'InitializeComponent 
End Class 'Form1
' </Snippet1>