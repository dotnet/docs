 ' <Snippet1>
Imports System
Imports System.Windows.Forms



Public Class Form1
   Inherits Form
   Private toolStripContainer1 As ToolStripContainer
   Private toolStrip1 As ToolStrip
   Private richTextBox1 As RichTextBox
   
   
   Public Sub New()
      DragToolStrip()
   End Sub
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
   End Sub
   
   
   Private Sub DragToolStrip()
      ' Create a ToolStripContainer.
      toolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
      toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Controls.Add(toolStripContainer1)
      
      ' Create a ToolStrip and add items to it.
      toolStrip1 = New System.Windows.Forms.ToolStrip()
      toolStrip1.Items.Add("One")
      toolStrip1.Items.Add("Two")
      toolStrip1.Items.Add("Three")
      
      ' Add the ToolStrip to the top panel of the ToolStripContainer.
      toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1)
      
      ' Create a RichTextBox and add it to the ContentPanel.
      richTextBox1 = New System.Windows.Forms.RichTextBox()
      richTextBox1.Location = New System.Drawing.Point(94, 61)
      toolStripContainer1.ContentPanel.Controls.Add(richTextBox1)
      
      ' Attach event handlers for the BeginDrag and EndDrag events.
      AddHandler toolStrip1.BeginDrag, AddressOf toolStrip1_BeginDrag
      AddHandler toolStrip1.EndDrag, AddressOf toolStrip1_EndDrag
   End Sub
   
   ' Clear any text from the RichTextBox when a drag operation begins.
   Private Sub toolStrip1_BeginDrag(sender As Object, e As EventArgs)
      richTextBox1.Text = ""
   End Sub
   
   ' Notify the user when the drag operation ends.
   Private Sub toolStrip1_EndDrag(sender As Object, e As EventArgs)
      richTextBox1.Text = "The drag operation is complete."
   End Sub
End Class
' </Snippet1>