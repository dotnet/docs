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
   Private WithEvents radioButton1 As RadioButton
   Private WithEvents radioButton2 As RadioButton
   
   
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
      Me.radioButton1 = New System.Windows.Forms.RadioButton()
      Me.radioButton2 = New System.Windows.Forms.RadioButton()
      Me.SuspendLayout()
      ' 
      ' radioButton1
      ' 
      Me.radioButton1.AutoSize = True
      Me.radioButton1.Location = New System.Drawing.Point(0, 0)
      Me.radioButton1.Name = "radioButton1"
      Me.radioButton1.Size = New System.Drawing.Size(62, 17)
      Me.radioButton1.TabIndex = 0
      Me.radioButton1.TabStop = True
      Me.radioButton1.Text = "Button1"
      Me.radioButton1.UseVisualStyleBackColor = True
      ' 
      ' radioButton2
      ' 
      Me.radioButton2.AutoSize = True
      Me.radioButton2.Location = New System.Drawing.Point(0, 39)
      Me.radioButton2.Name = "radioButton2"
      Me.radioButton2.Size = New System.Drawing.Size(126, 17)
      Me.radioButton2.TabIndex = 1
      Me.radioButton2.TabStop = True
      Me.radioButton2.Text = "Change Button1 font."
      Me.radioButton2.UseVisualStyleBackColor = True
      ' 
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.Add(radioButton2)
      Me.Controls.Add(radioButton1)
      Me.Name = "Form1"
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub
    
   
   Private Sub radioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton2.CheckedChanged
      radioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
   End Sub
   
   
   Private Sub radioButton1_FontChanged(sender As Object, e As EventArgs) Handles radioButton1.FontChanged
      MessageBox.Show("The font has been changed.")
   End Sub
End Class
'</Snippet1>