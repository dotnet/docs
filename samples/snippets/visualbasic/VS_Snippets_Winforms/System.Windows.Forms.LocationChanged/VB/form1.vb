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
   Private WithEvents statusStrip1 As StatusStrip
   
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
      Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.SuspendLayout()
      ' 
      ' statusStrip1
      ' 
      Me.statusStrip1.Location = New System.Drawing.Point(0, 251)
      Me.statusStrip1.Name = "statusStrip1"
      Me.statusStrip1.Size = New System.Drawing.Size(292, 22)
      Me.statusStrip1.TabIndex = 0
      Me.statusStrip1.Text = "statusStrip1"
      ' 
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.Add(statusStrip1)
      Me.Name = "Form1"
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub
    
   
   Private Sub statusStrip1_LocationChanged(sender As Object, e As EventArgs) Handles statusStrip1.LocationChanged
      MessageBox.Show("The form has been resized.")
   End Sub
End Class
' </Snippet1>