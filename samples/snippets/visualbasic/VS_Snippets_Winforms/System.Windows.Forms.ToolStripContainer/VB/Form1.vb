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
   Private tsc As ToolStripContainer
   Private rtb As RichTextBox
   Public Sub New()
      InitializeComponent()
   End Sub
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
   End Sub
   
   Private Sub InitializeComponent()
      Me.tsc = New System.Windows.Forms.ToolStripContainer()
      Me.rtb = New System.Windows.Forms.RichTextBox()
      Me.tsc.ContentPanel.Controls.Add(Me.rtb)
      Me.Controls.Add(tsc)
   End Sub
End Class
' </Snippet1>