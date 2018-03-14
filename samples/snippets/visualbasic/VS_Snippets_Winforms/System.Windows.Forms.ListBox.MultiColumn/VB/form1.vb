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
   Private listBox1 As ListBox
   
   
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
      Me.listBox1 = New System.Windows.Forms.ListBox()
      Me.SuspendLayout()
      ' 
      ' listBox1
      ' 
      Me.listBox1.FormattingEnabled = True
      Me.listBox1.HorizontalScrollbar = True
      Me.listBox1.Items.AddRange(New Object() {"Item 1, column 1", "Item 2, column 1", "Item 3, column 1", "Item 4, column 1", "Item 5, column 1", "Item 1, column 2", "Item 2, column 2", "Item 3, column 2"})
      Me.listBox1.Location = New System.Drawing.Point(0, 0)
      Me.listBox1.MultiColumn = True
      Me.listBox1.Name = "listBox1"
      Me.listBox1.ScrollAlwaysVisible = True
      Me.listBox1.Size = New System.Drawing.Size(120, 95)
      Me.listBox1.TabIndex = 0
      Me.listBox1.ColumnWidth = 85
      ' 
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.Add(listBox1)
      Me.Name = "Form1"
      Me.ResumeLayout(False)
   End Sub
End Class
'</Snippet1>