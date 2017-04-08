Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace ControlMembers6
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents button1 As System.Windows.Forms.Button
      Private WithEvents textBox1 As System.Windows.Forms.TextBox
      Private WithEvents button2 As System.Windows.Forms.Button
      Private WithEvents checkBox1 As System.Windows.Forms.CheckBox
      Private WithEvents button3 As System.Windows.Forms.Button
      Private WithEvents button4 As System.Windows.Forms.Button
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
         textBox1.Enabled = checkBox1.Checked
      End Sub 'New
      
      
      Protected Overrides Overloads Sub Dispose(disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose
      

      Private Sub InitializeComponent()
         Me.button1 = New System.Windows.Forms.Button()
         Me.textBox1 = New System.Windows.Forms.TextBox()
         Me.button2 = New System.Windows.Forms.Button()
         Me.checkBox1 = New System.Windows.Forms.CheckBox()
         Me.button3 = New System.Windows.Forms.Button()
         Me.button4 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(48, 40)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 0
         Me.button1.Text = "Focus"
         ' 
         ' textBox1
         ' 
         Me.textBox1.Location = New System.Drawing.Point(48, 88)
         Me.textBox1.Name = "textBox1"
         Me.textBox1.TabIndex = 1
         Me.textBox1.Text = "textBox1"
         ' 
         ' button2
         ' 
         Me.button2.Location = New System.Drawing.Point(160, 40)
         Me.button2.Name = "button2"
         Me.button2.TabIndex = 2
         Me.button2.Text = "Select"
         ' 
         ' checkBox1
         ' 
         Me.checkBox1.Location = New System.Drawing.Point(160, 88)
         Me.checkBox1.Name = "checkBox1"
         Me.checkBox1.TabIndex = 3
         Me.checkBox1.Text = "Enabled"
         ' 
         ' button3
         ' 
         Me.button3.Location = New System.Drawing.Point(216, 248)
         Me.button3.Name = "button3"
         Me.button3.TabIndex = 4
         Me.button3.Text = "button3"
         ' 
         ' button4
         ' 
         Me.button4.Location = New System.Drawing.Point(0, 248)
         Me.button4.Name = "button4"
         Me.button4.TabIndex = 5
         Me.button4.Text = "button4"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button4, Me.button3, checkBox1, Me.button2, Me.textBox1, Me.button1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
      <STAThread()> _
      Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main
      
      
      Private Sub button1_Click(sender As Object, e As System.EventArgs) Handles button1.Click
         Me.ControlSetFocus(Me.textBox1)
      End Sub 'button1_Click
      
      
'<snippet1>
Public Sub ControlSetFocus(control As Control)
   ' Set focus to the control, if it can receive focus.
   If control.CanFocus Then
      control.Focus()
   End If
End Sub
'</snippet1>

'<snippet2>
Public Sub ControlSelect(control As Control)
   ' Select the control, if it can be selected.
   If control.CanSelect Then
      control.Select()
   End If
End Sub
'</snippet2>
      
      
      
      
      
      Private Sub checkBox1_CheckedChanged(sender As Object, e As System.EventArgs) Handles checkBox1.CheckedChanged
         textBox1.Enabled = checkBox1.Checked
      End Sub 'checkBox1_CheckedChanged
      
      
      Private Sub button2_Click(sender As Object, e As System.EventArgs) Handles button2.Click
         Me.ControlSelect(Me.textBox1)
      End Sub 'button2_Click
      
      
'<snippet3>
Public Sub EnableDoubleBuffering()
   ' Set the value of the double-buffering style bits to true.
   Me.SetStyle(ControlStyles.DoubleBuffer _
     Or ControlStyles.UserPaint _
     Or ControlStyles.AllPaintingInWmPaint, _
     True)
   Me.UpdateStyles()
End Sub
' </snippet3>

' <snippet4>
Public Function DoubleBufferingEnabled() As Boolean
   ' Get the value of the double-buffering style bits.
   Return Me.GetStyle((ControlStyles.DoubleBuffer _
     Or ControlStyles.UserPaint _
     Or ControlStyles.AllPaintingInWmPaint))
End Function
' </snippet4>
      
      
      Private Sub button4_Click(sender As Object, e As System.EventArgs) Handles button4.Click
         Me.EnableDoubleBuffering()
      End Sub 'button4_Click
      
      
      Private Sub button3_Click(sender As Object, e As System.EventArgs) Handles button3.Click
         MessageBox.Show(Me.DoubleBufferingEnabled().ToString())
         Me.ScaleChildControls()
      End Sub 'button3_Click
      
      
      
' <snippet5>
Public Sub ScaleChildControlsEqually()
   ' Resize all child controls to 1.5 
   ' times their current size.
   Dim i As Integer
   For i = 0 To (Me.Controls.Count) - 1
      Me.Controls(i).Scale(1.5F)
   Next i
End Sub
' </snippet5>
      
' <snippet6>
Public Sub ScaleChildControls()
   ' Resize all child controls to 1.5 times their current
   ' height while, maintaining their current width.
   Dim i As Integer
   For i = 0 To (Me.Controls.Count) - 1
      Me.Controls(i).Scale(1F, 1.5F)
   Next i
End Sub 
' </snippet6>


   End Class
End Namespace
