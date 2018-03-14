 ' <snippet10>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms




Public Class SimpleForm
   Inherits System.Windows.Forms.Form

   Private firstControl1 As FirstControl
   
   Private components As System.ComponentModel.Container = Nothing
   
   
   Public Sub New()
      InitializeComponent()
   End Sub 
   
   

   
   
   Private Sub InitializeComponent()
      Me.firstControl1 = New FirstControl()
      Me.SuspendLayout()
      
      ' 
      ' firstControl1
      ' 
      Me.firstControl1.BackColor = System.Drawing.SystemColors.ControlDark
      Me.firstControl1.Location = New System.Drawing.Point(96, 104)
      Me.firstControl1.Name = "firstControl1"
      Me.firstControl1.Size = New System.Drawing.Size(75, 16)
      Me.firstControl1.TabIndex = 0
      Me.firstControl1.Text = "Hello World"
      Me.firstControl1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
      
      ' 
      ' SimpleForm
      ' 
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(firstControl1)
      Me.Name = "SimpleForm"
      Me.Text = "SimpleForm"
      Me.ResumeLayout(False)
   End Sub 
    
   
   <STAThread()>  _
   Shared Sub Main()
      Application.Run(New SimpleForm())
   End Sub 
End Class 
' </snippet10>